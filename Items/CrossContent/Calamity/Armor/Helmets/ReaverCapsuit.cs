using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using ClickerAddon.Other;

namespace ClickerAddon.Items.CrossContent.Calamity.Armor.Helmets
{
	[AutoloadEquip(EquipType.Head)]
	public class ReaverCapsuit : ModItem
	{
		public override bool Autoload(ref string name)
		{
			return WitherTacoLib.IfMod("CalamityMod");
		}

		public override void SetStaticDefaults()
		{
			ClickerCompat.RegisterClickerItem(this);
			//DisplayName.SetDefault("Capsuit of Fallen");
			Tooltip.SetDefault("15% increased clicker damage"
							+ "\n5% increased clicker crit"
							+ "\n45% increased clicker radius");
		}

		public override void SetDefaults()
		{
			item.width = 22;
			item.height = 22;
			item.value = Item.buyPrice(gold: 30);
			item.rare = ItemRarityID.Lime;
			item.defense = 18;
		}

		public override void UpdateEquip(Player player)
		{
			ClickerCompat.SetDamageAdd(player, 0.15f);
			ClickerCompat.SetClickerCritAdd(player, 5);
			ClickerCompat.SetClickerRadiusAdd(player, WitherTacoLib.Math.Radius(0.45f));
		}

		public override bool IsArmorSet(Item head, Item body, Item legs)
		{
			Mod calamity = ModLoader.GetMod("CalamityMod");
			return body.type == calamity.ItemType("ReaverScaleMail") && legs.type == calamity.ItemType("ReaverCuisses");
		}

		public override void UpdateArmorSet(Player player)
		{
			player.setBonus = "5% increased clicker damage\nWhen you click there is a chance that there will be shoot spores";
			Mod calamity = ModLoader.GetMod("CalamityMod");
			
			ClickerCompat.SetDamageAdd(player, 0.05f);
			player.GetModPlayer<ClickerAddonPlayer>().reaverCapsuit = true;
		}

		public override void ArmorSetShadows(Player player)
		{
			player.armorEffectDrawShadow = true;
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

			recipe.AddIngredient(calamity.ItemType("DraedonBar"), 8);
			recipe.AddIngredient(ItemID.JungleSpores, 6);
			recipe.AddIngredient(calamity.ItemType("EssenceofCinder"), 1);
			
			recipe.SetResult(this);
			recipe.AddTile(TileID.MythrilAnvil);
			recipe.AddRecipe();
		}
	}
}