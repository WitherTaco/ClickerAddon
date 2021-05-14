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
	public class AerospecClicker : ModItem
	{
		public override bool Autoload(ref string name)
		{
			return WitherTacoLib.IfMod("CalamityMod");
		}

		public override void SetStaticDefaults()
		{
			ClickerCompat.RegisterClickerWeapon(this, borderTexture: "ClickerAddon/Items/CrossContent/Calamity/Weapons/Clickers/AerospecClicker_Outline");
			//DisplayName.SetDefault("Xenomite Clicker");
			Tooltip.SetDefault("Click on an enemy within range and sight to damage them");

			string SeaSplash = ClickerCompat.RegisterClickEffect(mod, "BurstOfAir", "Burst of air", "Creates a burst of air that deals damage", 6, new Color(160, 210, 160, 0), delegate (Player player, Vector2 position, int type, int damage, float knockBack)
			{
				Projectile.NewProjectile(Main.MouseWorld.X, Main.MouseWorld.Y, 0f, 0f, mod.ProjectileType("AerospecClickerPro"), damage, knockBack * 100, player.whoAmI);
			});
		}
		
		public override void SetDefaults()
		{
			ClickerCompat.SetClickerWeaponDefaults(item);
			ClickerCompat.SetRadius(item, 2.1f);
			ClickerCompat.SetColor(item, new Color(160, 210, 160, 0));
			ClickerCompat.SetDust(item, 89);
			//ClickerCompat.SetEffectW(item, "Holy Nova", 9);
			ClickerCompat.AddEffect(item, "ClickerAddon:BurstOfAir");
			
			item.damage = 13;
			item.width = 30;
			item.height = 30;
			item.knockBack = 1f;
			item.value = 1000;
			item.rare = ItemRarityID.LightRed;
		}
		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			Mod calamity = ModLoader.GetMod("CalamityMod");

			recipe.AddIngredient(calamity.ItemType("AerialiteBar"), 7);
			recipe.AddIngredient(ItemID.SunplateBlock, 3);

			recipe.SetResult(this);
			recipe.AddTile(TileID.SkyMill);
			recipe.AddRecipe();
		}
	}
}
