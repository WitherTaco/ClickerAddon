using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ClickerAddon.Projectiles.Clickers.Thorium
{
	public class AquaTyphoon : ModProjectile
	{
		public override void SetStaticDefaults()
		{
			ClickerCompat.RegisterClickerProjectile(this);
		}
		
		public override void SetDefaults()
		{
			//projectile.CloneDefaults(ModLoader.GetMod("ThoriumMod").ProjectileType("AquaTyphoon"));
			

			//projectile.netImportant = true;
			projectile.width = 140;
			projectile.height = 42;
			projectile.aiStyle = 1;
			projectile.tileCollide = false;
			projectile.penetrate = -1;
			projectile.timeLeft = 300;
			//projectile.extraUpdates = 1;
			aiType = 14;
			//ProjectileID.Sets.TrailCacheLength[projectile.type] = 20;
			//ProjectileID.Sets.TrailingMode[projectile.type] = 0;

			projectile.usesLocalNPCImmunity = true;
			projectile.localNPCHitCooldown = 20;
			projectile.friendly = true;
			Main.projFrames[projectile.type] = 6;
			projectile.maxPenetrate = -1;
			projectile.ignoreWater = true;

		}
		public override Color? GetAlpha(Color lightColor) => new Color?(new Color((int)byte.MaxValue, (int)byte.MaxValue, (int)byte.MaxValue, 150) * 1f);
		public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
		{
			target.AddBuff(36, 600, false);
		}
		public override bool PreDraw(SpriteBatch spriteBatch, Color lightColor)
		{
			Rectangle rectangle = new Rectangle(0, 0, 140, 44);
			int local = rectangle.Y;
			Vector2 vec1 = new Vector2(70f, 21f);

			local += 44 * projectile.frame;
			for (int index = 0; index < projectile.oldPos.Length; ++index)
			{
				Vector2 vec2 = projectile.oldPos[index] - Main.screenPosition + vec1 + new Vector2(0.0f, projectile.gfxOffY);
				Color color = projectile.GetAlpha(new Color((int)byte.MaxValue, (int)byte.MaxValue, (int)byte.MaxValue, 0) * 0.01f)
					* ((float)(projectile.oldPos.Length - index) / (float)projectile.oldPos.Length);
				spriteBatch.Draw(
					mod.GetTexture("Projectiles/Clickers/Thorium/AquaTyphoon"),
					vec2,
					new Rectangle?(rectangle),
					color * 0.35f,
					projectile.rotation,
					vec1,
					projectile.scale - 0.025f * (float)index,
					(SpriteEffects)0,
					0.0f
				);
			}
			return true;
		}
		public override void PostAI()
		{
			++projectile.frameCounter;
			if (projectile.frameCounter > 2)
			{
				++projectile.frame;
				projectile.frameCounter = 0;
			}
			//++projectile.frame;
			if (projectile.frame < 6)
				projectile.frame = 1;
		}
	}
}