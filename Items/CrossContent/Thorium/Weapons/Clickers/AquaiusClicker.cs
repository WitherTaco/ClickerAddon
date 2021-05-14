using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria.DataStructures;
using Terraria.Enums;
using Terraria.ObjectData;
using ClickerAddon.Items.Weapons.Clickers;
using ClickerAddon.Projectiles.Clickers;

namespace ClickerAddon.Items.CrossContent.Thorium.Weapons.Clickers
{
	public class AquaiusClicker : ModItem
	{
		public override bool Autoload(ref string name)
		{
			return WitherTacoLib.IfMod("ThoriumMod");
		}

		public override void SetStaticDefaults()
		{
			ClickerCompat.RegisterClickerWeapon(this);
			DisplayName.SetDefault("Aquaius`s Clicker");
			Tooltip.SetDefault("Click on an enemy within range and sight to damage them");

			string AquaWave = ClickerCompat.RegisterClickEffect(mod, "AquaWave", "Aqua Wave", "Two waves appear on the sides, dealing damage horizontally", 7, new Color(0, 148, 255, 0), delegate (Player player, Vector2 position, int type, int damage, float knockBack)
			{
				//Main.PlaySound(SoundID.Item, (int)Main.MouseWorld.X, (int)Main.MouseWorld.Y, 103);
				Mod clickerClass = ModLoader.GetMod("ClickerClass");

				Projectile.NewProjectile(Main.MouseWorld.X + 1200, Main.MouseWorld.Y, -12f, 0f, mod.ProjectileType("AquaTyphoon"), damage, knockBack, player.whoAmI);
				Projectile.NewProjectile(Main.MouseWorld.X - 1200, Main.MouseWorld.Y, 12f, 0f, mod.ProjectileType("AquaTyphoon"), damage, knockBack, player.whoAmI);
			});
		}
		
		public override void SetDefaults()
		{
			ClickerCompat.SetClickerWeaponDefaults(item);
			ClickerCompat.SetRadius(item, 6.5f);
			ClickerCompat.SetColor(item, new Color(0, 148, 255, 0));
			ClickerCompat.SetDust(item, 157);
			ClickerCompat.AddEffect(item, "ClickerAddon:AquaWave");
			
			item.damage = 205;
			item.width = 30;
			item.height = 30;
			item.knockBack = 2f;
			item.value = 50000 * 5;
			item.rare = ItemRarityID.Red;
		}

		public override void AddRecipes()
		{
			Mod clickerClass = ModLoader.GetMod("ClickerClass");
			Mod thorium = ModLoader.GetMod("ThoriumMod");
			ModRecipe recipe = new ModRecipe(mod);

			recipe.AddIngredient(thorium.ItemType("OceanEssence"), 3);

			recipe.AddTile(TileID.LunarCraftingStation);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}
