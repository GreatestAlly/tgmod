using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace tgmod.NPCs
{
    class goblinTinkerer : GlobalNPC
    {
        public override void SetDefaults(NPC npc)
        {
            if (npc.type == NPCID.GoblinTinkerer)
            {
                if (!npc.GivenName.EndsWith(")))"))
                {
                    npc.GivenName = "(((" + npc.GivenName + ")))";
                }
            }
        }

        public override bool PreAI(NPC npc)
        {
            if (npc.type == NPCID.GoblinTinkerer)
            {
                if (!npc.GivenName.EndsWith(")))"))
                {
                    npc.GivenName = "(((" + npc.GivenName + ")))";
                }
            }
            return base.PreAI(npc);
        }
    }
}
