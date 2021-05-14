using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Graphics.Shaders;
using Terraria.ID;
using Terraria.ModLoader;

using ClickerAddon.Items.Accessories;

namespace ClickerAddon.NPCs
{
	public class ClickerAddonGlobalNPC : GlobalNPC
	{
		public int ChanceMasoMode()
		{
			if ((bool)ModLoader.GetMod("FargowiltasSouls")?.Call("Masomode"))
				return 3;
			else
				return 10;
		}
		public override void NPCLoot(NPC npc)
		{
			Mod clickerClass = ModLoader.GetMod("ClickerClass");
			
			if(npc.type == NPCID.Mothron && npc.value > 0f)
			{
				if(Main.rand.NextBool(4))
				{
					Item.NewItem(npc.Hitbox, mod.ItemType("BrockenHeroClicker"), 1, false, -1);
				}
			}
			if(npc.type == NPCID.RainbowSlime && npc.value > 0f)
			{
				Item.NewItem(npc.Hitbox, mod.ItemType("RainbowGel"), Main.rand.Next(5, 15), false, -1);
			}
			if (npc.type == NPCID.Shark && npc.value > 0f && Main.hardMode)
			{
				if (Main.rand.NextBool(20))
				{
					Item.NewItem(npc.Hitbox, clickerClass.ItemType("PortableParticleAccelerator"), 1, false, -1);
				}
			}
			if (npc.type == NPCID.EyeofCthulhu)
			{
				if(Main.rand.NextBool(20))
				{
					Item.NewItem(npc.Hitbox, mod.ItemType("SteveHead"), 1, false, -1);
				}
			}
			if (npc.type == NPCID.Eyezor)
			{
				if (Main.rand.NextBool(10))
				{
					Item.NewItem(npc.Hitbox, mod.ItemType("TheDice"), 1, false, -1);
				}
			}
			if(!Main.expertMode)
			{
				if(npc.type == NPCID.DD2Betsy && npc.value > 0f)
				{
					if(Main.rand.NextBool(4))
					{
						Item.NewItem(npc.Hitbox, mod.ItemType("OldOneClicker"), 1, false, -1);
					}
				}
				if (npc.type == NPCID.DukeFishron && npc.value > 0f)
				{
					if (Main.rand.NextBool(4))
					{
						Item.NewItem(npc.Hitbox, mod.ItemType("FishronsClicker"), 1, false, -1);
					}
				}
				if(npc.type == NPCID.QueenBee && npc.value > 0f)
				{
					if (Main.rand.NextBool(3))
					{
						Item.NewItem(npc.Hitbox, mod.ItemType("BeeClicker"), 1, false, -1);
					}
				}
			}
			Mod redemption = ModLoader.GetMod("Redemption");
			if (redemption != null)
			{
				if(npc.type == redemption.NPCType("Thorn"))
				{
					if(Main.rand.NextBool(4))
					{
						Item.NewItem(npc.Hitbox, mod.ItemType("CursedRootClicker"), 1, false, -1);
					}
				}
			}
			Mod fargo = ModLoader.GetMod("FargowiltasSouls");
			if (fargo != null)
			{
				if (npc.type == NPCID.CultistBoss)
				{
					if ((bool)fargo?.Call("Masomode"))
					{
						if (Main.rand.NextBool(3))
						{
							Item.NewItem(npc.Hitbox, mod.ItemType("ClickerOfCult"), 1, false, -1);
						}
					}
					else
					{
						if (Main.rand.NextBool(10))
						{
							Item.NewItem(npc.Hitbox, mod.ItemType("ClickerOfCult"), 1, false, -1);
						}
					}
				}
			}
		}
		public override void SetupShop(int type, Chest shop, ref int nextSlot)
		{
			if(type == NPCID.Clothier)
			{
				shop.item[nextSlot++].SetDefaults(ModContent.ItemType<BandOfClicking>());
			}
		}
	}
}