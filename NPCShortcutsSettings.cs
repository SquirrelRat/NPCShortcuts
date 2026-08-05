using ExileCore.Shared.Interfaces;
using ExileCore.Shared.Nodes;
using SharpDX;

namespace NPCShortcuts;

public class NPCShortcutsSettings : ISettings
{
    public ToggleNode Enable { get; set; } = new ToggleNode(true);
    public ColorNode TextColor { get; set; } = new ColorNode(Color.White);
    public ColorNode SellColor { get; set; } = new ColorNode(Color.Red);
    public ColorNode BuyColor { get; set; } = new ColorNode(Color.LimeGreen);
    public ColorNode OtherActionColor { get; set; } = new ColorNode(Color.Aqua);
    public ColorNode BackgroundColor { get; set; } = new ColorNode(new Color(0, 0, 0, 160));
}
