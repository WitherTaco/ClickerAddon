using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria.DataStructures;
using Terraria.Enums;
using Terraria.ObjectData;
using Redemption.Projectiles.v08;

namespace ClickerAddon.Items.Redemption.Weapons.Clickers
{
	public class XenoClicker : ModItem
	{
		public static short customGlowMask;
		
		public override bool Autoload(ref string name)
		{
			return ((ClickerCompat.ClickerClass != null) && (Terraria.ModLoader.ModLoader.GetMod("Redemption") != null));
		}
		
		public override void SetStaticDefaults()
		{
			ClickerCompat.RegisterClickerWeapon(this);
			DisplayName.SetDefault("Xenomite Clicker");
			Tooltip.SetDefault("Click on an enemy within range and sight to damage them");

			string XenoEffect = ClickerCompat.RegisterClickEffect(mod, "XenoEffect", "Xeno Splash", "Damage from xenomite splash", 7, new Color(55, 200, 60, 0), delegate (Player player, Vector2 position, int type, int damage, float knockBack)
			{
				Mod redemption = ModLoader.GetMod("Redemption");
				for(int i = 0; i < 10; i++)
				{
					//Projectile.NewProjectile(Main.MouseWorld + 20 * Vector2.UnitX.RotatedByRandom(MathHelper.TwoPi), Vector2.Zero, redemption.ProjectileType<XenoYoyoShard>, (int)(damage * 0.5f), 0f, Main.myPlayer);
					Projectile.NewProjectile(new Vector2(Main.MouseWorld.X, Main.MouseWorld.Y), new Vector2(Main.rand.NextFloat(-3f, 3f), Main.rand.NextFloat(-3f, 3f)), redemption.ProjectileType("XenoYoyoShard"), (int)(damage * 0.2f), 0f, Main.myPlayer);
				}
			});
		}
		
		public override void SetDefaults()
		{
			ClickerCompat.SetClickerWeaponDefaults(item);
			ClickerCompat.SetRadius(item, 3.10f);
			ClickerCompat.SetColor(item, new Color(0, 50, 65, 0));
			ClickerCompat.SetDust(item, 89);
			//ClickerCompat.SetEffectW(item, "Holy Nova", 9);
			ClickerCompat.AddEffect(item, "ClickerAddon:XenoEffect");
			
			item.damage = 46;
			item.width = 30;
			item.height = 30;
			item.knockBack = 1f;
			item.value = 1000;
			item.rare = 7;
		}
		
		public override void AddRecipes()
		{
			Mod clickerClass = ModLoader.GetMod("ClickerClass");
			Mod redemption = ModLoader.GetMod("Redemption");
			ModRecipe recipe = new ModRecipe(mod);
			
			/*recipe.AddIngredient(clickerClass.ItemType("ArthursClicker"));
			recipe.AddIngredient(ItemID.ChlorophyteBar, 24);
			recipe.AddIngredient(mod.ItemType("BrockenHeroClicker"));*/
			recipe.AddIngredient(redemption.ItemType("StarliteBar"), 5);
			recipe.AddIngredient(redemption.ItemType("Xenomite"), 20);
			
			recipe.AddTile(redemption.TileType("XenoForgeTile"));
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}
