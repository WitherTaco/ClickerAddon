using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Utilities;

namespace ClickerAddon.Items
{
	public class ClickerAddonGlobalItem : GlobalItem
	{
		public override bool Shoot(Item item, Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
		{
			if(ClickerCompat.IsClickerWeapon(item))
			{
				Mod clickerClass = ModLoader.GetMod("ClickerClass");
				if(ClickerCompat.GetClickAmount(player) % 5 == 0 && player.GetModPlayer<ClickerAddonPlayer>().clickerCobaltSet)
				{
					Main.PlaySound(2, (int)Main.MouseWorld.X, (int)Main.MouseWorld.Y, 24);
					player.AddBuff(clickerClass.BuffType("Haste"), 300, false);
					for (int i = 0; i < 15; i++)
					{
						int num6 = Dust.NewDust(player.position, 20, 20, 56, 0f, 0f, 150, default(Color), 1.25f);
						Main.dust[num6].noGravity = true;
						Main.dust[num6].velocity *= 0.75f;
						int num7 = Main.rand.Next(-50, 51);
						int num8 = Main.rand.Next(-50, 51);
						Dust dust = Main.dust[num6];
						dust.position.X = dust.position.X + (float)num7;
						Dust dust2 = Main.dust[num6];
						dust2.position.Y = dust2.position.Y + (float)num8;
						Main.dust[num6].velocity.X = -(float)num7 * 0.075f;
						Main.dust[num6].velocity.Y = -(float)num8 * 0.075f;
					}
				}
				/*if((ClickerCompat.GetClickAmount(player) % ClickerCompat.GetClickerAmountTotal(player) == 0 || player.HasBuff(clickerClass.BuffType("OverclockBuff"))) && !player.HasBuff(clickerClass.BuffType("AutoClick")))
				{
					
				}*/
				return false;
			}
			return base.Shoot(item, player, ref position, ref speedX, ref speedY, ref type, ref damage, ref knockBack);
		}
	}
}