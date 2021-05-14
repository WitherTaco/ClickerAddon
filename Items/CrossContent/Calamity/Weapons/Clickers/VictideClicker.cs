using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria.DataStructures;
using Terraria.Enums;
using Terraria.ObjectData;
using Terraria.Utilities;
//using Redemption.Projectiles.v08;
//using Redemption;
using ClickerAddon.Projectiles.Clickers;

namespace ClickerAddon.Items.CrossContent.Calamity.Weapons.Clickers
{
	public class VictideClicker : ModItem
	{
		public override bool Autoload(ref string name)
		{
			return WitherTacoLib.IfMod("CalamityMod");
		}

		public override void SetStaticDefaults()
		{
			ClickerCompat.RegisterClickerWeapon(this, borderTexture: "ClickerAddon/Items/CrossContent/Calamity/Weapons/Clickers/VictideClicker_Outline");
			//DisplayName.SetDefault("Xenomite Clicker");
			Tooltip.SetDefault("Click on an enemy within range and sight to damage them");

			string SeaSplash = ClickerCompat.RegisterClickEffect(mod, "SeaSplash", "Sea Splash", "Star-shaped shoots shells", 10, new Color(160, 210, 160, 0), delegate (Player player, Vector2 position, int type, int damage, float knockBack)
			{
				Vector2 vec = new Vector2(Main.MouseWorld.X, Main.MouseWorld.Y);
				
				Projectile.NewProjectile(vec, new Vector2(6f, 0f), mod.ProjectileType("SeashellPro"), damage, 0f, Main.myPlayer);
				Projectile.NewProjectile(vec, new Vector2(6f, 6f), mod.ProjectileType("SeashellPro"), damage, 0f, Main.myPlayer);
				Projectile.NewProjectile(vec, new Vector2(0f, 6f), mod.ProjectileType("SeashellPro"), damage, 0f, Main.myPlayer);
				Projectile.NewProjectile(vec, new Vector2(-6f, 6f), mod.ProjectileType("SeashellPro"), damage, 0f, Main.myPlayer);
				Projectile.NewProjectile(vec, new Vector2(-6f, 0f), mod.ProjectileType("SeashellPro"), damage, 0f, Main.myPlayer);
				Projectile.NewProjectile(vec, new Vector2(-6f, -6f), mod.ProjectileType("SeashellPro"), damage, 0f, Main.myPlayer);
				Projectile.NewProjectile(vec, new Vector2(0f, -6f), mod.ProjectileType("SeashellPro"), damage, 0f, Main.myPlayer);
				Projectile.NewProjectile(vec, new Vector2(6f, -6f), mod.ProjectileType("SeashellPro"), damage, 0f, Main.myPlayer);

			});
		}
		
		public override void SetDefaults()
		{
			ClickerCompat.SetClickerWeaponDefaults(item);
			ClickerCompat.SetRadius(item, 2.1f);
			ClickerCompat.SetColor(item, new Color(160, 210, 160, 0));
			ClickerCompat.SetDust(item, 89);
			//ClickerCompat.SetEffectW(item, "Holy Nova", 9);
			ClickerCompat.AddEffect(item, "ClickerAddon:SeaSplash");
			
			item.damage = 10;
			item.width = 30;
			item.height = 30;
			item.knockBack = 1f;
			item.value = 1000;
			item.rare = ItemRarityID.Green;
		}
		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			Mod calamity = ModLoader.GetMod("CalamityMod");

			recipe.AddIngredient(calamity.ItemType("VictideBar"), 3);

			recipe.SetResult(this);
			recipe.AddTile(TileID.Anvils);
			recipe.AddRecipe();
		}
	}
}
