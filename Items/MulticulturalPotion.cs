using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace tgmod.Items
{
    class MulticulturalPotion : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Potion of MultiCulturalism");
            Tooltip.SetDefault("Multiculturalism makes (((us))) all stronger :^)");
        }

        public override void SetDefaults()
        {
            item.value = 10000;
            item.useStyle = 2;
            item.useAnimation = 17;
            item.useTime = 17;
            item.consumable = true;
            item.useTurn = true;
            item.rare = 4;
            item.expert = true;
            item.width = 14;
            item.height = 24;
            item.UseSound = SoundID.Item3;
            item.buffType = mod.BuffType("Multiculturalism");
            item.buffTime = 5 * 3600;
            item.stack = 1;
            item.maxStack = 1488;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.BottledWater, 1);
            recipe.AddIngredient(ItemID.Daybloom, 1);
            recipe.AddIngredient(ItemID.Fireblossom, 1);
            recipe.AddIngredient(ItemID.Damselfish);
            recipe.AddIngredient(ItemID.ArmoredCavefish);
            recipe.AddTile(TileID.Bottles);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}
