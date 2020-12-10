using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria.DataStructures;
using Terraria.Enums;
using Terraria.ObjectData;

namespace ClickerAddon.Items.Weapons.Clickers
{
	public class TrueArthursClicker : ModItem
	{
		public override bool Autoload(ref string name)
		{
			return ClickerCompat.ClickerClass != null;
		}
		
		public override void SetStaticDefaults()
		{
			ClickerCompat.RegisterClickerWeapon(this);
			DisplayName.SetDefault("True Arthur's Clicker");
			Tooltip.SetDefault("Click on an enemy within range and sight to damage them");

			string HolyNovaClone = ClickerCompat.RegisterClickEffect(mod, "HolyNova", "Holy Nova", "Damages every enemy within the clicker's radius with a guaranteed critical hit", 9, new Color(255, 225, 0, 0), delegate (Player player, Vector2 position, int type, int damage, float knockBack)
			{
				Main.PlaySound(SoundID.NPCHit, (int)Main.MouseWorld.X, (int)Main.MouseWorld.Y, 5);
				Mod clickerClass = ModLoader.GetMod("ClickerClass");
				
				for (int u = 0; u < Main.maxNPCs; u++)
				{
					NPC target = Main.npc[u];
					if (Collision.CanHit(target.Center, 1, 1, Main.MouseWorld, 1, 1) && target.DistanceSQ(Main.MouseWorld) < 350 * 350)
					{
						Vector2 vector = target.Center - Main.MouseWorld;
						float speed = 8f;
						float mag = (float)Math.Sqrt(vector.X * vector.X + vector.Y * vector.Y);
						if (mag > speed)
						{
							mag = speed / mag;
						}
						vector *= mag;
						Projectile.NewProjectile(target.Center.X, target.Center.Y, 0f, 0f, clickerClass.ProjectileType("ArthursClickerPro"), (int)(damage * 0.75f), knockBack, player.whoAmI, 1f, 0f);

						for (int k = 0; k < 30; k++)
						{
							Dust dust = Dust.NewDustDirect(target.Center, 8, 8, 87, vector.X + Main.rand.NextFloat(-1f, 1f), vector.Y + Main.rand.NextFloat(-1f, 1f), 0, default, 1.25f);
							dust.noGravity = true;
						}
					}
				}

				float num102 = 100f;
				int num103 = 0;
				while ((float)num103 < num102)
				{
					Vector2 vector12 = Vector2.UnitX * 0f;
					vector12 += -Vector2.UnitY.RotatedBy((double)((float)num103 * (6.28318548f / num102)), default(Vector2)) * new Vector2(2f, 2f);
					vector12 = vector12.RotatedBy((double)Vector2.Zero.ToRotation(), default(Vector2));
					int num104 = Dust.NewDust(Main.MouseWorld, 0, 0, 87, 0f, 0f, 0, default(Color), 2f);
					Main.dust[num104].noGravity = true;
					Main.dust[num104].position = Main.MouseWorld + vector12;
					Main.dust[num104].velocity = Vector2.Zero * 0f + vector12.SafeNormalize(Vector2.UnitY) * 15f;
					int num = num103;
					num103 = num + 1;
				}
			});
		}
		
		public override void SetDefaults()
		{
			ClickerCompat.SetClickerWeaponDefaults(item);
			ClickerCompat.SetRadius(item, 3.65f);
			ClickerCompat.SetColor(item, new Color(255, 225, 0, 0));
			ClickerCompat.SetDust(item, 87);
			//ClickerCompat.SetEffectW(item, "Holy Nova", 9);
			ClickerCompat.AddEffect(item, "ClickerAddon:HolyNova");
			
			item.damage = 61;
			item.width = 30;
			item.height = 30;
			item.knockBack = 1f;
			item.value = 1000;
			item.rare = 5;
		}
		
		public override void AddRecipes()
		{
			Mod clickerClass = ModLoader.GetMod("ClickerClass");
			ModRecipe recipe = new ModRecipe(mod);
			
			recipe.AddIngredient(clickerClass.ItemType("ArthursClicker"));
			recipe.AddIngredient(ItemID.ChlorophyteBar, 24);
			recipe.AddIngredient(mod.ItemType("BrockenHeroClicker"));
			
			recipe.AddTile(TileID.MythrilAnvil);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}
