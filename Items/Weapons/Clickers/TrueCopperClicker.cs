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
	public class TrueCopperClicker : ModItem
	{
		public override bool Autoload(ref string name)
		{
			return WitherTacoLib.IfMod();
		}

		public override void SetStaticDefaults()
		{
			ClickerCompat.RegisterClickerWeapon(this);
			/*DisplayName.SetDefault("Copper Clicker");*/
			Tooltip.SetDefault("Click on an enemy within range and sight to damage them");
			string DoubleClickClone = ClickerCompat.RegisterClickEffect(mod, "DoubleClick", "Double Click", "Deals damage twice with one attack", 6, Color.White, delegate (Player player, Vector2 position, int type, int damage, float knockBack)
			{
				Main.PlaySound(SoundID.Item, (int)Main.MouseWorld.X, (int)Main.MouseWorld.Y, 37);
				Mod clickerClass = ModLoader.GetMod("ClickerClass");
				Projectile.NewProjectile(Main.MouseWorld.X, Main.MouseWorld.Y, 0f, 0f, clickerClass.ProjectileType("ClickDamage"), damage, knockBack, player.whoAmI);
			});

		}
		
		public override void SetDefaults()
		{
			ClickerCompat.SetClickerWeaponDefaults(item);
			ClickerCompat.SetRadius(item, 3.5f);
			ClickerCompat.SetColor(item, new Color(255, 150, 75, 0));
			ClickerCompat.SetDust(item, 9);
			/*ClickerCompat.SetEffect(item, "Double Click");
			ClickerCompat.SetAmount(item, 1);*/
			//ClickerCompat.SetEffectW(item, "Double Click", 1);
			ClickerCompat.AddEffect(item, "ClickerAddon:DoubleClick");
			
			item.damage = 47;
			item.width = 30;
			item.height = 30;
			item.knockBack = 1f;
			item.value = 40000 * 5;
			item.rare = ItemRarityID.Yellow;
		}

		public override void AddRecipes()
		{
			Mod clickerClass = ModLoader.GetMod("ClickerClass");
			ModRecipe recipe = new ModRecipe(mod);
			
			recipe.AddIngredient(clickerClass.ItemType("CopperClicker"));
			recipe.AddIngredient(mod.ItemType("BrockenHeroClicker"), 1);
			
			recipe.AddTile(TileID.MythrilAnvil);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}
