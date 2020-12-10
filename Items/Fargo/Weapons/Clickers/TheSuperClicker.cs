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

namespace ClickerAddon.Items.Fargo.Weapons.Clickers
{
	public class TheSuperClicker : ModItem
	{
		public override bool Autoload(ref string name)
		{
			return ((ClickerCompat.ClickerClass != null) && (Terraria.ModLoader.ModLoader.GetMod("Fargowiltas") != null));
		}
		
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("The Super Clicker");
			Tooltip.SetDefault("Click on an enemy within range and sight to damage them");
			ClickerCompat.RegisterClickerWeapon(this);
			
			string SuperClone = ClickerCompat.RegisterClickEffect(mod, "SuperConqueror", "Super Conqueror", "Creates an area-of-effect super phantasmal explosion that deals double damage and a guaranteed critical hit", 1, Color.White, delegate (Player player, Vector2 position, int type, int damage, float knockBack)
			{
				Main.PlaySound(SoundID.Item, (int)Main.MouseWorld.X, (int)Main.MouseWorld.Y, 37);
				Mod clickerClass = ModLoader.GetMod("ClickerClass");
				Projectile.NewProjectile(Main.MouseWorld.X, Main.MouseWorld.Y, 0f, 0f, ModContent.ProjectileType<LordsClickerProSuper>(), damage, knockBack, player.whoAmI);
			});
		}
		
		public override void SetDefaults()
		{
			/*isClicker = true;
			isClickerWeapon = true;
			radiusBoost = 6f;
			clickerColorItem = new Color(255, 255, 255, 0);
			clickerDustColor = 91;
			itemClickerAmount = 1;
			itemClickerEffect = "SuperConqueror";
			itemClickerColorEffect = "ffffff";*/
			
			ClickerCompat.SetClickerWeaponDefaults(item);
			ClickerCompat.SetRadius(item, 6f);
			ClickerCompat.SetColor(item, new Color(255, 255, 225, 0));
			ClickerCompat.SetDust(item, 91);
			ClickerCompat.AddEffect(item, "ClickerAddon:SuperConqueror");
			
			item.damage = 500;
			item.width = 90;
			item.height = 90;
			item.knockBack = 1f;
			item.value = 0;
			item.rare = 10;
		}
		
		public override void AddRecipes()
		{
			Mod clickerClass = ModLoader.GetMod("ClickerClass");
			Mod fargo = ModLoader.GetMod("Fargowiltas");
			ModRecipe recipe = new ModRecipe(mod);
			
			recipe.AddIngredient(clickerClass.ItemType("TheClicker"));
			recipe.AddIngredient(fargo.ItemType("EnergizerMoon"));
			
			recipe.AddTile(fargo.TileType("CrucibleCosmosSheet"));
			recipe.SetResult(this);
			recipe.AddRecipe();
		}

	}
}
