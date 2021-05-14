using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ClickerAddon.Items.Accessories
{
	public class UpdatedClickerEmblem : ModItem
	{
		public override bool Autoload(ref string name)
		{
			//return ClickerCompat.ClickerClass != null;
			return false;
		}
		
		public override void SetStaticDefaults()
		{
			ClickerCompat.RegisterClickerItem(this);
			Tooltip.SetDefault("Increases click damage by 20%");
		}

		public override void SetDefaults()
		{
			item.width = 20;
			item.height = 20;
			item.accessory = true;
			item.value = 35000;
			item.rare = 8;
		}

		public override void UpdateAccessory(Player player, bool hideVisual)
		{
			/*player.GetModPlayer<ClickerPlayer>().clickerGloveAcc2 = true;*/
			ClickerCompat.SetAccessory(player, "RegalClickingGlove");
			ClickerCompat.SetDamageAdd(player, 0.2f);
		}
		
		/*public override void AddRecipes()
		{
			Mod clickerClass = ModLoader.GetMod("ClickerClass");
			ModRecipe recipe = new ModRecipe(mod);
			
			recipe.AddIngredient(clickerClass.ItemType("ClickerEmblem"));
			recipe.AddIngredient(3261, 4);
			recipe.AddIngredient(1552, 4);
			
			recipe.AddTile(TileID.TinkerersWorkbench);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}*/
	}
}
