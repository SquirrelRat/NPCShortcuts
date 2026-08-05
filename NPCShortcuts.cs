using System.Collections.Generic;
using ExileCore;
using ExileCore.PoEMemory;
using SharpDX;
using Vector2 = System.Numerics.Vector2;

namespace NPCShortcuts;

public class NPCShortcuts : BaseSettingsPlugin<NPCShortcutsSettings>
{
    public override bool Initialise()
    {
        return true;
    }

    public override void Render()
    {
        if (!Settings.Enable) return;

        var labelHover = GameController.IngameState.IngameUi.ItemsOnGroundLabelElement.LabelOnHover;
        if (labelHover == null || labelHover.Type != ElementType.MiscGroundLabel) return;

        var hoverPath = GameController.IngameState.IngameUi.ItemsOnGroundLabelElement.ItemOnHoverPath;
        if (!NPCDatabase.TryGetNPC(hoverPath, out var npc)) return;

        DrawShortcuts(npc, labelHover);
    }

    private void DrawShortcuts(NPC npc, Element label)
    {
        var segments = new List<(string Key, string Action)>(3);
        if (!string.IsNullOrEmpty(npc.CtrlAction)) segments.Add(("Ctrl", npc.CtrlAction));
        if (!string.IsNullOrEmpty(npc.AltAction)) segments.Add(("Alt", npc.AltAction));
        if (!string.IsNullOrEmpty(npc.CtrlAltAction)) segments.Add(("CtrlAlt", npc.CtrlAltAction));

        if (segments.Count == 0) return;

        const float padding = 4;
        const string separator = "   ";
        var separatorWidth = Graphics.MeasureText(separator).X;
        var lineHeight = Graphics.MeasureText(separator).Y;

        var width = separatorWidth * (segments.Count - 1);
        foreach (var (key, action) in segments)
        {
            width += Graphics.MeasureText(key + ": ").X + Graphics.MeasureText(action).X;
        }

        var labelRect = label.GetClientRectCache;
        var boxPos = new Vector2(labelRect.Center.X - width / 2 - padding, labelRect.Top - lineHeight - 5 - padding);
        var boxSize = new Vector2(width + padding * 2, lineHeight + padding * 2);

        Graphics.DrawBox(new RectangleF(boxPos.X, boxPos.Y, boxSize.X, boxSize.Y), Color.Black);

        var x = boxPos.X + padding;
        var y = boxPos.Y + padding;
        for (var i = 0; i < segments.Count; i++)
        {
            var keyLabel = segments[i].Key + ": ";
            var keyWidth = Graphics.MeasureText(keyLabel).X;
            Graphics.DrawText(keyLabel, new Vector2(x, y), Settings.TextColor);
            x += keyWidth;

            var action = segments[i].Action;
            var actionWidth = Graphics.MeasureText(action).X;
            Graphics.DrawText(action, new Vector2(x, y), GetActionColor(action));
            x += actionWidth;

            if (i < segments.Count - 1) x += separatorWidth;
        }
    }

    private Color GetActionColor(string action) => action switch
    {
        "Sell" => Settings.SellColor,
        "Buy" => Settings.BuyColor,
        _ => Settings.OtherActionColor
    };
}
