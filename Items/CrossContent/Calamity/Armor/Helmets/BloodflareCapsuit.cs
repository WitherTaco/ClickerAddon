using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using ClickerAddon.Other;

namespace ClickerAddon.Items.CrossContent.Calamity.Armor.Helmets
{
	[AutoloadEquip(EquipType.Head)]
	public class BloodflareCapsuit : ModItem
	{
		public override bool Autoload(ref string name)
		{
			return WitherTacoLib.IfMod("CalamityMod");
		}

		public override void SetStaticDefaults()
		{
			ClickerCompat.RegisterClickerItem(this);
			DisplayName.SetDefault("Bloodflare Crimera Capsuit");
			Tooltip.SetDefault("You can move freely through liquids and have temporary immunity to lava"
							+ "\n10% increased clicker damage and crit"
							+ "\n35% increased clicker radius");
		}

		public override void SetDefaults()
		{
			item.width = 27;
			item.height = 22;
			item.value = Item.buyPrice(gold: 60);
			CalamityCompat.SetCalamityRarity(item, CalamityCompat.CalamityRarity.PureGreen);
			item.defense = 20;
		}

		public override void UpdateEquip(Player player)
		{
			ClickerCompat.SetDamageAdd(player, 0.1f);
			ClickerCompat.SetClickerCritAdd(player, 10);
			ClickerCompat.SetClickerRadiusAdd(player, WitherTacoLib.Math.Radius(0.35f));
			player.lavaMax += 240;
			player.ignoreWater = true;
		}

		public override bool IsArmorSet(Item head, Item body, Item legs)
		{
			Mod calamity = ModLoader.GetMod("CalamityMod");
			return body.type == calamity.ItemType("BloodflareBodyArmor") && legs.type == calamity.ItemType("BloodflareCuisses");
		}

		public override void UpdateArmorSet(Player player)
		{
			player.setBonus = "Greatly increases life regen\nEnemies below 50% life have a chance to drop hearts and mana star when struck\nEnemies killed during a Blood Moon have a much higher chance to drop Blood Orbs\nThe radius increases depending on the decrease in the life";
			Mod calamity = ModLoader.GetMod("CalamityMod");
			
			CalamityCompat.CalamityArmorSetBonus(player, "bloodflare");
			player.crimsonRegen = true;
			player.GetModPlayer<ClickerAddonPlayer>().bloodflareCapsuit = true;
		}

		public override void ArmorSetShadows(Player player)
		{
			player.armorEffectDrawShadowSubtle = true;
		}
		/*public override void DrawHair(ref bool drawHair, ref bool drawAltHair)
		{
			drawAltHair = true; 
		}*/
		public override bool DrawHead()
		{
			return false;
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			Mod calamity = ModLoader.GetMod("CalamityMod");

			recipe.AddIngredient(calamity.ItemType("BloodstoneCore"), 11);
			recipe.AddIngredient(calamity.ItemType("RuinousSoul"), 2);
			
			recipe.SetResult(this);
			recipe.AddTile(TileID.LunarCraftingStation);
			recipe.AddRecipe();
		}
	}
}