using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria.ID;
using Terraria.ModLoader;

namespace tgmod.Items.Placeable
{
    class LivingMahoganyLeafBlock : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Living Mahogany Leaf Block");
            Tooltip.SetDefault("Can be placed.");
        }

        public override void SetDefaults()
        {
            item.width = 12;
            item.height = 12;
            item.maxStack = 999;
            item.useTurn = true;
            item.autoReuse = true;
            item.useAnimation = 15;
            item.useTime = 10;
            item.useStyle = 1;
            item.consumable = true;
            item.createTile = TileID.LivingMahoganyLeaves;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.RichMahogany, 1);
            recipe.SetResult(this, 1);
            recipe.AddTile(TileID.LivingLoom);
            recipe.AddRecipe();
        }
    }
}
