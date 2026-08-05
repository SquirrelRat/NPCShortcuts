using ExileCore.Shared.Interfaces;
using ExileCore.Shared.Nodes;
using SharpDX;

namespace NPCShortcuts;

public class NPCShortcutsSettings : ISettings
{
    public ToggleNode Enable { get; set; } = new ToggleNode(true);
    public ColorNode TextColor { get; set; } = new ColorNode(Color.White);
}
