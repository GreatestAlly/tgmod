using Terraria;
using Terraria.ObjectData;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;

namespace tgmod.Tiles
{
    class NeutralityTile : ModTile
    {
        public override void SetDefaults()
        {
            Main.tileFrameImportant[Type] = true;
            Main.tileObsidianKill[Type] = false;

            TileObjectData.newTile.CopyFrom(TileObjectData.Style2xX);
            TileObjectData.addTile(Type);
            ModTranslation name = CreateMapEntryName();
            name.SetDefault("Neutrality Statue");
            AddMapEntry(new Color(144, 148, 144), name);
            dustType = 11;
            disableSmartCursor = true;
        }

        public override void KillMultiTile(int i, int j, int frameX, int frameY)
        {
            Item.NewItem(i * 16, j * 16, 32, 48, mod.ItemType("NeutralityStatue"));
        }

        public override void NearbyEffects(int i, int j, bool closer)
        {
            Player player = Main.LocalPlayer;
            player.GetModPlayer<tgplayer>().inNeutralZone = true;
            player.AddBuff(mod.BuffType<Buffs.FactionNeutral>(), 10);
            base.NearbyEffects(i, j, closer);
        }
    }
}
