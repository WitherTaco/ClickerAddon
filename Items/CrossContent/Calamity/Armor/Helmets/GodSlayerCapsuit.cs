using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using ClickerAddon.Other;

namespace ClickerAddon.Items.CrossContent.Calamity.Armor.Helmets
{
	[AutoloadEquip(EquipType.Head)]
	public class GodSlayerCapsuit : ModItem
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
							+ "\n14% increased clicker damage and crit"
							+ "\n45% increased clicker radius"
							+ "\n1 reduces the amount of clicks required for a click effect");
		}

		public override void SetDefaults()
		{
			item.width = 27;
			item.height = 22;
			item.value = Item.buyPrice(gold: 75);
			CalamityCompat.SetCalamityRarity(item, CalamityCompat.CalamityRarity.DarkBlue);
			item.defense = 34;
		}

		public override void UpdateEquip(Player player)
		{
			ClickerCompat.SetDamageAdd(player, 0.14f);
			ClickerCompat.SetClickerCritAdd(player, 14);
			ClickerCompat.SetClickerRadiusAdd(player, WitherTacoLib.Math.Radius(0.45f));
			ClickerCompat.SetClickerBonusAdd(player, 1);
		}

		public override bool IsArmorSet(Item head, Item body, Item legs)
		{
			Mod calamity = ModLoader.GetMod("CalamityMod");
			return body.type == calamity.ItemType("GodSlayerChestplate") && legs.type == calamity.ItemType("GodSlayerLeggings");
		}

		public override void UpdateArmorSet(Player player)
		{
			player.setBonus = "You will survive fatal damage and will be healed 150 HP if an attack would have killed you\nThis effect can only occur once every 45 seconds\nWhile the cooldown for this effect is active all life regen is halved\nWhen you click there is a chance that there will be shoot nebula stars";
			Mod calamity = ModLoader.GetMod("CalamityMod");
			
			CalamityCompat.CalamityArmorSetBonus(player, "godslayer");
			player.GetModPlayer<ClickerAddonPlayer>().godSlayerCapsuit = true;
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

			recipe.AddIngredient(calamity.ItemType("CosmiliteBar"), 14);
			recipe.AddIngredient(calamity.ItemType("AscendantSpiritEssence"));
			
			recipe.SetResult(this);
			recipe.AddTile(calamity.TileType("DraedonsForge"));
			recipe.AddRecipe();
		}
	}
}