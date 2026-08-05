using System.Collections.Generic;
using ExileCore;
using ExileCore.PoEMemory;
using ExileCore.PoEMemory.Components;
using ExileCore.PoEMemory.FilesInMemory;
using SharpDX;
using Vector2 = System.Numerics.Vector2;

namespace NPCShortcuts;

public class NPCShortcuts : BaseSettingsPlugin<NPCShortcutsSettings>
{
    private const float Padding = 4;
    private const float TopOffset = 5;
    private const string Separator = "   ";

    private static readonly Dictionary<string, string> ActionLabels = new()
    {
        ["Sell Items"] = "Sell",
        ["Purchase Items"] = "Buy",
        ["Identify Items"] = "Identify",
        ["Identify all items"] = "Identify",
        ["Trade Divination Cards"] = "Cards",
        ["Gamble for Items"] = "Gamble",
        ["Haggle for Items"] = "Haggle",
        ["Deal for Items"] = "Deal",
        ["Exchange Items"] = "Exchange",
        ["Currency Exchange"] = "Currency",
        ["Manage Shop"] = "Shop",
        ["Manage Town"] = "Town",
        ["Respecialisation"] = "Respec",
        ["Atlas Respecialisation"] = "Atlas Respec",
        ["Anoint Items"] = "Anoint",
        ["Anointing Oils"] = "Anoint Oils",
        ["Unveil Items"] = "Unveil",
        ["View Bestiary"] = "Bestiary",
        ["View Temple"] = "Temple",
        ["View Subterranean Chart"] = "Delve Map",
        ["View Memory Map"] = "Memory Map",
        ["View Favours"] = "Favours",
        ["View Necropolis Morgue"] = "Morgue",
        ["Show Expedition Map"] = "Logbook",
        ["Show Expedition"] = "Logbook",
        ["Show Inventory"] = "Inventory",
        ["Show Investigation"] = "Investigation",
        ["Open Expedition Locker"] = "Locker",
        ["Open Chart"] = "Chart",
        ["Chart Area"] = "Chart",
        ["Plan Voyage"] = "Voyage",
        ["Invite to Hideout"] = "Hideout",
        ["Select Hideout"] = "Hideout",
        ["Select Guild Hideout"] = "Guild HO",
        ["Create Hideout"] = "New HO",
        ["Secret Hideout"] = "Secret HO",
        ["Clear the Hideout"] = "Clear HO",
        ["Town Recruitment"] = "Recruit",
        ["Invest in Recruitment"] = "Recruit",
        ["Allocate a Worker"] = "Worker",
        ["Fund the Treasury"] = "Treasury",
        ["Prepare Heist"] = "Heist",
        ["Prepare Grand Heist"] = "Grand Heist",
        ["Reveal Blueprint Details"] = "Blueprints",
        ["Buy Contracts"] = "Contracts",
        ["Enter Incursion"] = "Incursion",
        ["Enter Temple"] = "Enter Temple",
        ["Take Temple Chronicle"] = "Chronicle",
        ["Take Voidstones"] = "Voidstones",
        ["Take Map"] = "Map",
        ["Shipping"] = "Shipping",
        ["Disenchanting"] = "Disenchant",
        ["Craft"] = "Craft",
        ["Allflame Crafting"] = "Allflame",
        ["Visit Menagerie"] = "Menagerie",
        ["Visit Memory Nexus"] = "Nexus",
        ["Visit Kingsmarch"] = "Kingsmarch",
        ["Visit Tane's Laboratory"] = "Lab",
        ["Visit the Necropolis"] = "Necropolis",
        ["Visit Mine Encampment"] = "Mines",
        ["Visit the Monastery"] = "Monastery",
        ["Trade"] = "Trade"
    };

    private long _cacheEntityAddr;
    private LayoutData? _cacheLayout;

    public override bool Initialise()
    {
        return true;
    }

    public override void Render()
    {
        if (!Settings.Enable) return;

        var labelElement = GameController.IngameState.IngameUi.ItemsOnGroundLabelElement;
        var labelHover = labelElement.LabelOnHover;
        if (labelHover == null || labelHover.Type != ElementType.MiscGroundLabel) return;

        var entity = labelElement.ItemOnHover;
        if (entity == null) return;

        var npcDat = entity.GetComponent<NPC>()?.NpcDat;
        if (npcDat == null) return;

        if (_cacheEntityAddr != entity.Address)
        {
            _cacheEntityAddr = entity.Address;
            var path = entity.Path;
            var name = npcDat.Name ?? string.Empty;
            var actions = ParseActions(npcDat);
            _cacheLayout = BuildLayout(path, name, actions);
        }

        if (_cacheLayout != null) DrawLayout(_cacheLayout, labelHover);
    }

    private static List<string> ParseActions(NpcDat npcDat)
    {
        var result = new List<string>(4);
        var seen = new HashSet<string>();
        foreach (var talk in npcDat.Talk)
        {
            if (talk?.Name == null) continue;
            if (ActionLabels.TryGetValue(talk.Name, out var label) && seen.Add(label))
                result.Add(label);
        }

        return result;
    }

    private static List<(string Key, string Action)> BuildSegments(string entityPath, string npcName, List<string> actions)
    {
        var (overrides, isPathSpecific) = NPCHotkeys.Get(entityPath, npcName);

        List<(string Key, string Action)> segments;
        if (isPathSpecific && overrides != null)
            segments = OverrideToSegments(overrides);
        else if (overrides != null)
            segments = BuildNameSegments(overrides, actions);
        else
            segments = BuildDefaultSegments(actions);

        segments.Sort((a, b) => KeyPriority(a.Key).CompareTo(KeyPriority(b.Key)));
        return segments;
    }

    private static List<(string Key, string Action)> OverrideToSegments(IReadOnlyDictionary<string, string> overrides)
    {
        var segments = new List<(string Key, string Action)>(overrides.Count);
        foreach (var kv in overrides)
            segments.Add((kv.Value, kv.Key));
        return segments;
    }

    private static List<(string Key, string Action)> BuildNameSegments(IReadOnlyDictionary<string, string> overrides, List<string> actions)
    {
        var segments = new List<(string Key, string Action)>();
        if (actions.Count > 0)
        {
            foreach (var action in actions)
                if (overrides.TryGetValue(action, out var key))
                    segments.Add((key, action));
        }
        else
        {
            foreach (var kv in overrides)
                segments.Add((kv.Value, kv.Key));
        }

        return segments;
    }

    private static List<(string Key, string Action)> BuildDefaultSegments(List<string> actions)
    {
        var segments = new List<(string Key, string Action)>(2);
        if (actions.Contains("Sell")) segments.Add(("Ctrl", "Sell"));
        if (actions.Contains("Buy")) segments.Add(("Alt", "Buy"));
        return segments;
    }

    private LayoutData? BuildLayout(string entityPath, string npcName, List<string> actions)
    {
        var segments = BuildSegments(entityPath, npcName, actions);
        if (segments.Count == 0) return null;

        var layout = new LayoutData();
        layout.SeparatorWidth = Graphics.MeasureText(Separator).X;
        layout.LineHeight = Graphics.MeasureText(Separator).Y;

        foreach (var (key, action) in segments)
        {
            layout.KeyWidths.Add(Graphics.MeasureText(key + ": ").X);
            layout.ActionWidths.Add(Graphics.MeasureText(action).X);
            layout.Segments.Add((key, action));
        }

        layout.TotalWidth = layout.SeparatorWidth * (segments.Count - 1);
        for (var i = 0; i < segments.Count; i++)
            layout.TotalWidth += layout.KeyWidths[i] + layout.ActionWidths[i];

        return layout;
    }

    private void DrawLayout(LayoutData layout, Element label)
    {
        var labelRect = label.GetClientRectCache;
        var boxPos = new Vector2(labelRect.Center.X - layout.TotalWidth / 2 - Padding, labelRect.Top - layout.LineHeight - TopOffset - Padding);
        var boxSize = new Vector2(layout.TotalWidth + Padding * 2, layout.LineHeight + Padding * 2);

        Graphics.DrawBox(new RectangleF(boxPos.X, boxPos.Y, boxSize.X, boxSize.Y), Color.Black);

        var x = boxPos.X + Padding;
        var y = boxPos.Y + Padding;
        for (var i = 0; i < layout.Segments.Count; i++)
        {
            var keyLabel = layout.Segments[i].Key + ": ";
            Graphics.DrawText(keyLabel, new Vector2(x, y), Settings.TextColor);
            x += layout.KeyWidths[i];

            var action = layout.Segments[i].Action;
            Graphics.DrawText(action, new Vector2(x, y), GetActionColor(action));
            x += layout.ActionWidths[i];

            if (i < layout.Segments.Count - 1) x += layout.SeparatorWidth;
        }
    }

    private Color GetActionColor(string action) => action switch
    {
        "Sell" => Settings.SellColor,
        "Buy" => Settings.BuyColor,
        _ => Settings.OtherActionColor
    };

    private static int KeyPriority(string key) => key switch
    {
        "Ctrl" => 0,
        "Alt" => 1,
        "CtrlAlt" => 2,
        _ => 3
    };

    private sealed class LayoutData
    {
        public List<(string Key, string Action)> Segments { get; } = new();
        public List<float> KeyWidths { get; } = new();
        public List<float> ActionWidths { get; } = new();
        public float SeparatorWidth;
        public float LineHeight;
        public float TotalWidth;
    }
}
