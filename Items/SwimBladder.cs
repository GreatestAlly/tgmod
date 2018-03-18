using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace tgmod.Items
{
    class SwimBladder : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Swim Bladder");
            Tooltip.SetDefault("Right click to open. ");
        }

        public override void SetDefaults()
        {
            item.consumable = true;
            item.rare = 2;
            item.maxStack = 999;
            item.width = 12;
            item.height = 12;
            item.stack = 1;
        }

        public override bool CanRightClick()
        {
            return true;
        }

        public override void RightClick(Player player)
        {
            int item;
            int stack;

            // a chance to get some like of max life item
            if (tgmod.instance.thoriumLoaded)
            {
                SpawnLifeQuartz(player);
            }
            else
            {
                if (Main.rand.Next(5) == 0)
                {
                    item = ItemID.LifeCrystal;
                    stack = 1;
                    player.QuickSpawnItem(item, stack);
                }
            }

            // Always get some bait
            item = ItemID.Worm;
            stack = 1;
            if (Main.rand.Next(3) == 0)
            {
                stack++;
            }
            player.QuickSpawnItem(item, stack);

            // Chance to get a hook
            if (Main.rand.Next(20) == 0)
            {
                item = ItemID.Hook;
                stack = 1;
                player.QuickSpawnItem(item, stack);
            }
        }

        private void SpawnLifeQuartz(Player player)
        {
            int stack = 0;
            while (Main.rand.Next(2) == 0)
            {
                stack++;
            }
            if (stack > 0)
            {
                int item = ModLoader.GetMod("ThoriumMod").ItemType("LifeQuartz");
                player.QuickSpawnItem(item, stack);
            }

        }
    }
}
