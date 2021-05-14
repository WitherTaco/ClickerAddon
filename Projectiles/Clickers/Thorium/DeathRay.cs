using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ClickerAddon.Projectiles.Clickers.Thorium
{
	public class DeathRay : ModProjectile
	{
		public override void SetStaticDefaults()
		{
			ClickerCompat.RegisterClickerProjectile(this);
		}
		public override void SetDefaults()
		{
			projectile.width = 30;
			projectile.height = 30;
			projectile.aiStyle = 1;
			projectile.friendly = true;
			projectile.tileCollide = false;
			projectile.penetrate = -1;
			projectile.timeLeft = 600;
			projectile.extraUpdates = 1;
			//ProjectileID.Sets.TrailCacheLength[projectile.type] = 8;
			//ProjectileID.Sets.TrailingMode[projectile.type] = 0;
			projectile.usesLocalNPCImmunity = true;
			projectile.localNPCHitCooldown = 20;
			projectile.ignoreWater = true;
			projectile.maxPenetrate = -1;
		}
		public override Color? GetAlpha(Color lightColor) => new Color?(new Color((int)byte.MaxValue, (int)byte.MaxValue, (int)byte.MaxValue, 150) * 1f);
		public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
		{
			target.AddBuff(BuffID.CursedInferno, 300, true);
		}
	}
}