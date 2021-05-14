using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Graphics.Shaders;
using Terraria.ID;
using Terraria.ModLoader;

using ClickerAddon;
using ClickerAddon.Items.CrossContent.SoA.Other;

using SacredTools;

namespace ClickerAddon.Items.CrossContent.SoA
{
	public class ModSoAGlobalNPC : GlobalNPC
	{
		public override bool Autoload(ref string name)
		{
			return WitherTacoLib.IfMod("SacredTools");
		}
		public override void AI(NPC npc)
		{
			base.AI(npc);
		}
		public override void SetupShop(int type, Chest shop, ref int nextSlot)
		{
			if (type == ModLoader.GetMod("SacredTools").NPCType("Soraniti"))
			{
				shop.item[nextSlot].SetDefaults(ModLoader.GetMod("ClickerClass").ItemType("MiceFragment"));
				shop.item[nextSlot].shopCustomPrice = new int?(2);
				shop.item[nextSlot].shopSpecialCurrency = ClickerAddon.LunarCoinCloneID;
				nextSlot++;

				if (ModdedWorld.TRUEdownedAbaddon && ModdedWorld.TRUEdownedAraghur && ModdedWorld.TRUEdownedLunarians)
				{
					shop.item[nextSlot].SetDefaults(ModContent.ItemType<LuxShardClicker>());
					shop.item[nextSlot].shopCustomPrice = new int?(110);
					shop.item[nextSlot].shopSpecialCurrency = ClickerAddon.LunarCoinCloneID;
					nextSlot++;
				}
			}
		}
	}
}