using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.IO;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ClickerAddon.Projectiles.Clickers.Fargo
{
	public class CultistFireball : ModProjectile
	{
		public override string Texture => "Terraria/Projectile_467";

		public override void SetStaticDefaults()
		{
			ClickerCompat.RegisterClickerProjectile(this);
			DisplayName.SetDefault("Fireball");
			Main.projFrames[projectile.type] = 4;
		}

		public override void SetDefaults()
		{
			projectile.width = 40;
			projectile.height = 40;
			projectile.aiStyle = -1;
			projectile.alpha = (int)byte.MaxValue;
			projectile.friendly = true;
			projectile.minion = true;
			projectile.ignoreWater = true;
			projectile.extraUpdates = 1;
			projectile.timeLeft = 360;
			projectile.penetrate = 1;
		}
		public override void AI()
		{
			if (projectile.ai[1] > -1.0 && projectile.ai[1] < 200.0)
			{
				NPC npc = Main.npc[(int)projectile.ai[1]];
				if (npc.CanBeChasedBy((object)projectile))
				{
					float rotation1 = projectile.velocity.ToRotation();
					Vector2 v = npc.Center - projectile.Center;
					if ((double)v.Length() < 20.0)
					{
						projectile.Kill();
						return;
					}
					float rotation2 = v.ToRotation();
					projectile.velocity = new Vector2(projectile.velocity.Length(), 0.0f).RotatedBy((double)rotation1.AngleLerp(rotation2, 0.008f));
				}
				else
				{
					projectile.ai[1] = -1f;
					projectile.netUpdate = true;
				}
			}
			projectile.alpha -= 40;
			if (projectile.alpha < 0)
				projectile.alpha = 0;
			++projectile.frameCounter;
			if (projectile.frameCounter > 2)
			{
				projectile.frameCounter = 0;
				++projectile.frame;
				if (projectile.frame > 3)
					projectile.frame = 0;
			}
			Lighting.AddLight(projectile.Center, 1.1f, 0.9f, 0.4f);
			projectile.rotation = projectile.velocity.ToRotation() + 1.570796f;
			++projectile.localAI[0];
			if (projectile.localAI[0] == 12.0)
			{
				projectile.localAI[0] = 0.0f;
				for (int index1 = 0; index1 < 12; ++index1)
				{
					Vector2 vector2 = (Vector2.UnitX * (float)-projectile.width / 2f + -Vector2.UnitY.RotatedBy((double)index1 * 3.14159274101257 / 6.0) * new Vector2(8f, 16f)).RotatedBy(projectile.rotation - 1.57079637050629);
					int index2 = Dust.NewDust(projectile.Center, 0, 0, 6, Alpha: 160);
					Main.dust[index2].scale = 1.1f;
					Main.dust[index2].noGravity = true;
					Main.dust[index2].position = projectile.Center + vector2;
					Main.dust[index2].velocity = projectile.velocity * 0.1f;
					Main.dust[index2].velocity = Vector2.Normalize(projectile.Center - projectile.velocity * 3f - Main.dust[index2].position) * 1.25f;
				}
			}
			if (Main.rand.Next(4) == 0)
			{
				for (int index1 = 0; index1 < 1; ++index1)
				{
					Vector2 vector2 = -Vector2.UnitX.RotatedByRandom(0.196349546313286).RotatedBy(projectile.velocity.ToRotation());
					int index2 = Dust.NewDust(projectile.position, projectile.width, projectile.height, 31, Alpha: 100);
					Main.dust[index2].velocity *= 0.1f;
					Main.dust[index2].position = projectile.Center + vector2 * projectile.width / 2f;
					Main.dust[index2].fadeIn = 0.9f;
				}
			}
			if (Main.rand.Next(32) == 0)
			{
				for (int index1 = 0; index1 < 1; ++index1)
				{
					Vector2 vector2 = -Vector2.UnitX.RotatedByRandom(0.392699092626572).RotatedBy(projectile.velocity.ToRotation());
					int index2 = Dust.NewDust(projectile.position, projectile.width, projectile.height, 31, Alpha: 155, Scale: 0.8f);
					Main.dust[index2].velocity *= 0.3f;
					Main.dust[index2].position = projectile.Center + vector2 * projectile.width / 2f;
					if (Main.rand.Next(2) == 0)
						Main.dust[index2].fadeIn = 1.4f;
				}
			}
			if (Main.rand.Next(2) != 0)
				return;
			for (int index1 = 0; index1 < 2; ++index1)
			{
				Vector2 vector2 = -Vector2.UnitX.RotatedByRandom(0.785398185253143).RotatedBy(projectile.velocity.ToRotation());
				int index2 = Dust.NewDust(projectile.position, projectile.width, projectile.height, 6, Scale: 1.2f);
				Main.dust[index2].velocity *= 0.3f;
				Main.dust[index2].noGravity = true;
				Main.dust[index2].position = projectile.Center + vector2 * projectile.width / 2f;
				if (Main.rand.Next(2) == 0)
					Main.dust[index2].fadeIn = 1.4f;
			}
		}
		public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
		{
			target.AddBuff(189, 240);
			if (projectile.penetrate != -1)
				return;
			target.immune[projectile.owner] = 0;
		}

		public override void Kill(int timeLeft)
		{
			if (projectile.localAI[1] != 0.0)
				return;
			projectile.localAI[1] = 1f;
			projectile.penetrate = -1;
			projectile.position = projectile.Center;
			Main.PlaySound(SoundID.Item14, projectile.position);
			projectile.width = projectile.height = 176;
			projectile.Center = projectile.position;
			projectile.Damage();
			for (int index1 = 0; index1 < 4; ++index1)
			{
				int index2 = Dust.NewDust(projectile.position, projectile.width, projectile.height, 31, Alpha: 100, Scale: 1.5f);
				Main.dust[index2].position = projectile.Center + Vector2.UnitY.RotatedByRandom(3.14159274101257) * (float)Main.rand.NextDouble() * projectile.width / 2f;
			}
			for (int index1 = 0; index1 < 30; ++index1)
			{
				int index2 = Dust.NewDust(projectile.position, projectile.width, projectile.height, 6, Alpha: 200, Scale: 3.7f);
				Main.dust[index2].position = projectile.Center + Vector2.UnitY.RotatedByRandom(3.14159274101257) * (float)Main.rand.NextDouble() * projectile.width / 2f;
				Main.dust[index2].noGravity = true;
				Main.dust[index2].velocity *= 3f;
				int index3 = Dust.NewDust(projectile.position, projectile.width, projectile.height, 6, Alpha: 100, Scale: 1.5f);
				Main.dust[index3].position = projectile.Center + Vector2.UnitY.RotatedByRandom(3.14159274101257) * (float)Main.rand.NextDouble() * projectile.width / 2f;
				Main.dust[index3].velocity *= 2f;
				Main.dust[index3].noGravity = true;
				Main.dust[index3].fadeIn = 2.5f;
			}
			for (int index1 = 0; index1 < 10; ++index1)
			{
				int index2 = Dust.NewDust(projectile.position, projectile.width, projectile.height, 6, Scale: 2.7f);
				Main.dust[index2].position = projectile.Center + Vector2.UnitX.RotatedByRandom(3.14159274101257).RotatedBy(projectile.velocity.ToRotation()) * projectile.width / 2f;
				Main.dust[index2].noGravity = true;
				Main.dust[index2].velocity *= 3f;
			}
			for (int index1 = 0; index1 < 10; ++index1)
			{
				int index2 = Dust.NewDust(projectile.position, projectile.width, projectile.height, 31, Scale: 1.5f);
				Main.dust[index2].position = projectile.Center + Vector2.UnitX.RotatedByRandom(3.14159274101257).RotatedBy(projectile.velocity.ToRotation()) * projectile.width / 2f;
				Main.dust[index2].noGravity = true;
				Main.dust[index2].velocity *= 3f;
			}
			for (int index1 = 0; index1 < 2; ++index1)
			{
				int index2 = Gore.NewGore(projectile.position + new Vector2((float)(projectile.width * Main.rand.Next(100)) / 100f, (float)(projectile.height * Main.rand.Next(100)) / 100f) - Vector2.One * 10f, new Vector2(), Main.rand.Next(61, 64));
				Main.gore[index2].position = projectile.Center + Vector2.UnitY.RotatedByRandom(3.14159274101257) * (float)Main.rand.NextDouble() * projectile.width / 2f;
				Main.gore[index2].velocity *= 0.3f;
				Main.gore[index2].velocity.X += (float)Main.rand.Next(-10, 11) * 0.05f;
				Main.gore[index2].velocity.Y += (float)Main.rand.Next(-10, 11) * 0.05f;
			}
		}

		public override Color? GetAlpha(Color lightColor) => new Color?(new Color((int)byte.MaxValue, 150, 150, (int)byte.MaxValue) * (float)(1.0 - (double)projectile.alpha / (double)byte.MaxValue));

		public override bool PreDraw(SpriteBatch spriteBatch, Color lightColor)
		{
			Texture2D texture = Main.projectileTexture[projectile.type];
			int height = Main.projectileTexture[projectile.type].Height / Main.projFrames[projectile.type];
			Rectangle r = new Rectangle(0, height * projectile.frame, texture.Width, height);
			Vector2 origin = r.Size() / 2f;
			Main.spriteBatch.Draw(texture, projectile.Center - Main.screenPosition + new Vector2(0.0f, projectile.gfxOffY), new Rectangle?(r), projectile.GetAlpha(lightColor), projectile.rotation, origin, projectile.scale, SpriteEffects.None, 0.0f);
			return false;
		}
	}
}