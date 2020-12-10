using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;

namespace ClickerAddon.Items.Accessories
{
	public class GamerBoots : ModItem
	{
		public override bool Autoload(ref string name)
		{
			return ClickerCompat.ClickerClass != null;
		}
		
		public override void SetStaticDefaults() 
		{
			ClickerCompat.RegisterClickerItem(this);
			Tooltip.SetDefault("'Coming Soon'"
			+"\nGain up to 20% move speed based on your amount of clicks within a second.");
		}

		public override void SetDefaults() 
		{
			item.width = 32;
			item.height = 32;
			item.value = 50000;
			item.rare = 3;
			item.accessory = true;
		}

		public override void UpdateAccessory(Player player, bool hideVisual) 
		{
			//player.GetModPlayer<ClickerAddonPlayer>().gamerBoots = true;
			player.moveSpeed += (float)(ClickerCompat.GetClickerPerSecond(player) * 0.2f);
		}
		
		public override void AddRecipes()
		{
			/*ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(34);
			recipe.AddIngredient(1322);
			
			recipe.AddTile(114);
			recipe.SetResult(this);
			recipe.AddRecipe();*/
		}
	}
}
