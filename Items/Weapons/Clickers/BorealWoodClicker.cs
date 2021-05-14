using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria.DataStructures;
using Terraria.Enums;
using Terraria.ObjectData;
using ClickerAddon.Projectiles.Clickers;

namespace ClickerAddon.Items.Weapons.Clickers
{
	public class BorealWoodClicker : ModItem
	{
		public override bool Autoload(ref string name)
		{
			return WitherTacoLib.IfMod();
		}

		public override void SetStaticDefaults()
		{
			ClickerCompat.RegisterClickerWeapon(this);
			//DisplayName.SetDefault("True Arthur's Clicker");
			Tooltip.SetDefault("Click on an enemy within range and sight to damage them");
			string BorealEffect = ClickerCompat.RegisterClickEffect(mod, "Boreal", "Boreal Spikes", "Shoot a boreal spiges", 5, new Color(61, 49, 41, 0), delegate (Player player, Vector2 position, int type, int damage, float knockBack)
			{
				Mod clickerClass = ModLoader.GetMod("ClickerClass");
				//Projectile.NewProjectile(Main.MouseWorld.X, Main.MouseWorld.Y, 0f, 0f, ModContent.ProjectileType<LordsClickerProSuper>(), damage, knockBack, player.whoAmI);

				for(int i = 0; i < 8; i++)
				{
					Projectile.NewProjectile(Main.MouseWorld.X, Main.MouseWorld.Y, Main.rand.NextFloat(-2f, 2f), Main.rand.NextFloat(-2f, 2f), ModContent.ProjectileType<BorealNeedle>(), (int)(damage * 0.1f), knockBack, player.whoAmI);
				}
			});
		}
		
		public override void SetDefaults()
		{
			ClickerCompat.SetClickerWeaponDefaults(item);
			ClickerCompat.SetRadius(item, 0.9f);
			ClickerCompat.SetColor(item, new Color(61, 49, 41, 0));
			ClickerCompat.SetDust(item, 87);
			ClickerCompat.AddEffect(item, "ClickerAddon:Boreal");

			item.damage = 5;
			item.width = 30;
			item.height = 30;
			item.knockBack = 1f;
			item.value = 24;
			item.rare = ItemRarityID.White;
		}
		
		public override void AddRecipes()
		{
			Mod clickerClass = ModLoader.GetMod("ClickerClass");
			ModRecipe recipe = new ModRecipe(mod);
			
			recipe.AddIngredient(ItemID.BorealWood, 10);
			
			recipe.AddTile(TileID.WorkBenches);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}
