using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace tgmod.NPCs
{
    class AnglerKill : GlobalNPC
    {
        public override void NPCLoot(NPC npc)
        {
            if (npc.type == NPCID.Angler && Main.hardMode)
            {
                Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("FishGrinder"));
            }
        }
    }
}
