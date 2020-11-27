using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Graphics.Shaders;
using Terraria.ID;
using Terraria.ModLoader;

namespace ClickerAddon.NPCs
{
	public class ClickerAddonGlobalNPC : GlobalNPC
	{
		public override void NPCLoot(NPC npc)
		{
			if (npc.type == NPCID.Mothron && npc.value > 0f)
			{
				if (Main.rand.NextBool(4))
				{
					Item.NewItem(npc.Hitbox, mod.ItemType("BrockenHeroClicker"), 1, false, -1);
				}
			}
		}
	}
}