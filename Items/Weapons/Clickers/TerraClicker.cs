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
	public class TerraClicker : ModItem
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

			string Terra = ClickerCompat.RegisterClickEffect(mod, "TerraDamage", "Terra Damage", "Shoots 4 terra cursors with 50% weapon damage", 7, new Color(100, 225, 0, 0), delegate (Player player, Vector2 position, int type, int damage, float knockBack)
			{
				Main.PlaySound(SoundID.Item1.SoundId, (int)Main.MouseWorld.X, (int)Main.MouseWorld.Y, 5);
				Mod clickerClass = ModLoader.GetMod("ClickerClass");
				
				for (int k = 0; k < 4; k++)
				{
					Projectile.NewProjectile(Main.MouseWorld.X, Main.MouseWorld.Y, Main.rand.NextFloat(-4f, 4f), Main.rand.NextFloat(-4f, 4f), mod.ProjectileType("TerraClickerPro"), (int)(damage * 0.5f), knockBack, player.whoAmI);
				}
			});
		}
		
		public override void SetDefaults()
		{
			ClickerCompat.SetClickerWeaponDefaults(item);
			ClickerCompat.SetRadius(item, 3.8f);
			ClickerCompat.SetColor(item, new Color(100, 225, 0, 0));
			ClickerCompat.SetDust(item, 87);
			//ClickerCompat.SetEffectW(item, "Holy Nova", 9);
			ClickerCompat.AddEffect(item, "ClickerAddon:TerraDamage");
			
			item.damage = 75;
			item.width = 30;
			item.height = 30;
			item.knockBack = 1f;
			item.value = 75000 * 5;
			item.rare = ItemRarityID.Yellow;
		}
		
		public override void AddRecipes()
		{
			Mod clickerClass = ModLoader.GetMod("ClickerClass");
			ModRecipe recipe = new ModRecipe(mod);
			
			//recipe.AddIngredient(clickerClass.ItemType("ArthursClicker"));
			//recipe.AddIngredient(ItemID.ChlorophyteBar, 24);
			recipe.AddIngredient(mod.ItemType("TrueArthursClicker"));
			recipe.AddIngredient(mod.ItemType("TrueUmbralClicker"));
			recipe.AddIngredient(mod.ItemType("BrockenHeroClicker"));
			
			recipe.AddTile(TileID.MythrilAnvil);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}
