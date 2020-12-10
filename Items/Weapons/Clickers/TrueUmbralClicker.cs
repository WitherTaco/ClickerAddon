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
	public class TrueUmbralClicker : ModItem
	{
		public override bool Autoload(ref string name)
		{
			return ClickerCompat.ClickerClass != null;
		}
		
		public override void SetStaticDefaults()
		{
			ClickerCompat.RegisterClickerWeapon(this);
			DisplayName.SetDefault("True Umbral Clicker");
			Tooltip.SetDefault("Click on an enemy within range and sight to damage them");

			string ShadowLashClone = ClickerCompat.RegisterClickEffect(mod, "ShadowLash", "Shadow Lash", "Damages every enemy within the clicker's radius with a guaranteed critical hit", 8, new Color(150, 100, 255, 0), delegate (Player player, Vector2 position, int type, int damage, float knockBack)
			{
				Main.PlaySound(SoundID.Item, (int)Main.MouseWorld.X, (int)Main.MouseWorld.Y, 103);
				Mod clickerClass = ModLoader.GetMod("ClickerClass");

				for (int k = 0; k < 5; k++)
				{
					Projectile.NewProjectile(Main.MouseWorld.X, Main.MouseWorld.Y, Main.rand.NextFloat(-3f, 3f), Main.rand.NextFloat(-3f, 3f), clickerClass.ProjectileType("UmbralClickerPro"), (int)(damage * 0.5f), knockBack, player.whoAmI);
				}
			});
		}
		
		public override void SetDefaults()
		{
			ClickerCompat.SetClickerWeaponDefaults(item);
			ClickerCompat.SetRadius(item, 2.9f);
			ClickerCompat.SetColor(item, new Color(150, 100, 255, 0));
			ClickerCompat.SetDust(item, 27);
			//ClickerCompat.SetEffect(item, "Double Click");
			//ClickerCompat.SetAmount(item, 1);
			//ClickerCompat.SetEffectW(item, "Shadow Lash", 8);
			ClickerCompat.AddEffect(item, "ClickerAddon:ShadowLash");
			
			item.damage = 58;
			item.width = 30;
			item.height = 30;
			item.knockBack = 2f;
			item.value = 1000;
			item.rare = 5;
		}

		public override void AddRecipes()
		{
			Mod clickerClass = ModLoader.GetMod("ClickerClass");
			ModRecipe recipe = new ModRecipe(mod);
			
			recipe.AddIngredient(clickerClass.ItemType("UmbralClicker"));
			recipe.AddIngredient(ItemID.SoulofSight, 20);
			recipe.AddIngredient(ItemID.SoulofMight, 20);
			recipe.AddIngredient(ItemID.SoulofFright, 20);
			recipe.AddIngredient(mod.ItemType("BrockenHeroClicker"));
			
			recipe.AddTile(TileID.MythrilAnvil);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}
