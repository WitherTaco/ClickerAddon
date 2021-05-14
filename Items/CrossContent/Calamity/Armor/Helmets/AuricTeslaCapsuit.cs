using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using ClickerAddon.Other;

namespace ClickerAddon.Items.CrossContent.Calamity.Armor.Helmets
{
	[AutoloadEquip(EquipType.Head)]
	public class AuricTeslaCapsuit : ModItem
	{
		public override bool Autoload(ref string name)
		{
			return WitherTacoLib.IfMod("CalamityMod");
		}

		public override void SetStaticDefaults()
		{
			ClickerCompat.RegisterClickerItem(this);
			//DisplayName.SetDefault("Bloodflare Crimera Capsuit");
			Tooltip.SetDefault("You can move freely through liquids and have temporary immunity to lava"
							+ "\n20% increased clicker damage and crit"
							+ "\n60% increased clicker radius"
							+ "\n15% reduces the amount of clicks required for a click effect"
							+ "\nNot moving boosts all damage and critical strike chance");
		}

		public override void SetDefaults()
		{
			item.width = 27;
			item.height = 22;
			item.value = Item.buyPrice(gold: 90);
			CalamityCompat.SetCalamityRarity(item, CalamityCompat.CalamityRarity.Violet);
			item.defense = 38;
		}

		public override void UpdateEquip(Player player)
		{
			ClickerCompat.SetDamageAdd(player, 0.13f);
			ClickerCompat.SetClickerCritAdd(player, 13);
			ClickerCompat.SetClickerRadiusAdd(player, WitherTacoLib.Math.Radius(0.5f));
			ClickerCompat.SetClickerBonusPercentAdd(player, 0.1f);
		}

		public override bool IsArmorSet(Item head, Item body, Item legs)
		{
			Mod calamity = ModLoader.GetMod("CalamityMod");
			return body.type == calamity.ItemType("AuricTeslaBodyArmor") && legs.type == calamity.ItemType("AuricTeslaCuisses");
		}

		public override void UpdateArmorSet(Player player)
		{
			player.setBonus = "Clicker Tarragon, Bloodflare, God Slayer, and Silva armor effects\n30% increased clicker damage and crit";
			Mod calamity = ModLoader.GetMod("CalamityMod");

			ClickerCompat.SetDamageAdd(player, 0.30f);
			ClickerCompat.SetClickerCritAdd(player, 30);

			CalamityCompat.CalamityArmorSetBonus(player, "tarragon");

			CalamityCompat.CalamityArmorSetBonus(player, "bloodflare");
			player.crimsonRegen = true;
			player.GetModPlayer<ClickerAddonPlayer>().bloodflareCapsuit = true;
			player.lavaMax += 240;
			player.ignoreWater = true;

			CalamityCompat.CalamityArmorSetBonus(player, "godslayer");
			player.GetModPlayer<ClickerAddonPlayer>().godSlayerCapsuit = true;

			CalamityCompat.CalamityArmorSetBonus(player, "silva");
			player.GetModPlayer<ClickerAddonPlayer>().silvaCapsuit = true;

			CalamityCompat.CalamityArmorSetBonus(player, "auric");
			player.thorns += 3f;
			if (player.lavaWet)
			{
				player.statDefense += 30;
				player.lifeRegen += 10;
			}
		}

		public override void ArmorSetShadows(Player player)
		{
			player.armorEffectDrawShadow = true;
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

			recipe.AddIngredient(mod.ItemType("TarragonCapsuit"));
			recipe.AddIngredient(mod.ItemType("BloodflareCapsuit"));
			recipe.AddIngredient(mod.ItemType("GodSlayerCapsuit"));
			recipe.AddIngredient(mod.ItemType("SilvaCapsuit"));

			recipe.AddIngredient(calamity.ItemType("AuricBar"), 10);
			recipe.AddIngredient(calamity.ItemType("PsychoticAmulet"));

			recipe.SetResult(this);
			recipe.AddTile(calamity.TileType("DraedonsForge"));
			recipe.AddRecipe();
		}
	}
}