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
                if (type == TileID.Grass || type == TileID.JungleGrass || type == TileID.MushroomGrass || type == TileID.HallowedGrass ||
                    (type >= TileID.GreenMoss && type <= TileID.LongMoss))
                {
                    Player player = Main.LocalPlayer;
                    player.AddBuff(mod.BuffType<Buffs.ElvenBlessing>(), 5);
                }
            }
            base.NearbyEffects(i, j, type, closer);
        }
    }
}
