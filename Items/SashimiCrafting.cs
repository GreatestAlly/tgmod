using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace tgmod.Items
{
    class SashimiCrafting : GlobalItem
    {
        public override void OnCraft(Item item, Recipe recipe)
        {
            if (item.type == ItemID.Sashimi)
            {
                // roll for chance get a swim bladder
                if (Main.rand.Next(10) == 0)
                {
                    Main.player[Main.myPlayer].QuickSpawnItem(mod.ItemType<SwimBladder>());
                }
            }
        }
    }
}
