using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using ClickerAddon.Other;

namespace ClickerAddon.Items.CrossContent.Calamity.Armor.Helmets
{
	[AutoloadEquip(EquipType.Head)]
	public class SilvaCapsuit : ModItem
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
							+ "\n13% increased clicker damage and crit"
							+ "\n50% increased clicker radius"
							+ "\n10% reduces the amount of clicks required for a click effect");
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
			return body.type == calamity.ItemType("SilvaArmor") && legs.type == calamity.ItemType("SilvaLeggings");
		}

		public override void UpdateArmorSet(Player player)
		{
			player.setBonus = "All projectiles spawn healing leaf orbs on enemy hits\nMax run speed and acceleration boosted by 5%\nIf you are reduced to 1 HP you will not die from any further damage for 10 seconds\nIf you get reduced to 1 HP again while this effect is active you will lose 100 max life\nThis effect only triggers once per life and if you are reduced to 400 max life the invincibility effect will stop\nYour max life will return to normal if you die\nAdd a auto click on all Clickers then click rates are low decreased";
			Mod calamity = ModLoader.GetMod("CalamityMod");
			
			CalamityCompat.CalamityArmorSetBonus(player, "silva");
			player.GetModPlayer<ClickerAddonPlayer>().silvaCapsuit = true;
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

			recipe.AddIngredient(calamity.ItemType("DarksunFragment"), 5);
			recipe.AddIngredient(calamity.ItemType("EffulgentFeather"), 5);
			recipe.AddRecipeGroup("ClickerAddon:AnyGoldBar", 5);
			recipe.AddIngredient(calamity.ItemType("Tenebris"), 6);
			recipe.AddIngredient(calamity.ItemType("AscendantSpiritEssence"), 2);

			recipe.SetResult(this);
			recipe.AddTile(calamity.TileType("DraedonsForge"));
			recipe.AddRecipe();
		}
	}
}