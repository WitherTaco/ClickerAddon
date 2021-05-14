using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using ClickerAddon.Other;

namespace ClickerAddon.Items.CrossContent.Calamity.Armor.Helmets
{
	[AutoloadEquip(EquipType.Head)]
	public class TarragonCapsuit : ModItem
	{
		public override bool Autoload(ref string name)
		{
			return WitherTacoLib.IfMod("CalamityMod");
		}

		public override void SetStaticDefaults()
		{
			ClickerCompat.RegisterClickerItem(this);
			//DisplayName.SetDefault("Capsuit of Fallen");
			Tooltip.SetDefault("Temporary immunity to lava"
							+ "\nCan move freely through liquids"
							+ "\n10% increased clicker damage and crit"
							+ "\n25% decreased clicker radius"
							+ "\n5% increased damage reduction");
		}

		public override void SetDefaults()
		{
			item.width = 27;
			item.height = 22;
			item.value = Item.buyPrice(gold: 50);
			CalamityCompat.SetCalamityRarity(item, CalamityCompat.CalamityRarity.Turquoise);
			item.defense = 18;
		}

		public override void UpdateEquip(Player player)
		{
			ClickerCompat.SetDamageAdd(player, 0.1f);
			ClickerCompat.SetClickerCritAdd(player, 10);
			ClickerCompat.SetClickerRadiusAdd(player, -WitherTacoLib.Math.Radius(0.25f));
			player.endurance += 0.05f;
			player.lavaMax += 240;
			player.ignoreWater = true;
		}

		public override bool IsArmorSet(Item head, Item body, Item legs)
		{
			Mod calamity = ModLoader.GetMod("CalamityMod");
			return body.type == calamity.ItemType("TarragonBreastplate") && legs.type == calamity.ItemType("TarragonLeggings");
		}

		public override void UpdateArmorSet(Player player)
		{
			player.setBonus = "Reduces enemy spawn rates\nIncreased heart pickup range\nEnemies have a chance to drop extra hearts on death";
			Mod calamity = ModLoader.GetMod("CalamityMod");
			
			//ClickerCompat.SetDamageAdd(player, 0.05f);
			CalamityCompat.CalamityArmorSetBonus(player, "tarragon");
		}

		public override void ArmorSetShadows(Player player)
		{
			player.armorEffectDrawShadowSubtle = true;
			player.armorEffectDrawOutlines = true;
		}
		public override void DrawHair(ref bool drawHair, ref bool drawAltHair)
		{
			drawAltHair = true; 
		}
		public override bool DrawHead()
		{
			return false;
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			Mod calamity = ModLoader.GetMod("CalamityMod");

			recipe.AddIngredient(calamity.ItemType("UeliaceBar"), 7);
			recipe.AddIngredient(calamity.ItemType("DivineGeode"), 6);
			
			recipe.SetResult(this);
			recipe.AddTile(TileID.LunarCraftingStation);
			recipe.AddRecipe();
		}
	}
}