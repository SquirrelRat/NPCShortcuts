using System.Collections.Generic;

namespace NPCShortcuts;

public static class NPCHotkeys
{
    private static readonly Dictionary<string, Dictionary<string, string>> ByPath = new()
    {
        // Tujen: Expedition (Haggle) vs Kingsmarch (Shipping)
        ["Metadata/NPC/League/Expedition/Haggler"] = new() { ["Haggle"] = "Ctrl", ["Sell"] = "Alt" },
        ["Metadata/NPC/League/Expedition/HagglerHideout"] = new() { ["Haggle"] = "Ctrl", ["Sell"] = "Alt" },
        ["Metadata/NPC/League/Kalguur/VillageTujen"] = new() { ["Shipping"] = "Ctrl", ["Sell"] = "Alt" },

        // Rog: Expedition (Deal) vs Kingsmarch (Disenchant)
        ["Metadata/NPC/League/Expedition/Dealer"] = new() { ["Deal"] = "Ctrl", ["Sell"] = "Alt", ["Disenchant"] = "CtrlAlt" },
        ["Metadata/NPC/League/Expedition/DealerHideout"] = new() { ["Deal"] = "Ctrl", ["Sell"] = "Alt", ["Disenchant"] = "CtrlAlt" },
        ["Metadata/NPC/League/Kalguur/VillageRog"] = new() { ["Disenchant"] = "Ctrl", ["Sell"] = "Alt" },

        // Kirac (hideout dat Talk is empty, so path override renders unconditionally)
        ["Metadata/NPC/Epilogue/Kirac"] = new() { ["Buy"] = "Ctrl", ["Sell"] = "Alt", ["Atlas Respec"] = "CtrlAlt" },
        ["Metadata/NPC/Epilogue/KiracHideout"] = new() { ["Buy"] = "Ctrl", ["Sell"] = "Alt", ["Atlas Respec"] = "CtrlAlt" },

        // Jun: town and hideout both have Ctrl=Unveil
        ["Metadata/NPC/League/Betrayal/BetrayalNinjaCopHideout"] = new() { ["Unveil"] = "Ctrl", ["Investigation"] = "Alt", ["Sell"] = "CtrlAlt" },
        ["Metadata/NPC/League/Betrayal/BetrayalNinjaCop"] = new() { ["Unveil"] = "Ctrl", ["Investigation"] = "Alt", ["Sell"] = "CtrlAlt" },

        // Faustus: town (Currency/Gamble/Respec) vs hideout (Currency/Gamble/Manage Shop)
        ["Metadata/NPC/League/Kalguur/VillageFaustusTown"] = new() { ["Currency"] = "Ctrl", ["Gamble"] = "Alt", ["Respec"] = "CtrlAlt" },
        ["Metadata/NPC/League/Kalguur/VillageFaustusHideout"] = new() { ["Currency"] = "Ctrl", ["Gamble"] = "Alt", ["Shop"] = "CtrlAlt" },

        // Helena (hideout): Ctrl=Sell, CtrlAlt=Identify
        ["Metadata/NPC/Missions/Hideout/Helena"] = new() { ["Sell"] = "Ctrl", ["Identify"] = "CtrlAlt" },

        // Bestel Act 1 (gambler): Ctrl=Sell, Alt=Gamble, CtrlAlt=Respec
        ["Metadata/NPC/Act1/Bestel"] = new() { ["Sell"] = "Ctrl", ["Gamble"] = "Alt", ["Respec"] = "CtrlAlt" },

        // Act 2
        ["Metadata/NPC/Act2/HelenaTown"] = new() { ["Hideout"] = "Ctrl" },
        ["Metadata/NPC/Act2/Greust"] = new() { ["Sell"] = "Ctrl", ["Buy"] = "Alt" },
        ["Metadata/NPC/Act2/Silk"] = new() { ["Sell"] = "Ctrl", ["Gamble"] = "Alt", ["Respec"] = "CtrlAlt" },
        ["Metadata/NPC/Act2/Yeena"] = new() { ["Sell"] = "Ctrl", ["Buy"] = "Alt", ["Identify"] = "CtrlAlt" },

        // Act 3
        ["Metadata/NPC/Act3/ClarissaTown"] = new() { ["Sell"] = "Ctrl", ["Buy"] = "Alt", ["Identify"] = "CtrlAlt" },
        ["Metadata/NPC/Act3/Hargan"] = new() { ["Sell"] = "Ctrl", ["Buy"] = "Alt" },
        ["Metadata/NPC/Act3/Maramoa"] = new() { ["Sell"] = "Ctrl", ["Buy"] = "Alt", ["Respec"] = "CtrlAlt" },

        // Act 4
        ["Metadata/NPC/Act4/Kira"] = new() { ["Sell"] = "Ctrl", ["Buy"] = "Alt" },
        ["Metadata/NPC/Act4/PetarusVanja"] = new() { ["Sell"] = "Ctrl", ["Buy"] = "Alt", ["Identify"] = "CtrlAlt" },
        ["Metadata/NPC/Act4/Tasuni"] = new() { ["Cards"] = "Ctrl", ["Gamble"] = "Alt", ["Sell"] = "CtrlAlt" },

        // Act 5
        ["Metadata/NPC/Act5/BannonTown"] = new() { ["Sell"] = "Ctrl", ["Buy"] = "Alt" },
        ["Metadata/NPC/Act5/Lani"] = new() { ["Sell"] = "Ctrl", ["Buy"] = "Alt", ["Identify"] = "CtrlAlt" },
        ["Metadata/NPC/Act5/Vilenta"] = new() { ["Sell"] = "Ctrl", ["Gamble"] = "Alt", ["Respec"] = "CtrlAlt" },

        // Act 6
        ["Metadata/NPC/Act6/Bestel"] = new() { ["Sell"] = "Ctrl", ["Buy"] = "Alt", ["Identify"] = "CtrlAlt" },
        ["Metadata/NPC/Act6/Tarkleigh"] = new() { ["Sell"] = "Ctrl", ["Buy"] = "Alt" },

        // Act 7
        ["Metadata/NPC/Act7/Helena"] = new() { ["Hideout"] = "Ctrl", ["Sell"] = "CtrlAlt" },
        ["Metadata/NPC/Act7/YeenaTown"] = new() { ["Sell"] = "Ctrl", ["Buy"] = "Alt", ["Identify"] = "CtrlAlt" },

        // Act 8
        ["Metadata/NPC/Act8/ClarissaTown"] = new() { ["Sell"] = "Ctrl", ["Buy"] = "Alt", ["Identify"] = "CtrlAlt" },
        ["Metadata/NPC/Act8/Hargan"] = new() { ["Sell"] = "Ctrl", ["Buy"] = "Alt" },

        // Act 9
        ["Metadata/NPC/Act9/Irasha"] = new() { ["Sell"] = "Ctrl", ["Buy"] = "Alt" },
        ["Metadata/NPC/Act9/PetarusVanja"] = new() { ["Sell"] = "Ctrl", ["Buy"] = "Alt", ["Identify"] = "CtrlAlt" },
        ["Metadata/NPC/Act9/Tasuni"] = new() { ["Cards"] = "Ctrl" },

        // Act 10
        ["Metadata/NPC/Act10/Lani"] = new() { ["Sell"] = "Ctrl", ["Buy"] = "Alt", ["Identify"] = "CtrlAlt" },
        ["Metadata/NPC/Act10/Weylam"] = new() { ["Sell"] = "Ctrl", ["Buy"] = "Alt" },

        // Epilogue
        ["Metadata/NPC/Epilogue/Lani"] = new() { ["Sell"] = "Ctrl", ["Buy"] = "Alt", ["Identify"] = "CtrlAlt" },
        ["Metadata/NPC/Epilogue/Weylam"] = new() { ["Sell"] = "Ctrl", ["Buy"] = "Alt" },
        ["Metadata/NPC/Epilogue/Helena"] = new() { ["Hideout"] = "Ctrl" },

        // Einhar Menagerie: Ctrl=Bestiary, Alt=Sell, CtrlAlt=Identify (hideout/town are Bestiary-only)
        ["Metadata/NPC/League/Bestiary/EinharMenagerie"] = new() { ["Bestiary"] = "Ctrl", ["Sell"] = "Alt", ["Identify"] = "CtrlAlt" },

        // Niko Mine Encampment: Ctrl=Delve Map, Alt=Buy, CtrlAlt=Identify
        ["Metadata/NPC/League/Delve/DelveMinerHub"] = new() { ["Delve Map"] = "Ctrl", ["Buy"] = "Alt", ["Identify"] = "CtrlAlt" },

        // Divinia (Sanctum airlock): Ctrl=Sell only
        ["Metadata/NPC/League/Sanctum/SanctumNPCAirlock"] = new() { ["Sell"] = "Ctrl" },

        // Heist rogues: Ctrl=Show Inventory
        ["Metadata/NPC/League/Heist/HeavyLifter1"] = new() { ["Inventory"] = "Ctrl" },
        ["Metadata/NPC/League/Heist/Lockpick1"] = new() { ["Inventory"] = "Ctrl" },

        // Ailith (Monastery): Ctrl=Sell only
        ["Metadata/NPC/League/Chayula/ChayulaFarmerHub"] = new() { ["Sell"] = "Ctrl" },

        // Valerie (Deepwater Sovereign): Ctrl=Chart, Alt=Sell, CtrlAlt=Identify
        ["Metadata/NPC/League/Deepwater/Valerie"] = new() { ["Chart"] = "Ctrl", ["Sell"] = "Alt", ["Identify"] = "CtrlAlt" },

        // Vesper (Deepwater crafting): Ctrl=Allflame Craft
        ["Metadata/NPC/League/Deepwater/VesperCrafting"] = new() { ["Allflame"] = "Ctrl" },

        // Kingsmarch
        ["Metadata/NPC/League/Kalguur/VillageFaustus"] = new() { ["Currency"] = "Ctrl", ["Gamble"] = "Alt", ["Respec"] = "CtrlAlt" },
        ["Metadata/NPC/League/Kalguur/VillageIsla"] = new() { ["Sell"] = "Ctrl", ["Identify"] = "CtrlAlt" }
    };

    private static readonly Dictionary<string, Dictionary<string, string>> ByName = new()
    {
        ["Lilly Roth"] = new() { ["Sell"] = "Ctrl", ["Buy"] = "Alt", ["Cards"] = "CtrlAlt" },
        ["Gwennen, the Gambler"] = new() { ["Gamble"] = "Ctrl", ["Sell"] = "Alt" },
        ["Dannig, Warrior Skald"] = new() { ["Logbook"] = "Ctrl", ["Sell"] = "Alt", ["Exchange"] = "CtrlAlt" },
        ["Einhar, Beastmaster"] = new() { ["Bestiary"] = "Ctrl" },
        ["Niko, Master of the Depths"] = new() { ["Delve Map"] = "Ctrl" },
        ["Alva, Master Explorer"] = new() { ["Temple"] = "Ctrl" },
        ["Sister Cassia"] = new() { ["Anoint"] = "Ctrl" },
        ["Johan, the King's Hand"] = new() { ["Town"] = "Ctrl" },
        ["Raulf, the Recruiter"] = new() { ["Recruit"] = "Ctrl" },
        ["Isla, the Engineer"] = new() { ["Inventory"] = "Ctrl", ["Sell"] = "Ctrl" },
        ["Adiyah, the Wayfinder"] = new() { ["Heist"] = "Ctrl", ["Grand Heist"] = "Alt" },
        ["Whakano, the Barber"] = new() { ["Blueprints"] = "Ctrl", ["Buy"] = "Alt" },
        ["Valerie, the Corsair"] = new() { ["Chart"] = "Ctrl", ["Sell"] = "Alt" },
        ["Faustus, the Fence"] = new() { ["Sell"] = "Ctrl", ["Identify"] = "CtrlAlt" }
    };

    public static (IReadOnlyDictionary<string, string>? Map, bool IsPathSpecific) Get(string entityPath, string npcName)
    {
        if (ByPath.TryGetValue(entityPath, out var map)) return (map, true);
        return (ByName.TryGetValue(npcName, out map) ? map : null, false);
    }
}
