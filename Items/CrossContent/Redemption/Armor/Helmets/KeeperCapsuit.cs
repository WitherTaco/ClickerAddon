using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
//using Redemption;
//using Redemption.Items.Armor.PostML;
//using Redemption.Items;
//using Redemption.Buffs;

namespace ClickerAddon.Items.CrossContent.Redemption.Armor.Helmets
{
	[AutoloadEquip(EquipType.Head)]
	public class KeeperCapsuit : ModItem
	{
		public override bool Autoload(ref string name)
		{
			return WitherTacoLib.IfMod("Redemption");
		}

		public override void SetStaticDefaults()
		{
			ClickerCompat.RegisterClickerItem(this);
			DisplayName.SetDefault("Capsuit of Fallen");
			Tooltip.SetDefault("Increases click damage by 8%"
							+ "\nIncreases click crit by 6%"
							+ "\nIncreases your base click radius by 25%");
		}

		public override void SetDefaults()
		{
			item.width = 22;
			item.height = 22;
			item.value = 400;
			item.rare = 3;
			item.defense = 14;
		}

		public override void UpdateEquip(Player player)
		{
			/*player.GetModPlayer<ClickerPlayer>().clickerDamage += 0.06f;
			player.GetModPlayer<ClickerPlayer>().clickerRadius += 0.4f;*/
			ClickerCompat.SetDamageAdd(player, 0.08f);
			ClickerCompat.SetClickerCritAdd(player, 6);
			ClickerCompat.SetClickerRadiusAdd(player, WitherTacoLib.Math.Radius(0.25f));
		}

		public override bool IsArmorSet(Item head, Item body, Item legs)
		{
			Mod redemption = ModLoader.GetMod("Redemption");
			return body.type == redemption.ItemType("KeepersChestplate") && legs.type == redemption.ItemType("KeepersLeggings");
		}

		public override void UpdateArmorSet(Player player)
		{
			player.setBonus = "10% reduces the amount of clicks required for a click effect";
			Mod redemption = ModLoader.GetMod("Redemption");
			//RedePlayer modPlayer = player.GetModPlayer<RedePlayer>();
			
			ClickerCompat.SetClickerBonusPercentAdd(player, (float)(0.1f * -1));
			//ClickerCompat.EnableClickEffect(player, "ClickerClass:Curse");
		}

		/*public override void ArmorSetShadows(Player player)
		{
			player.armorEffectDrawShadow = true;
			player.armorEffectDrawOutlines = true;
		}*/
		public override void DrawHair(ref bool drawHair, ref bool drawAltHair)
		{
			drawAltHair = true; 
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			Mod redemption = ModLoader.GetMod("Redemption");
			
			recipe.AddIngredient(redemption.ItemType("DarkShard"), 1);
			recipe.AddIngredient(redemption.ItemType("SmallLostSoul"), 4);
			
			recipe.SetResult(this);
			recipe.AddTile(16);
			recipe.AddRecipe();
		}
	}
}