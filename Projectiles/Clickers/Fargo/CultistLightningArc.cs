using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Utilities;

namespace ClickerAddon.Projectiles.Clickers.Fargo
{
	public class CultistLightningArc : ModProjectile
	{
		private float colorlerp;
		private bool playedsound;

		public override string Texture => "Terraria/Projectile_466";

		public override void SetStaticDefaults()
		{
			ClickerCompat.RegisterClickerProjectile(this);
			DisplayName.SetDefault("Lightning Arc");
			ProjectileID.Sets.TrailCacheLength[projectile.type] = 10;
			ProjectileID.Sets.TrailingMode[projectile.type] = 1;
		}

		public override void SetDefaults()
		{
			projectile.width = 20;
			projectile.height = 20;
			projectile.scale = 0.5f;
			projectile.aiStyle = -1;
			projectile.friendly = true;
			projectile.ranged = true;
			projectile.alpha = 100;
			projectile.ignoreWater = true;
			projectile.tileCollide = true;
			projectile.extraUpdates = 3;
			projectile.timeLeft = 120 * (projectile.extraUpdates + 1);
			projectile.penetrate = -1;
			projectile.usesIDStaticNPCImmunity = true;
			projectile.idStaticNPCHitCooldown = 10;
		}
		public override void AI()
		{
			++projectile.frameCounter;
			Lighting.AddLight(projectile.Center, 0.3f, 0.45f, 0.5f);
			this.colorlerp += 0.05f;
			if (!this.playedsound)
			{
				Main.PlaySound(2, (int)projectile.Center.X, (int)projectile.Center.Y, 122, 0.5f, -0.5f);
				this.playedsound = true;
			}
			if (projectile.velocity == Vector2.Zero)
			{
				if (projectile.frameCounter >= projectile.extraUpdates * 2)
				{
					projectile.frameCounter = 0;
					bool flag = true;
					for (int index = 1; index < projectile.oldPos.Length; ++index)
					{
						if (projectile.oldPos[index] != projectile.oldPos[0])
							flag = false;
					}
					if (flag)
					{
						projectile.Kill();
						return;
					}
				}
				if (Main.rand.Next(projectile.extraUpdates) != 0)
					return;
				for (int index1 = 0; index1 < 2; ++index1)
				{
					float num1 = projectile.rotation + (float)((Main.rand.Next(2) == 1 ? -1.0 : 1.0) * 1.57079637050629);
					float num2 = (float)(Main.rand.NextDouble() * 0.800000011920929 + 1.0);
					Vector2 vector2 = new Vector2((float)Math.Cos((double)num1) * num2, (float)Math.Sin((double)num1) * num2);
					int index2 = Dust.NewDust(projectile.Center, 0, 0, 226, vector2.X, vector2.Y);
					Main.dust[index2].noGravity = true;
					Main.dust[index2].scale = 1.2f;
				}
				if (Main.rand.Next(5) != 0)
					return;
				int index3 = Dust.NewDust(projectile.Center + projectile.velocity.RotatedBy(1.57079637050629) * ((float)Main.rand.NextDouble() - 0.5f) * (float)projectile.width - Vector2.One * 4f, 8, 8, 31, Alpha: 100, Scale: 1.5f);
				Main.dust[index3].velocity *= 0.5f;
				Main.dust[index3].velocity.Y = -Math.Abs(Main.dust[index3].velocity.Y);
			}
			else
			{
				if (projectile.frameCounter < projectile.extraUpdates * 2)
					return;
				projectile.frameCounter = 0;
				float num1 = projectile.velocity.Length();
				UnifiedRandom unifiedRandom = new UnifiedRandom((int)projectile.ai[1]);
				int num2 = 0;
				Vector2 spinningpoint = -Vector2.UnitY;
				Vector2 rotationVector2;
				do
				{
					int num3 = unifiedRandom.Next();
					projectile.ai[1] = (float)num3;
					rotationVector2 = ((float)((double)(num3 % 100) / 100.0 * 6.28318548202515)).ToRotationVector2();
					if ((double)rotationVector2.Y > 0.0)
						--rotationVector2.Y;
					bool flag = false;
					if ((double)rotationVector2.Y > -0.0199999995529652)
						flag = true;
					if ((double)rotationVector2.X * (double)(projectile.extraUpdates + 1) * 2.0 * (double)num1 + (double)projectile.localAI[0] > 40.0)
						flag = true;
					if ((double)rotationVector2.X * (double)(projectile.extraUpdates + 1) * 2.0 * (double)num1 + (double)projectile.localAI[0] < -40.0)
						flag = true;
					if (!flag)
						goto label_32;
				}
				while (num2++ < 100);
				projectile.velocity = Vector2.Zero;
				projectile.localAI[1] = 1f;
				goto label_33;
			label_32:
				spinningpoint = rotationVector2;
			label_33:
				if (projectile.velocity == Vector2.Zero || (double)projectile.velocity.Length() < 4.0)
				{
					projectile.velocity = Vector2.UnitX.RotatedBy((double)projectile.ai[0]).RotatedByRandom(Math.PI / 4.0) * 7f;
					projectile.ai[1] = (float)Main.rand.Next(100);
				}
				else
				{
					projectile.localAI[0] += (float)((double)spinningpoint.X * (double)(projectile.extraUpdates + 1) * 2.0) * num1;
					projectile.velocity = spinningpoint.RotatedBy((double)projectile.ai[0] + 1.57079637050629) * num1;
					projectile.rotation = projectile.velocity.ToRotation() + 1.570796f;
				}
			}
		}

		public override bool? Colliding(Rectangle projHitbox, Rectangle targetHitbox)
		{
			for (int index = 0; index < projectile.oldPos.Length && ((double)projectile.oldPos[index].X != 0.0 || (double)projectile.oldPos[index].Y != 0.0); ++index)
			{
				Rectangle rectangle = projHitbox;
				rectangle.X = (int)projectile.oldPos[index].X;
				rectangle.Y = (int)projectile.oldPos[index].Y;
				if (rectangle.Intersects(targetHitbox))
					return new bool?(true);
			}
			return new bool?(false);
		}

		public override void Kill(int timeLeft)
		{
			float num1 = (float)((double)projectile.rotation + 1.57079637050629 + (Main.rand.Next(2) == 1 ? -1.0 : 1.0) * 1.57079637050629);
			float num2 = (float)(Main.rand.NextDouble() * 2.0 + 2.0);
			Vector2 vector2 = new Vector2((float)Math.Cos((double)num1) * num2, (float)Math.Sin((double)num1) * num2);
			for (int index1 = 0; index1 < projectile.oldPos.Length; ++index1)
			{
				int index2 = Dust.NewDust(projectile.oldPos[index1], 0, 0, 229, vector2.X, vector2.Y);
				Main.dust[index2].noGravity = true;
				Main.dust[index2].scale = 1.7f;
			}
		}

		public override void OnHitNPC(NPC target, int damage, float knockback, bool crit) => target.AddBuff(144, 180);

		public override Color? GetAlpha(Color lightColor) => new Color?(Color.Lerp(Color.LightSkyBlue, Color.White, (float)(0.5 + Math.Sin((double)this.colorlerp) / 2.0)) * 0.5f);

		public override bool PreDraw(SpriteBatch spriteBatch, Color lightColor)
		{
			Texture2D texture = Main.projectileTexture[projectile.type];
			Rectangle bounds = texture.Bounds;
			Vector2 origin = bounds.Size() / 2f;
			Color alpha = projectile.GetAlpha(lightColor);
			for (int index1 = 1; index1 < ProjectileID.Sets.TrailCacheLength[projectile.type]; ++index1)
			{
				if (!(projectile.oldPos[index1] == Vector2.Zero) && !(projectile.oldPos[index1 - 1] == projectile.oldPos[index1]))
				{
					Vector2 vector2_1 = projectile.oldPos[index1 - 1] - projectile.oldPos[index1];
					int num = (int)vector2_1.Length();
					float scale = projectile.scale * (float)Math.Sin((double)index1 / 3.14159274101257);
					vector2_1.Normalize();
					for (int index2 = 0; index2 < num; index2 += 3)
					{
						Vector2 vector2_2 = projectile.oldPos[index1] + vector2_1 * (float)index2;
						Main.spriteBatch.Draw(texture, vector2_2 + projectile.Size / 2f - Main.screenPosition + new Vector2(0.0f, projectile.gfxOffY), new Rectangle?(bounds), alpha, projectile.rotation, origin, scale, SpriteEffects.FlipHorizontally, 0.0f);
					}
				}
			}
			return false;
		}

		public override bool OnTileCollide(Vector2 oldVelocity)
		{
			projectile.velocity = Vector2.Zero;
			return false;
		}
	}
}