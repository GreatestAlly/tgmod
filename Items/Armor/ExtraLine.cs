using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace tgmod.Items.Armor
{
    class ExtraLine : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Extra Fishing Line");
            Tooltip.SetDefault("x1");
        }

        public override void SetDefaults()
        {
            item.accessory = true;
            item.width = 30;
            item.height = 30;
            item.value = 10000;
            item.rare = 2;
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
                player.GetModPlayer<tgplayer>().extraFishingLines += 1;
            }
            base.UpdateAccessory(player, hideVisual);
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.WhiteString);
            recipe.AddIngredient(ItemID.Hook);
            recipe.AddTile(TileID.WorkBenches);
            recipe.SetResult(this, 1);
            recipe.AddRecipe();
            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.YellowString);
            recipe.AddIngredient(ItemID.Hook);
            recipe.AddTile(TileID.WorkBenches);
            recipe.SetResult(this, 1);
            recipe.AddRecipe();
            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.BlackString);
            recipe.AddIngredient(ItemID.Hook);
            recipe.AddTile(TileID.WorkBenches);
            recipe.SetResult(this, 1);
            recipe.AddRecipe();
            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.BlueString);
            recipe.AddIngredient(ItemID.Hook);
            recipe.AddTile(TileID.WorkBenches);
            recipe.SetResult(this, 1);
            recipe.AddRecipe();
            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.BrownString);
            recipe.AddIngredient(ItemID.Hook);
            recipe.AddTile(TileID.WorkBenches);
            recipe.SetResult(this, 1);
            recipe.AddRecipe();
            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.CyanString);
            recipe.AddIngredient(ItemID.Hook);
            recipe.AddTile(TileID.WorkBenches);
            recipe.SetResult(this, 1);
            recipe.AddRecipe();
            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.GreenString);
            recipe.AddIngredient(ItemID.Hook);
            recipe.AddTile(TileID.WorkBenches);
            recipe.SetResult(this, 1);
            recipe.AddRecipe();
            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.LimeString);
            recipe.AddIngredient(ItemID.Hook);
            recipe.AddTile(TileID.WorkBenches);
            recipe.SetResult(this, 1);
            recipe.AddRecipe();
            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.OrangeString);
            recipe.AddIngredient(ItemID.Hook);
            recipe.AddTile(TileID.WorkBenches);
            recipe.SetResult(this, 1);
            recipe.AddRecipe();
            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.PinkString);
            recipe.AddIngredient(ItemID.Hook);
            recipe.AddTile(TileID.WorkBenches);
            recipe.SetResult(this, 1);
            recipe.AddRecipe();
            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.PurpleString);
            recipe.AddIngredient(ItemID.Hook);
            recipe.AddTile(TileID.WorkBenches);
            recipe.SetResult(this, 1);
            recipe.AddRecipe();
            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.RainbowString);
            recipe.AddIngredient(ItemID.Hook);
            recipe.AddTile(TileID.WorkBenches);
            recipe.SetResult(this, 1);
            recipe.AddRecipe();
            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.RedString);
            recipe.AddIngredient(ItemID.Hook);
            recipe.AddTile(TileID.WorkBenches);
            recipe.SetResult(this, 1);
            recipe.AddRecipe();
            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.SkyBlueString);
            recipe.AddIngredient(ItemID.Hook);
            recipe.AddTile(TileID.WorkBenches);
            recipe.SetResult(this, 1);
            recipe.AddRecipe();
            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.TealString);
            recipe.AddIngredient(ItemID.Hook);
            recipe.AddTile(TileID.WorkBenches);
            recipe.SetResult(this, 1);
            recipe.AddRecipe();
            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.VioletString);
            recipe.AddIngredient(ItemID.Hook);
            recipe.AddTile(TileID.WorkBenches);
            recipe.SetResult(this, 1);
            recipe.AddRecipe();
        }
    }
}
