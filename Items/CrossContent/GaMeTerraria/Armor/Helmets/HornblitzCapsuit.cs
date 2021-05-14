using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
//using Redemption;
//using Redemption.Items.Armor.PostML;
//using Redemption.Items;
//using Redemption.Buffs;

namespace ClickerAddon.Items.CrossContent.GaMeTerraria.Armor.Helmets
{
	[AutoloadEquip(EquipType.Head)]
	public class HornblitzCapsuit : ModItem
	{
		public override bool Autoload(ref string name)
		{
			return WitherTacoLib.IfMod("GaMeterraria");
		}

		public override void SetStaticDefaults()
		{
			ClickerCompat.RegisterClickerItem(this);
			//DisplayName.SetDefault("Capsuit of Fallen");
			Tooltip.SetDefault("Increases click damage by 6%");
		}

		public override void SetDefaults()
		{
			item.width = 22;
			item.height = 22;
			item.value = 400;
			item.rare = 3;
			item.defense = 5;
		}

		public override void UpdateEquip(Player player)
		{
			/*player.GetModPlayer<ClickerPlayer>().clickerDamage += 0.06f;
			player.GetModPlayer<ClickerPlayer>().clickerRadius += 0.4f;*/
			ClickerCompat.SetDamageAdd(player, 0.06f);
		}

		public override bool IsArmorSet(Item head, Item body, Item legs)
		{
			Mod game = ModLoader.GetMod("GaMeterraria");
			return body.type == game.ItemType("HornblitzBreastplate") && legs.type == game.ItemType("HornblitzLeggings");
		}

		public override void UpdateArmorSet(Player player)
		{
			player.setBonus = "9% increased click damage, 25% increased movement speed";
			Mod game = ModLoader.GetMod("GaMeterraria");
			//RedePlayer modPlayer = player.GetModPlayer<RedePlayer>();
			
			ClickerCompat.SetDamageAdd(player, 0.09f);
			player.moveSpeed += 0.25f;
		}

		/*public override void ArmorSetShadows(Player player)
		{
			player.armorEffectDrawShadow = true;
			player.armorEffectDrawOutlines = true;
		}*/
		/*public override void DrawHair(ref bool drawHair, ref bool drawAltHair)
		{
			drawAltHair = drawAltHair = true; 
		}*/

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			Mod game = ModLoader.GetMod("GaMeterraria");
			
			recipe.AddIngredient(game.ItemType("HornlitzScale"), 1);
			recipe.AddIngredient(ItemID.SilverHelmet, 1);
			
			recipe.SetResult(this);
			//recipe.AddTile(91);
			recipe.AddRecipe();
			
			recipe = new ModRecipe(mod);
			
			recipe.AddIngredient(game.ItemType("HornlitzScale"), 1);
			recipe.AddIngredient(ItemID.TungstenHelmet, 1);
			
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}