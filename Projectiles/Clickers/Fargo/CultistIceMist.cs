using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ClickerAddon.Projectiles.Clickers.Fargo
{
	public class CultistIceMist : ModProjectile
	{
		public Projectile get_projectile()
		{
			return projectile;
		}
		public override string Texture => "Terraria/Projectile_464";

		public override void SetStaticDefaults()
		{
			ClickerCompat.RegisterClickerProjectile(this);
			DisplayName.SetDefault("Ice Mist"); 
		}

		public override void SetDefaults()
		{
			this.get_projectile().width = 60;
			this.get_projectile().height = 60;
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
			if ((double)this.get_projectile().localAI[0] == 0.0)
			{
				this.get_projectile().localAI[0] = 1f;
				Main.PlaySound(SoundID.Item120, this.get_projectile().position);
			}
			this.get_projectile().alpha += this.get_projectile().timeLeft > 20 ? -10 : 10;
			if (this.get_projectile().alpha < 0)
				this.get_projectile().alpha = 0;
			if (this.get_projectile().alpha > (int)byte.MaxValue)
				this.get_projectile().alpha = (int)byte.MaxValue;
			if (this.get_projectile().timeLeft % 60 == 0)
			{
				Main.PlaySound(SoundID.Item120, this.get_projectile().position);
				Vector2 spinningpoint = Vector2.UnitX.RotatedBy((double)this.get_projectile().rotation) * 8f;
				for (int index = 0; index < 6; ++index)
				{
					spinningpoint = spinningpoint.RotatedBy(1.04719758033752);
					if (this.get_projectile().owner == Main.myPlayer)
						Projectile.NewProjectile(this.get_projectile().Center, spinningpoint, mod.ProjectileType("CultistIceSpike"), this.get_projectile().damage, this.get_projectile().knockBack, this.get_projectile().owner, (float)this.get_projectile().whoAmI, 0.0f);
				}
			}
			this.get_projectile().rotation += (float)Math.PI / 40f;
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
