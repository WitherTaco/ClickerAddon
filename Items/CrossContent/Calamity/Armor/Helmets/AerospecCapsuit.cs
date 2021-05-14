using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using ClickerAddon.Other;

namespace ClickerAddon.Items.CrossContent.Calamity.Armor.Helmets
{
	[AutoloadEquip(EquipType.Head)]
	public class AerospecCapsuit : ModItem
	{
		public override bool Autoload(ref string name)
		{
			return WitherTacoLib.IfMod("CalamityMod");
		}

		public override void SetStaticDefaults()
		{
			ClickerCompat.RegisterClickerItem(this);
			//DisplayName.SetDefault("Capsuit of Fallen");
			Tooltip.SetDefault("8% increased clicker damage"
							+ "\n15% increased clicker radius");
		}

		public override void SetDefaults()
		{
			item.width = 22;
			item.height = 22;
			item.value = Item.buyPrice(gold: 5);
			item.rare = ItemRarityID.Orange;
			item.defense = 5;
		}

		public override void UpdateEquip(Player player)
		{
			ClickerCompat.SetDamageAdd(player, 0.08f);
			//ClickerCompat.SetClickerCritAdd(player, 6);
			ClickerCompat.SetClickerRadiusAdd(player, WitherTacoLib.Math.Radius(0.15f));
		}

		public override bool IsArmorSet(Item head, Item body, Item legs)
		{
			Mod calamity = ModLoader.GetMod("CalamityMod");
			return body.type == calamity.ItemType("AerospecBreastplate") && legs.type == calamity.ItemType("AerospecLeggings");
		}

		public override void UpdateArmorSet(Player player)
		{
			player.setBonus = "5% increased movement speed and click critical strike chance\nTaking over 25 damage in one hit will cause a spread of homing feathers to fall\nAllows you to fall more quickly and disables fall damage";
			Mod calamity = ModLoader.GetMod("CalamityMod");
			
			CalamityCompat.CalamityArmorSetBonus(player, "aerospec");
			ClickerCompat.SetClickerCritAdd(player, 5);
			player.moveSpeed += 0.05f;
			player.noFallDmg = true;
		}

		public override void ArmorSetShadows(Player player)
		{
			player.armorEffectDrawShadow = true;
		}
		public override void DrawHair(ref bool drawHair, ref bool drawAltHair)
		{
			drawAltHair = true; 
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			Mod calamity = ModLoader.GetMod("CalamityMod");

			//recipe.AddIngredient(redemption.ItemType("DarkShard"), 1);
			//recipe.AddIngredient(redemption.ItemType("SmallLostSoul"), 4);

			recipe.AddIngredient(calamity.ItemType("AerialiteBar"), 5);
			recipe.AddIngredient(ItemID.Cloud, 3);
			recipe.AddIngredient(ItemID.RainCloud, 1);
			recipe.AddIngredient(ItemID.Feather, 1);
			
			recipe.SetResult(this);
			recipe.AddTile(TileID.SkyMill);
			recipe.AddRecipe();
		}
	}
}