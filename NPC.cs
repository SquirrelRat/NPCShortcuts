using System;

namespace NPCShortcuts;

public sealed class NPC
{
    public string Name { get; }
    public string? CtrlAction { get; }
    public string? AltAction { get; }
    public string? CtrlAltAction { get; }

    public NPC(string name, string? ctrlAction = null, string? altAction = null, string? ctrlAltAction = null)
    {
        Name = name ?? throw new ArgumentNullException(nameof(name));
        CtrlAction = ctrlAction;
        AltAction = altAction;
        CtrlAltAction = ctrlAltAction;
    }

    public static NPC Vendor(string name) => new(name, "Sell", "Buy");
}
