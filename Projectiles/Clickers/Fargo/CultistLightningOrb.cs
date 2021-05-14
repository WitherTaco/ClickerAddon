using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using Terraria;
using Terraria.ModLoader;

namespace ClickerAddon.Projectiles.Clickers.Fargo
{
	public class CultistLightningOrb : ModProjectile
	{
		public override string Texture => "Terraria/Projectile_465";

		public override void SetStaticDefaults()
		{
			ClickerCompat.RegisterClickerProjectile(this);
			DisplayName.SetDefault("Lightning Orb");
			Main.projFrames[projectile.type] = 4;
		}

		public override void SetDefaults()
		{
			projectile.width = 80;
			projectile.height = 80;
			projectile.aiStyle = -1;
			projectile.alpha = (int)byte.MaxValue;
			projectile.friendly = true;
			projectile.minion = true;
			projectile.ignoreWater = true;
			projectile.tileCollide = false;
			projectile.timeLeft = 240;
			projectile.penetrate = -1;
			projectile.usesLocalNPCImmunity = true;
			projectile.localNPCHitCooldown = 10;
		}
		public Projectile get_projectile()
		{
			return projectile;
		}
		public override void AI()
		{
			projectile.alpha += projectile.timeLeft > 51 ? -10 : 10;
			if (projectile.alpha < 0)
				projectile.alpha = 0;
			if (projectile.alpha > (int)byte.MaxValue)
				projectile.alpha = (int)byte.MaxValue;
			if (projectile.timeLeft % 30 == 0)
			{
				int num1 = -1;
				if ((double)projectile.ai[0] > -1.0 && (double)projectile.ai[0] < 1000.0)
				{
					int index1 = (int)projectile.ai[0];
					if ((double)Main.projectile[index1].ai[0] > -1.0 && (double)Main.projectile[index1].ai[0] < 200.0)
					{
						int index2 = (int)Main.projectile[index1].ai[0];
						num1 = index2;
						if (Main.npc[index2].CanBeChasedBy((object)projectile))
						{
							Vector2 vector2_1 = Main.npc[index2].Center - projectile.Center;
							float num2 = (float)Main.rand.Next(100);
							Vector2 vector2_2 = Vector2.Normalize(vector2_1.RotatedByRandom(Math.PI / 4.0)) * 7f;
							if (projectile.owner == Main.myPlayer)
								Projectile.NewProjectile(projectile.Center, vector2_2, mod.ProjectileType("CultistLightningArc"), projectile.damage, projectile.knockBack / 2f, projectile.owner, vector2_1.ToRotation(), num2);
						}
					}
				}
				float num3 = 2000f;
				int index3 = -1;
				for (int index1 = 0; index1 < 200; ++index1)
				{
					NPC npc = Main.npc[index1];
					if (npc.CanBeChasedBy((object)projectile))
					{
						float num2 = projectile.Distance(npc.Center);
						if ((double)num2 < (double)num3 && index1 != num1)
						{
							num3 = num2;
							index3 = index1;
						}
					}
				}
				if (index3 > -1)
				{
					Vector2 vector2_1 = Main.npc[index3].Center - projectile.Center;
					float num2 = (float)Main.rand.Next(100);
					Vector2 vector2_2 = Vector2.Normalize(vector2_1.RotatedByRandom(Math.PI / 4.0)) * 7f;
					if (projectile.owner == Main.myPlayer)
						Projectile.NewProjectile(projectile.Center, vector2_2, mod.ProjectileType("CultistLightningArc"), projectile.damage, projectile.knockBack / 2f, projectile.owner, vector2_1.ToRotation(), num2);
				}
			}
			Lighting.AddLight(projectile.Center, 0.4f, 0.85f, 0.9f);
			++projectile.frameCounter;
			if (projectile.frameCounter > 3)
			{
				projectile.frameCounter = 0;
				++projectile.frame;
				if (projectile.frame > 3)
					projectile.frame = 0;
			}
			float num4 = (float)(Main.rand.NextDouble() * 1.0 - 0.5);
			if ((double)num4 < -0.5)
				num4 = -0.5f;
			if ((double)num4 > 0.5)
				num4 = 0.5f;
			Vector2 vector2_3 = new Vector2((float)-projectile.width * 0.2f * projectile.scale, 0.0f).RotatedBy((double)num4 * 6.28318548202515).RotatedBy((double)projectile.velocity.ToRotation());
			int index4 = Dust.NewDust(projectile.Center - Vector2.One * 5f, 10, 10, 226, (float)(-(double)projectile.velocity.X / 3.0), (float)(-(double)projectile.velocity.Y / 3.0), 150, Color.Transparent, 0.7f);
			Main.dust[index4].position = projectile.Center + vector2_3;
			Main.dust[index4].velocity = Vector2.Normalize(Main.dust[index4].position - this.get_projectile().Center) * 2f;
			Main.dust[index4].noGravity = true;
			float num5 = (float)(Main.rand.NextDouble() * 1.0 - 0.5);
			if ((double)num5 < -0.5)
				num5 = -0.5f;
			if ((double)num5 > 0.5)
				num5 = 0.5f;
			Vector2 vector2_4 = new Vector2((float)-this.get_projectile().width * 0.6f * this.get_projectile().scale, 0.0f).RotatedBy((double)num5 * 6.28318548202515).RotatedBy((double)this.get_projectile().velocity.ToRotation());
			int index5 = Dust.NewDust(this.get_projectile().Center - Vector2.One * 5f, 10, 10, 226, (float)(-(double)this.get_projectile().velocity.X / 3.0), (float)(-(double)this.get_projectile().velocity.Y / 3.0), 150, Color.Transparent, 0.7f);
			Main.dust[index5].velocity = Vector2.Zero;
			Main.dust[index5].position = this.get_projectile().Center + vector2_4;
			Main.dust[index5].noGravity = true;
		}

		public override Color? GetAlpha(Color lightColor) => new Color?(new Color((int)byte.MaxValue, (int)byte.MaxValue, (int)byte.MaxValue, 0) * (float)(1.0 - (double)this.get_projectile().alpha / (double)byte.MaxValue));

		public override bool PreDraw(SpriteBatch spriteBatch, Color lightColor)
		{
			Texture2D texture = Main.projectileTexture[this.get_projectile().type];
			int height = Main.projectileTexture[this.get_projectile().type].Height / Main.projFrames[this.get_projectile().type];
			Rectangle r = new Rectangle(0, height * this.get_projectile().frame, texture.Width, height);
			Vector2 origin = r.Size() / 2f;
			Main.spriteBatch.Draw(texture, this.get_projectile().Center - Main.screenPosition + new Vector2(0.0f, this.get_projectile().gfxOffY), new Rectangle?(r), this.get_projectile().GetAlpha(lightColor), this.get_projectile().rotation, origin, this.get_projectile().scale, SpriteEffects.None, 0.0f);
			return false;
		}
	}
}