using Terraria.ModLoader;
using Terraria.ID;

namespace tgmod.Items.Placeable
{
    class FishGrinder : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Fish Grinder");
            Tooltip.SetDefault("Where do you think the angler gets all those items from?");
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
            item.createTile = mod.TileType<Tiles.FishGrinderTile>();
            item.maxStack = 99;
            item.width = 18;
            item.height = 34;
            item.stack = 1;
        }
    }
}
