using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ClickerAddon.Items.Accessories
{
	[AutoloadEquip(EquipType.HandsOn)]
	public class MiceClickingGlove : ModItem
	{
		public override bool Autoload(ref string name)
		{
			return WitherTacoLib.IfMod();
		}
		
		public override void SetStaticDefaults()
		{
			ClickerCompat.RegisterClickerItem(this);
			Tooltip.SetDefault("While in combat, automatically clicks your current clicker every half-second"
							+ "\nIncreases click damage by 10%"
							+ "\nIncreases click critical strike chance by 2%"
							+ "\nClicker attacks inflict fire damage");
		}

		public override void SetDefaults()
		{
			item.width = 20;
			item.height = 20;
			item.accessory = true;
			item.value = 45000 * 5;
			item.rare = ItemRarityID.Red;
		}

		public override void UpdateAccessory(Player player, bool hideVisual)
		{
			/*player.GetModPlayer<ClickerPlayer>().clickerGloveAcc2 = true;*/
			ClickerCompat.SetAccessory(player, "RegalClickingGlove");
			ClickerCompat.SetDamageAdd(player, 0.1f);
			ClickerCompat.SetClickerCritAdd(player, 2);
			player.GetModPlayer<ClickerAddonPlayer>().magmaChair = true;
		}
		
		public override void AddRecipes()
		{
			Mod clickerClass = ModLoader.GetMod("ClickerClass");
			ModRecipe recipe = new ModRecipe(mod);
			
			recipe.AddIngredient(mod.ItemType("MagmaClickingGlove"));
			recipe.AddIngredient(clickerClass.ItemType("MiceFragment"), 8);
			
			recipe.AddTile(TileID.LunarCraftingStation);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}
