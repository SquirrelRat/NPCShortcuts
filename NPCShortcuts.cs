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
        var actions = new List<string>(3);
        if (!string.IsNullOrEmpty(npc.CtrlAction)) actions.Add("Ctrl: " + npc.CtrlAction);
        if (!string.IsNullOrEmpty(npc.AltAction)) actions.Add("Alt: " + npc.AltAction);
        if (!string.IsNullOrEmpty(npc.CtrlAltAction)) actions.Add("CtrlAlt: " + npc.CtrlAltAction);

        if (actions.Count == 0) return;

        var stringToDisplay = npc.Name + ": " + string.Join("   ", actions);

        var labelRect = label.GetClientRectCache;
        var textSize = Graphics.MeasureText(stringToDisplay);

        const float padding = 4;
        var boxPos = new Vector2(labelRect.Center.X - textSize.X / 2 - padding, labelRect.Top - textSize.Y - 5 - padding);
        var boxSize = new Vector2(textSize.X + padding * 2, textSize.Y + padding * 2);

        Graphics.DrawBox(new RectangleF(boxPos.X, boxPos.Y, boxSize.X, boxSize.Y), Color.Black);
        Graphics.DrawText(stringToDisplay, new Vector2(boxPos.X + padding, boxPos.Y + padding), Settings.TextColor);
    }
}
