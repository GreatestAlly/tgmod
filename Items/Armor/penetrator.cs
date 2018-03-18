using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace tgmod.Items.Armor
{
    class penetrator : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("The Penetrator");
            Tooltip.SetDefault("Modeled after the party girl (male) :^)\n" + 
                "Increases armor penetration");
        }

        public override void SetDefaults()
        {
            item.accessory = true;
            item.width = 30;
            item.height = 30;
            item.value = 15000;
            item.rare = 3;
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.armorPenetration += 10;
        }
    }
}
