using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace tgmod.Items.Placeable
{
    class LivingLeafBlock : ModItem
    {
        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("Can be placed.");
            DisplayName.SetDefault("Living Leaf Block");
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
            item.createTile = TileID.LeafBlock;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.Wood, 1);
            recipe.SetResult(this, 1);
            recipe.AddTile(TileID.LivingLoom);
            recipe.AddRecipe();
        }
    }
}
