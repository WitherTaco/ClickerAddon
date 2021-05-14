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

namespace ClickerAddon.Items.Weapons.Clickers
{
	public class ZClicker : ModItem
	{
		public override bool Autoload(ref string name)
		{
			return WitherTacoLib.IfMod();
		}

		public override void SetStaticDefaults()
		{
			ClickerCompat.RegisterClickerWeapon(this);
			DisplayName.SetDefault("Z-Clicker");
			Tooltip.SetDefault("Click on an enemy within range and sight to damage them");

			string ShadowLashClone = ClickerCompat.RegisterClickEffect(mod, "ZClick", "Z-Click", "Summon a lot of damaging clicks", 1, new Color(0, 0, 255, 0), delegate (Player player, Vector2 position, int type, int damage, float knockBack)
			{
				Main.PlaySound(SoundID.Item, (int)Main.MouseWorld.X, (int)Main.MouseWorld.Y, 103);
				Mod clickerClass = ModLoader.GetMod("ClickerClass");

				for (int i = 0; i < 5; i++)
				{
					Projectile.NewProjectile(Main.MouseWorld + 20 * Vector2.UnitX.RotatedByRandom(MathHelper.TwoPi), Vector2.Zero, ModContent.ProjectileType<ZClickerPro>(), (int)(damage * 0.5f), 0f, Main.myPlayer);
				}
			});
		}
		
		public override void SetDefaults()
		{
			ClickerCompat.SetClickerWeaponDefaults(item);
			ClickerCompat.SetRadius(item, 6f);
			ClickerCompat.SetColor(item, new Color(0, 0, 255, 0));
			ClickerCompat.SetDust(item, 27);
			//ClickerCompat.SetEffectW(item, "Shadow Lash", 8);
			ClickerCompat.AddEffect(item, "ClickerAddon:ZClick");
			
			item.damage = 175;
			item.width = 30;
			item.height = 30;
			item.knockBack = 2f;
			item.value = 50000 * 5;
			item.rare = ItemRarityID.Red;
		}

		public override void AddRecipes()
		{
			Mod clickerClass = ModLoader.GetMod("ClickerClass");
			ModRecipe recipe = new ModRecipe(mod);

			recipe.AddIngredient(clickerClass.ItemType("WoodenClicker"), 1);
			recipe.AddIngredient(clickerClass.ItemType("HemoClicker"), 1);
			recipe.AddIngredient(clickerClass.ItemType("HoneyGlazedClicker"), 1); 
			recipe.AddIngredient(clickerClass.ItemType("CrystalClicker"), 1);
			recipe.AddIngredient(clickerClass.ItemType("EclipticClicker"), 1);
			recipe.AddIngredient(mod.ItemType("TerraClicker"), 1);
			recipe.AddIngredient(clickerClass.ItemType("HighTechClicker"), 1);
			recipe.AddIngredient(clickerClass.ItemType("LordsClicker"), 1);
			recipe.AddIngredient(clickerClass.ItemType("TheClicker"), 1);

			recipe.AddTile(TileID.MythrilAnvil);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}
