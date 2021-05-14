using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ClickerAddon.Projectiles.Clickers
{
	public class ClickDiamond : ModProjectile
	{
		public override void SetStaticDefaults()
		{
			ClickerCompat.RegisterClickerProjectile(this);
		}
		
		public override void SetDefaults()
		{
			projectile.width = 18;
			projectile.height = 16;
			projectile.aiStyle = -1;
			projectile.penetrate = -1;
			projectile.timeLeft = 60;
			projectile.friendly = true;
			projectile.tileCollide = false;
			//Main.projFrames[projectile.type] = 7;
			
			projectile.usesLocalNPCImmunity = true;
			projectile.localNPCHitCooldown = 20;
		}

		/*public override Color? GetAlpha(Color lightColor)
		{
			return new Color(255, 255, 255, 0) * (0.08f * projectile.timeLeft);
		}
		
		public override void ModifyHitNPC(NPC target, ref int damage, ref float knockback, ref bool crit, ref int hitDirection)
		{
			Player player = Main.player[projectile.owner];
			damage = (int)(damage + (target.defense / 2));
			damage = (int)(damage * 2.5f);
			hitDirection = target.Center.X < player.Center.X ? -1 : 1;
			crit = true;
		}

		public override void PostAI()
		{
			projectile.frameCounter++;
			if (projectile.frameCounter > 3)
			{
				projectile.frame++;
				projectile.frameCounter = 0;
			}
			if (projectile.frame >= 12)
			{
				projectile.Kill();
				return;
			}
		}*/

		public override void AI()
		{
			//projectile.frame = (int)(projectile.ai[0]);
			projectile.velocity *= 0.9f;
			projectile.rotation += projectile.velocity.X > 0f ? 0.08f : 0.08f;
			if (projectile.timeLeft < 20)
			{
				projectile.alpha += 8;
			}
			for (int u = 0; u < Main.maxNPCs; u++)
			{
				NPC target = Main.npc[u];
				if (target.CanBeChasedBy(projectile) && target.DistanceSQ(projectile.Center) < 100 * 10)
				{
					target.AddBuff(BuffID.Midas, 120, false);
				}
			}
		}
	}
}