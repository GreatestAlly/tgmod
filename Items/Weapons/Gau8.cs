using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace tgmod.Items.Weapons
{
    class Gau8 : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Gau-8");
            Tooltip.SetDefault("BRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRT");
        }

        public override void SetDefaults()
        {
            item.damage = 2;
            item.ranged = true;
            item.width = 50;
            item.height = 20;
            item.useTime = 5;
            item.useAnimation = 5;
            item.useStyle = 5;
            item.noMelee = true;
            item.knockBack = 1f;
            item.value = Item.sellPrice(0, 0, 56, 0);
            item.rare = 3;
            item.UseSound = SoundID.Item5;
            item.autoReuse = true;
            item.shoot = 1;
            item.shootSpeed = 8;
            item.useAmmo = AmmoID.Bullet;
        }

        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
            float playerMass = 1f;
            float bulletMass = 0.3f;
            Vector2 speed = new Vector2(speedX, speedY);
            player.velocity = player.velocity - speed * bulletMass / playerMass;
            speed.Normalize();
            position = position + speed * item.width;
            return true;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.IronBar, 20);
            recipe.AddIngredient(ItemID.WaterBucket, 2);
            recipe.AddIngredient(ItemID.PartyBullet, 999);
            recipe.AddTile(TileID.Hellforge);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}
