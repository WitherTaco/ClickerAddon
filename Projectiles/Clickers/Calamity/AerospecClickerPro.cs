using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ClickerAddon.Projectiles.Clickers.Calamity
{
	public class AerospecClickerPro : ModProjectile
	{
		public override void SetStaticDefaults()
		{
			ClickerCompat.RegisterClickerProjectile(this);
		}
		
		public override void SetDefaults()
		{
			projectile.width = 44;
			projectile.height = projectile.width;
			projectile.penetrate = -1;
			projectile.timeLeft = 10;
			projectile.alpha = 255;
			projectile.extraUpdates = 3;
			projectile.friendly = true;
			projectile.aiStyle = -1;

			projectile.extraUpdates = 2;
			projectile.usesLocalNPCImmunity = true;
			projectile.localNPCHitCooldown = 60;
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
			if (projectile.ai[0] < 1f)
			{
				for (int k = 0; k < 100; k++)
				{
					Dust dust = Dust.NewDustDirect(projectile.position, projectile.width / 11 * 3, projectile.height / 11 * 3, 66, Main.rand.NextFloat(-10f, 10f), Main.rand.NextFloat(-10f, 10f), 125, default, 1.25f);
					dust.noGravity = true;
				}
				projectile.ai[0] += 1f;
			}
		}
	}
}