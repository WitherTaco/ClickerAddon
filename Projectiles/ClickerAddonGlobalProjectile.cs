using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ClickerAddon.Projectiles
{
	public class ClickerAddonGlobalProjectile : GlobalProjectile
	{
		public override void ModifyHitNPC(Projectile projectile, NPC target, ref int damage, ref float knockback, ref bool crit, ref int hitDirection)
		{
			Player player = Main.LocalPlayer;
			if(ClickerCompat.IsClickerProj(projectile))
			{
				if(player.GetModPlayer<ClickerAddonPlayer>().magmaChair)
				{
					for (int u = 0; u < Main.maxNPCs; u++)
					{
						/*NPC target = Main.npc[u];*/
						if (target.CanBeChasedBy(projectile) && target.DistanceSQ(projectile.Center) < 100 * 10)
						{
							target.AddBuff(BuffID.OnFire, 120, false);
						}
					}
				}
			}
		}
	}
}