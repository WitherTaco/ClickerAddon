using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ClickerAddon.Projectiles.Clickers
{
	public class ZClickerPro : ModProjectile
	{
		public override void SetStaticDefaults()
		{
			Main.projFrames[projectile.type] = 13;
			ClickerCompat.RegisterClickerProjectile(this);
		}
		
		public override void SetDefaults()
		{
			projectile.width = 18;
			projectile.height = 16;
			projectile.aiStyle = -1;
			projectile.penetrate = -1;
			projectile.timeLeft = 70;
			projectile.friendly = true;
			projectile.ignoreWater = true;
			projectile.tileCollide = false;
			projectile.alpha = 255;
			
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
		/*public override void PreAI()
		{
			projectile.frame = Main.rand.Next(1, 9);
			base.PostAI();
		}*/
		private int wiggleDirection = 0;
		private const float WiggleThreshold = MathHelper.Pi / 8;
		private const float WiggleSpeed = WiggleThreshold / 3;
		private bool ifSkin = true;

		public override void AI()
		{
			//projectile.frame = (int)(projectile.ai[0]);
			if (ifSkin)
			{
				projectile.frame = Main.rand.Next(1, Main.projFrames[projectile.type]);
				ifSkin = false;
			}
			if (projectile.timeLeft < 255 / 30f)
			{
				projectile.alpha += 30;
				if (projectile.alpha > 255)
				{
					projectile.alpha = 255;
				}
			}
			else
			{
				projectile.alpha -= 50;
				if (projectile.alpha < 0)
				{
					projectile.alpha = 0;
				}
			}

			if (wiggleDirection == 0)
			{
				//On spawn
				for (int i = 0; i < 3; i++)
				{
					Dust dust = Dust.NewDustDirect(projectile.position, projectile.width, projectile.height, ClickerCompat.ClickerClass.DustType("MiceDust"));
					dust.noGravity = true;
				}
				wiggleDirection = Main.rand.NextBool().ToDirectionInt();
			}

			if (wiggleDirection == 1 ? projectile.rotation < WiggleThreshold : projectile.rotation > -WiggleThreshold)
			{
				projectile.rotation += wiggleDirection * WiggleSpeed;
			}
			else
			{
				wiggleDirection *= -1;
			}
		}
		public override Color? GetAlpha(Color lightColor)
		{
			return Color.White * ((255 - projectile.alpha) / 255f);
		}
		/*public override void PostAI()
		{
			ifSkin = true;
			base.PostAI();
		}*/
	}
}