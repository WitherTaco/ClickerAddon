using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using Terraria;
using Terraria.ModLoader;

namespace ClickerAddon
{
	public class WitherTacoLib
	{
		public static Color MiceColor = new Color(88, 92, 222);
		public static class ClickerAddon
		{
			internal static void SetRadiusInfo(Item item, float radius, Color color)
			{
				ClickerCompat.SetRadius(item, radius);
				ClickerCompat.SetColor(item, color);
			}
			internal static void SetClickerBaseStats(Player player, float damage, int crit = 0, int clicksForEffect = 0)
			{
				ClickerCompat.SetDamageAdd(player, damage);
				ClickerCompat.SetClickerCritAdd(player, crit);
				ClickerCompat.SetClickerBonusAdd(player, clicksForEffect);
			}
			internal static void SetClickerBaseStats(Player player, float damage, int crit = 0, float clicksForEffect = 0f)
			{
				ClickerCompat.SetDamageAdd(player, damage);
				ClickerCompat.SetClickerCritAdd(player, crit);
				ClickerCompat.SetClickerBonusPercentAdd(player, clicksForEffect);
			}
		}
		internal static bool IfMod(string bonusMod = "ClickerClass")
		{
			return ((ClickerCompat.ClickerClass != null) && (ModLoader.GetMod(bonusMod) != null));
		}
		public static class Math
		{
			internal static float Radius(float radius)
			{
				return (float)(radius * 2);
			}
		}
		public static void DrawNPCGlowMask(SpriteBatch spriteBatch, NPC npc, Texture2D texture)
		{
			var effects = npc.direction == -1 ? SpriteEffects.None : SpriteEffects.FlipHorizontally;
			spriteBatch.Draw(texture, npc.Center - Main.screenPosition + new Vector2(0, npc.gfxOffY), npc.frame,
							 Color.White, npc.rotation, npc.frame.Size() / 2, npc.scale, effects, 0);
		}
	}
}