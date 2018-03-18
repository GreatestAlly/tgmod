using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using System;

namespace tgmod.NPCs
{
    class SoldSummonItems : GlobalNPC
    {
        public override void SetupShop(int type, Chest shop, ref int nextSlot)
        {
            if (!Config.sellSummons)
            {
                return;
            }
            if (type == NPCID.Dryad)
            {
                if (NPC.downedSlimeKing)
                {
                    shop.item[nextSlot].SetDefaults(ItemID.SlimeCrown);
                    shop.item[nextSlot].shopCustomPrice = new int?(10000);
                    nextSlot++;
                }
                if (NPC.downedBoss1) // Eye of Cthulu
                {
                    shop.item[nextSlot].SetDefaults(ItemID.SuspiciousLookingEye);
                    shop.item[nextSlot].shopCustomPrice = new int?(30000);
                    nextSlot++;
                }
                if (NPC.downedBoss2) // Eater of Worlds or Brain of Cthulu
                {
                    shop.item[nextSlot].SetDefaults(ItemID.WormFood);
                    shop.item[nextSlot].shopCustomPrice = new int?(10000);
                    nextSlot++;
                    shop.item[nextSlot].SetDefaults(ItemID.BloodySpine);
                    shop.item[nextSlot].shopCustomPrice = new int?(10000);
                    nextSlot++;
                }
                if (NPC.downedQueenBee)
                {
                    shop.item[nextSlot].SetDefaults(ItemID.Abeemination);
                    shop.item[nextSlot].shopCustomPrice = new int?(100000);
                    nextSlot++;
                }
                if (NPC.downedBoss3) // Skeletron
                {
                    shop.item[nextSlot].SetDefaults(ItemID.ClothierVoodooDoll);
                    shop.item[nextSlot].shopCustomPrice = new int?(50000);
                    nextSlot++;
                }
                if (Main.hardMode)
                {
                    shop.item[nextSlot].SetDefaults(ItemID.GuideVoodooDoll);
                    shop.item[nextSlot].shopCustomPrice = new int?(80000);
                    nextSlot++;
                }
            }

            if (type == NPCID.Wizard)
            {
                if (NPC.downedMechBoss1)
                {
                    shop.item[nextSlot].SetDefaults(ItemID.MechanicalWorm);
                    shop.item[nextSlot].shopCustomPrice = new int?(120000);
                    nextSlot++;
                }
                if (NPC.downedMechBoss2)
                {
                    shop.item[nextSlot].SetDefaults(ItemID.MechanicalEye);
                    shop.item[nextSlot].shopCustomPrice = new int?(120000);
                    nextSlot++;
                }
                if (NPC.downedMechBoss3)
                {
                    shop.item[nextSlot].SetDefaults(ItemID.MechanicalSkull);
                    shop.item[nextSlot].shopCustomPrice = new int?(120000);
                    nextSlot++;
                }
                if (NPC.downedHalloweenKing)
                {
                    shop.item[nextSlot].SetDefaults(ItemID.PumpkinMoonMedallion);
                    shop.item[nextSlot].shopCustomPrice = new int?(150000);
                    nextSlot++;
                }
                if (NPC.downedChristmasIceQueen)
                {
                    shop.item[nextSlot].SetDefaults(ItemID.NaughtyPresent);
                    shop.item[nextSlot].shopCustomPrice = new int?(200000);
                }
            }
            if (type == NPCID.Truffle)
            {
                if (NPC.downedFishron)
                {
                    shop.item[nextSlot].SetDefaults(ItemID.TruffleWorm);
                    shop.item[nextSlot].shopCustomPrice = new int?(20000);
                    nextSlot++;
                }
            }
            if (type == NPCID.GoblinTinkerer)
            {
                shop.item[nextSlot].SetDefaults(ItemID.GoblinBattleStandard);
                shop.item[nextSlot].shopCustomPrice = new int?(5000);
                nextSlot++;
            }
            if (type == NPCID.Pirate)
            {
                shop.item[nextSlot].SetDefaults(ItemID.PirateMap);
                shop.item[nextSlot].shopCustomPrice = new int?(50000);
                nextSlot++;
            }
            if (type == NPCID.Cyborg)
            {
                if (NPC.downedGolemBoss)
                {
                    shop.item[nextSlot].SetDefaults(ItemID.LihzahrdPowerCell);
                    shop.item[nextSlot].shopCustomPrice = new int?(120000);
                    nextSlot++;
                }
                if (NPC.downedMoonlord)
                {
                    shop.item[nextSlot].SetDefaults(ItemID.CelestialSigil);
                    shop.item[nextSlot].shopCustomPrice = new int?(200000);
                    nextSlot++;
                }
            }
        }
    }
}
