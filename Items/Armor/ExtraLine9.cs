﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace tgmod.Items.Armor
{
    class ExtraLine9 : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Extra Fishing Line");
            Tooltip.SetDefault("x9");
        }

        public override void SetDefaults()
        {
            item.accessory = true;
            item.width = 30;
            item.height = 30;
            item.value = 90000;
            item.rare = 5;
        }

        public override bool CanEquipAccessory(Player player, int slot)
        {
            foreach (Item armorPiece in player.armor)
            {
                if (armorPiece.type == mod.ItemType("ExtraLine"))
                {
                    return false;
                }
                if (armorPiece.type == mod.ItemType("ExtraLine2"))
                {
                    return false;
                }
                if (armorPiece.type == mod.ItemType("ExtraLine4"))
                {
                    return false;
                }
                if (armorPiece.type == mod.ItemType("ExtraLine9"))
                {
                    return false;
                }
                if (armorPiece.type == mod.ItemType("ExtraLine19"))
                {
                    return false;
                }
            }
            return base.CanEquipAccessory(player, slot);
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            if (!ModLoader.GetLoadedMods().Contains("UnuBattleRods"))
            {
                player.GetModPlayer<tgplayer>().extraFishingLines += 9;
            }
            base.UpdateAccessory(player, hideVisual);
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(mod.ItemType("ExtraLine4"), 2);
            recipe.AddIngredient(mod.ItemType("ExtraLine"));
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(this, 1);
            recipe.AddRecipe();
        }
    }
}
