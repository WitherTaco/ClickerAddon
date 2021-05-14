using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ModLoader;

namespace ClickerAddon.Projectiles.Clickers.Fargo
{
	public class CultistIceSpike : ModProjectile
	{
		public Projectile get_projectile()
		{
			return projectile;
		}
		public override void SetStaticDefaults()
		{
			ClickerCompat.RegisterClickerProjectile(this);
			DisplayName.SetDefault("Ice Spike"); 
		}

		public override void SetDefaults()
		{
			this.get_projectile().width = 34;
			this.get_projectile().height = 34;
			this.get_projectile().aiStyle = -1;
			this.get_projectile().alpha = (int)byte.MaxValue;
			this.get_projectile().friendly = true;
			this.get_projectile().minion = true;
			this.get_projectile().ignoreWater = true;
			this.get_projectile().tileCollide = false;
			this.get_projectile().extraUpdates = 1;
			this.get_projectile().timeLeft = 180;
			this.get_projectile().penetrate = -1;
			this.get_projectile().usesLocalNPCImmunity = true;
			this.get_projectile().localNPCHitCooldown = 10;
		}

		public override void AI()
		{
			this.get_projectile().alpha -= 10;
			if (this.get_projectile().alpha < 0)
				this.get_projectile().alpha = 0;
			int index = Dust.NewDust(this.get_projectile().Center + Utils.RandomVector2(Main.rand, -8f, 8f) / 2f, 8, 8, 197, Alpha: 100, newColor: Color.Transparent);
			Main.dust[index].noGravity = true;
			this.get_projectile().rotation = this.get_projectile().velocity.ToRotation();
			Lighting.AddLight(this.get_projectile().Center, 0.3f, 0.75f, 0.9f);
		}

		public override void OnHitNPC(NPC target, int damage, float knockback, bool crit) => target.AddBuff(44, 240);

		public override Color? GetAlpha(Color lightColor) => new Color?(new Color((int)byte.MaxValue, (int)byte.MaxValue, (int)byte.MaxValue, (int)byte.MaxValue) * (float)(1.0 - (double)this.get_projectile().alpha / (double)byte.MaxValue));

		public override bool PreDraw(SpriteBatch spriteBatch, Color lightColor)
		{
			Texture2D texture = Main.projectileTexture[this.get_projectile().type];
			Rectangle bounds = texture.Bounds;
			Vector2 origin = bounds.Size() / 2f;
			Main.spriteBatch.Draw(texture, this.get_projectile().Center - Main.screenPosition + new Vector2(0.0f, this.get_projectile().gfxOffY), new Rectangle?(bounds), this.get_projectile().GetAlpha(lightColor), this.get_projectile().rotation, origin, this.get_projectile().scale, SpriteEffects.None, 0.0f);
			return false;
		}
	}
}