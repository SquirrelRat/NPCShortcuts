using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace NPCShortcuts;

public static class NPCDatabase
{
    private static readonly Dictionary<string, NPC> NPCByPath = new()
    {
        // Act 1
        {
            "Metadata/NPC/Act1/Nessa", NPC.Vendor("Nessa")
        },
        {
            "Metadata/NPC/Act1/Tarkleigh", NPC.Vendor("Tarkleigh")
        },
        // Act 2
        {
            "Metadata/NPC/Act2/Greust", NPC.Vendor("Greust")
        },
        {
            "Metadata/NPC/Act2/HelenaTown", new NPC("Helena", "Hideout")
        },
        {
            "Metadata/NPC/Act2/Yeena", NPC.Vendor("Yeena")
        },
        {
            "Metadata/NPC/League/Bestiary/Einhar", new NPC("Einhar, Beastmaster", "Bestiary")
        },
        // Act 3
        {
            "Metadata/NPC/Act3/ClarissaTown", NPC.Vendor("Clarissa")
        },
        {
            "Metadata/NPC/Act3/Hargan", NPC.Vendor("Hargan")
        },
        // Act 4
        {
            "Metadata/NPC/Act4/Kira", NPC.Vendor("Kira")
        },
        {
            "Metadata/NPC/Act4/PetarusVanja", NPC.Vendor("Petarus and Vanja")
        },
        {
            "Metadata/NPC/Act4/Tasuni", new NPC("Tasuni", "Cards")
        },
        {
            "Metadata/NPC/League/Delve/DelveMiner", new NPC("Niko, Master of the Depths", "Delve Chart")
        },
        // Act 5
        {
            "Metadata/NPC/Act5/Lani", NPC.Vendor("Lani")
        },
        {
            "Metadata/NPC/Act5/BannonTown", NPC.Vendor("Bannon")
        },
        // Act 6
        {
            "Metadata/NPC/Act6/Lilly", new NPC("Lilly Roth", "Sell", "Gems")
        },
        {
            "Metadata/NPC/Act6/Bestel", NPC.Vendor("Bestel")
        },
        {
            "Metadata/NPC/Act6/Tarkleigh", NPC.Vendor("Tarkleigh")
        },
        {
            "Metadata/NPC/League/Expedition/Saga", new NPC("Dannig, Warrior Skald", "Exchange", null, "Sell")
        },
        {
            "Metadata/NPC/League/Expedition/Dealer", new NPC("Rog, the Dealer", "Deal", "Sell")
        },
        {
            "Metadata/NPC/League/Expedition/Gambler", new NPC("Gwennen, the Gambler", "Gamble", "Sell")
        },
        {
            "Metadata/NPC/League/Expedition/Haggler", new NPC("Tujen, the Haggler", "Haggle", "Sell")
        },
        // Act 7
        {
            "Metadata/NPC/League/Incursion/TreasureHunter", new NPC("Alva, Master Explorer", "Temple")
        },
        {
            "Metadata/NPC/Act7/YeenaTown", NPC.Vendor("Yeena")
        },
        {
            "Metadata/NPC/Act7/Helena", new NPC("Helena", "Hideout", null, "Sell")
        },
        // Act 8
        {
            "Metadata/NPC/Act8/ClarissaTown", NPC.Vendor("Clarissa")
        },
        {
            "Metadata/NPC/Act8/Hargan", NPC.Vendor("Hargan")
        },
        // Act 9
        {
            "Metadata/NPC/Act9/Tasuni", new NPC("Tasuni", "Cards")
        },
        {
            "Metadata/NPC/League/Betrayal/BetrayalNinjaCop", new NPC("Jun, Veiled Master", "Unveil", "Syndicate", "Sell")
        },
        {
            "Metadata/NPC/Act9/PetarusVanja", NPC.Vendor("Petarus and Vanja")
        },
        {
            "Metadata/NPC/Act9/Irasha", NPC.Vendor("Irasha")
        },
        // Act 10
        {
            "Metadata/NPC/Act10/Lani", NPC.Vendor("Lani")
        },
        {
            "Metadata/NPC/Act10/Weylam", NPC.Vendor("Weylam Roth")
        },
        {
            "Metadata/NPC/Act10/Lilly", new NPC("Lilly Roth", "Sell", "Gems")
        },
        // Epilogue
        {
            "Metadata/NPC/League/Blight/BlightBuilder", new NPC("Sister Cassia", "Anoint")
        },
        {
            "Metadata/NPC/Epilogue/Weylam", NPC.Vendor("Weylam Roth")
        },
        {
            "Metadata/NPC/Epilogue/Lani", NPC.Vendor("Lani")
        },
        {
            "Metadata/NPC/Epilogue/Helena", new NPC("Helena", "Hideout")
        },
        {
            "Metadata/NPC/Epilogue/Kirac", new NPC("Commander Kirac", "Purchase", "Sell")
        },
        // League mechanic areas
        {
            "Metadata/NPC/League/Sanctum/SanctumNPCAirlock", new NPC("Divinia", "Sell")
        },
        {
            "Metadata/NPC/League/Sanctum/SanctumNPCMerchant", new NPC("Divinia", "Purchase")
        },
        {
            "Metadata/NPC/League/Bestiary/EinharMenagerie", new NPC("Einhar, Beastmaster", "Bestiary", "Purchase", "Sell")
        },
        {
            "Metadata/NPC/League/Delve/DelveMinerHub", new NPC("Niko, Master of the Depths", "Delve Chart", "Purchase")
        },
        // Hideout
        {
            "Metadata/NPC/League/Expedition/DealerHideout", new NPC("Rog, the Dealer", "Deal", "Sell")
        },
        {
            "Metadata/NPC/League/Expedition/SagaHideout", new NPC("Dannig, Warrior Skald", "Logbook", null, "Sell")
        },
        {
            "Metadata/NPC/League/Expedition/GamblerHideout", new NPC("Gwennen, the Gambler", "Gamble", "Sell")
        },
        {
            "Metadata/NPC/League/Expedition/HagglerHideout", new NPC("Tujen, the Haggler", "Haggle", "Sell")
        },
        {
            "Metadata/NPC/Epilogue/LillyHideout", new NPC("Lilly Roth", "Sell", "Gems", "Cards")
        },
        {
            "Metadata/NPC/Epilogue/KiracHideout", new NPC("Commander Kirac", "Purchase", "Sell")
        },
        {
            "Metadata/NPC/League/Betrayal/BetrayalNinjaCopHideout", new NPC("Jun, Veiled Master", "Unveil", "Syndicate", "Sell")
        },
        {
            "Metadata/NPC/League/Incursion/TreasureHunterHideout", new NPC("Alva, Master Explorer", "Temple")
        },
        {
            "Metadata/NPC/League/Delve/DelveMinerHideout", new NPC("Niko, Master of the Depths", "Delve Chart")
        },
        {
            "Metadata/NPC/League/Bestiary/EinharHideout", new NPC("Einhar, Beastmaster", "Bestiary")
        },
        {
            "Metadata/NPC/League/Blight/BlightBuilderHideout", new NPC("Sister Cassia", "Anoint")
        },
        {
            "Metadata/NPC/Missions/Hideout/Helena", new NPC("Helena", "Change Hideout", null, "Sell")
        },
        // Kingsmarch
        {
            "Metadata/NPC/League/Kalguur/VillageTujen", new NPC("Tujen, the Harbourmaster", "Shipping", "Sell")
        },
        {
            "Metadata/NPC/League/Kalguur/VillageRog", new NPC("Rog, the Disenchanter", "Disenchant", "Sell")
        },
        {
            "Metadata/NPC/League/Kalguur/VillageRecruiter", new NPC("Raulf, the Recruiter", "Recruit Workers")
        },
        {
            "Metadata/NPC/League/Kalguur/VillageMayor", new NPC("Johan, the King's Hand", "Manage Town")
        },
        {
            "Metadata/NPC/League/Kalguur/VillageMayorHideout", new NPC("Johan, the King's Hand", "Manage Town")
        },
        {
            "Metadata/NPC/League/Kalguur/VillageIsla", new NPC("Isla, the Engineer", "Sell")
        },
        {
            "Metadata/NPC/League/Kalguur/VillageFaustus", new NPC("Faustus, the Financier", "Respecialise", "Black Market / Currency Exchange")
        },
        {
            "Metadata/NPC/League/Kalguur/VillageFaustusHideout", new NPC("Faustus, the Financier", "Respecialise", "Black Market / Currency Exchange")
        }
    };

    public static bool TryGetNPC(string path, [MaybeNullWhen(false)] out NPC npc) => NPCByPath.TryGetValue(path, out npc);
}
