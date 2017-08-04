using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace tgmod.Tiles
{
    class ElfFactionHelper : GlobalTile
    {
        public override void NearbyEffects(int i, int j, int type, bool closer)
        {
            if (closer)
            {
                Player player = Main.LocalPlayer;
                if (player.GetModPlayer<tgplayer>().playerFaction == FactionID.elf)
                {
                    if (type == TileID.Grass || type == TileID.JungleGrass || type == TileID.MushroomGrass || type == TileID.HallowedGrass ||
                        (type >= TileID.GreenMoss && type <= TileID.LongMoss))
                    {
                        player.GetModPlayer<tgplayer>().elvenBlessing = true;
                        player.AddBuff(mod.BuffType<Buffs.ElvenBlessing>(), 30);
                    }
                }
            }
            base.NearbyEffects(i, j, type, closer);
        }
    }
}
