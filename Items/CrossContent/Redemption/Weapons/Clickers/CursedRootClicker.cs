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

namespace ClickerAddon.Items.CrossContent.Redemption.Weapons.Clickers
{
	public class CursedRootClicker : ModItem
	{
		public override bool Autoload(ref string name)
		{
			return WitherTacoLib.IfMod("Redemption");
		}

		public override void SetStaticDefaults()
		{
			ClickerCompat.RegisterClickerWeapon(this);
			//DisplayName.SetDefault("Xenomite Clicker");
			Tooltip.SetDefault("Click on an enemy within range and sight to damage them");

			string CursedRootEffect = ClickerCompat.RegisterClickEffect(mod, "CursedRoot", "Cursed Root", "Star-shaped shoots roots", 7, new Color(160, 210, 160, 0), delegate (Player player, Vector2 position, int type, int damage, float knockBack)
			{
				Mod redemption = ModLoader.GetMod("Redemption");
				Vector2 vec = new Vector2(Main.MouseWorld.X, Main.MouseWorld.Y);
				
				Projectile.NewProjectile(vec, new Vector2(9f, 0f), redemption.ProjectileType("BloodrootRoot"), damage, 0f, Main.myPlayer);
				Projectile.NewProjectile(vec, new Vector2(9f, 9f), redemption.ProjectileType("BloodrootRoot"), damage, 0f, Main.myPlayer);
				Projectile.NewProjectile(vec, new Vector2(0f, 9f), redemption.ProjectileType("BloodrootRoot"), damage, 0f, Main.myPlayer);
				Projectile.NewProjectile(vec, new Vector2(-9f, 9f), redemption.ProjectileType("BloodrootRoot"), damage, 0f, Main.myPlayer);
				Projectile.NewProjectile(vec, new Vector2(-9f, 0f), redemption.ProjectileType("BloodrootRoot"), damage, 0f, Main.myPlayer);
				Projectile.NewProjectile(vec, new Vector2(-9f, -9f), redemption.ProjectileType("BloodrootRoot"), damage, 0f, Main.myPlayer);
				Projectile.NewProjectile(vec, new Vector2(0f, -9f), redemption.ProjectileType("BloodrootRoot"), damage, 0f, Main.myPlayer);
				Projectile.NewProjectile(vec, new Vector2(9f, -9f), redemption.ProjectileType("BloodrootRoot"), damage, 0f, Main.myPlayer);

			});
		}
		
		public override void SetDefaults()
		{
			ClickerCompat.SetClickerWeaponDefaults(item);
			ClickerCompat.SetRadius(item, 2.1f);
			ClickerCompat.SetColor(item, new Color(160, 210, 160, 0));
			ClickerCompat.SetDust(item, 89);
			//ClickerCompat.SetEffectW(item, "Holy Nova", 9);
			ClickerCompat.AddEffect(item, "ClickerAddon:CursedRoot");
			
			item.damage = 8;
			item.width = 30;
			item.height = 30;
			item.knockBack = 1f;
			item.value = 1000;
			item.rare = 2;
		}
	}
}
