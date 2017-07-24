using Terraria.ModLoader;
using Terraria.ID;

namespace tgmod.Items.Placeable
{
    class NeutralityStatue : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Neutrality Statue");
            Tooltip.SetDefault("Creates a faction-free zone.");
        }

        public override void SetDefaults()
        {
            item.useStyle = 1;
            item.useAnimation = 15;
            item.useTime = 10;
            item.consumable = true;
            item.useTurn = true;
            item.autoReuse = true;
            item.rare = 4;
            item.value = 10000;
            item.createTile = mod.TileType<Tiles.NeutralityTile>();
            item.maxStack = 99;
            item.width = 18;
            item.height = 34;
            item.stack = 1;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.SunplateBlock, 50);
            recipe.AddIngredient(ItemID.Hellstone, 50);
            recipe.AddTile(TileID.SkyMill);
            recipe.AddTile(TileID.Hellforge);
            recipe.AddRecipe();
        }
    }
}
