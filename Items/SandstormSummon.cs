using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Localization;

namespace tgmod.Items
{
    class SandstormSummon : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Sandstorm Summon");
            Tooltip.SetDefault("Summons a sandstorm. Hopefully. ");
        }

        public override void SetDefaults()
        {
            item.useStyle = 4;
            item.useAnimation = 45;
            item.useTime = 45;
            item.rare = 5;
            item.maxStack = 99;
            item.width = 22;
            item.height = 14;
            item.consumable = true;
        }

        public override bool UseItem(Player player)
        {
            Terraria.GameContent.Events.Sandstorm.Happening = true;
            Terraria.GameContent.Events.Sandstorm.TimeLeft = (int)(3600.0 * (8.0 + (double)Main.rand.NextFloat() * 16.0));
            Terraria.GameContent.Events.Sandstorm.IntendedSeverity = !Terraria.GameContent.Events.Sandstorm.Happening ? (Main.rand.Next(3) != 0 ? Main.rand.NextFloat() * 0.3f : 0.0f) : 0.4f + Main.rand.NextFloat();
            if (Main.netMode == 1)
                return base.UseItem(player);
            NetMessage.SendData(7, -1, -1, (NetworkText)null, 0, 0.0f, 0.0f, 0.0f, 0, 0, 0);

            return base.UseItem(player);
        }

        public override void AddRecipes()
        {
            // recipe for debug purposes

            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.SandBlock, 20);
            recipe.AddTile(TileID.DemonAltar);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}
