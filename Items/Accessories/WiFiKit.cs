using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ClickerAddon.Items.Accessories
{
	[AutoloadEquip(EquipType.Waist)]
	public class WiFiKit : ModItem
	{
		public override bool Autoload(ref string name)
		{
			return WitherTacoLib.IfMod();
		}
		
		public override void SetStaticDefaults()
		{
			ClickerCompat.RegisterClickerItem(this);
			DisplayName.SetDefault("Wi-Fi Kit");
			Tooltip.SetDefault("Every 10 clicks sticks damaging slime on to your screen"
							+ "\nGrants immunity to fire blocks"
							+ "\nIncreases armor penetration by 10"
							+ "\nMakes the radius pulsate up to 50% of the default radius"
							+ "\nGain up to move speed based on your amount of clicks within a second"
							+ "\nYour click have 10% chance to double click");
		}

		public override void SetDefaults()
		{
			item.width = 20;
			item.height = 20;
			item.accessory = true;
			item.value = 20000 * 5;
			item.rare = ItemRarityID.Green;
		}

		public override void UpdateAccessory(Player player, bool hideVisual)
		{
			ClickerCompat.EnableClickEffect(player, "ClickerClass:StickyKeychain");
			player.fireWalk = true;
			player.armorPenetration += 10; 
			player.GetModPlayer<ClickerAddonPlayer>().bigRedButton = true;
			player.GetModPlayer<ClickerAddonPlayer>().bandOfClicking = true;
			player.GetModPlayer<ClickerAddonPlayer>().diceEffect = true;
		}
		
		public override void AddRecipes()
		{
			Mod clickerClass = ModLoader.GetMod("ClickerClass");
			ModRecipe recipe = new ModRecipe(mod);

			recipe.AddIngredient(mod.ItemType("StickyObsidianKeychain"));
			recipe.AddIngredient(mod.ItemType("BigRedButton"));
			recipe.AddIngredient(mod.ItemType("BandOfClicking"));
			recipe.AddIngredient(mod.ItemType("TheDice"));

			recipe.AddTile(TileID.TinkerersWorkbench);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}
