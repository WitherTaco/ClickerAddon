using Microsoft.Xna.Framework;
using Terraria.ID;
using Terraria.ModLoader;

namespace ClickerAddon.Items.Weapons.Clickers
{
	//Sample code for a clicker weapon
	public class DamageClicker : ModItem
	{
		//Optional, if you only want this item to exist only when Clicker Class is enabled
		public override bool Autoload(ref string name)
		{
			return ClickerCompat.ClickerClass != null;
		}

		public override void SetStaticDefaults()
		{
			//You NEED to call this in SetStaticDefaults to make it count as a clicker weapon. also sets the default tooltip
			ClickerCompat.RegisterClickerWeapon(this);

			DisplayName.SetDefault("Damage Clicker");
			Tooltip.SetDefault("'Dev Only'");
		}

		public override void SetDefaults()
		{
			//This call is mandatory as it sets common stats like useStyle which is shared between all clickers
			ClickerCompat.SetClickerWeaponDefaults(item);

			//Use these methods to adjust clicker weapon specific stats
			ClickerCompat.SetRadius(item, 1.0f);
			ClickerCompat.SetColor(item, Color.White);
			ClickerCompat.SetDust(item, DustID.Fire);

			//These two aren't finished/implemented properly yet so you can only use Clicker Classes base effects (you can find them in the source code)

			item.damage = 100;
			item.width = 30;
			item.height = 30;
			item.knockBack = 0.5f;
			item.value = 20;
			item.rare = ItemRarityID.White;
		}

		/*public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.Wood, 10);
			recipe.AddTile(TileID.WorkBenches);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}*/
	}
}
