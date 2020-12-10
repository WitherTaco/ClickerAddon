using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ClickerAddon.Items.Armor
{
	[AutoloadEquip(EquipType.Head)]
	public class HallowedCap : ModItem
	{
		public override bool Autoload(ref string name)
		{
			return ClickerCompat.ClickerClass != null;
		}
		
		public override void SetStaticDefaults()
		{
			ClickerCompat.RegisterClickerItem(this);
			DisplayName.SetDefault("Hallowed Capsuit");
			Tooltip.SetDefault("Increases click damage by 12%"
							+ "\nIncreases your base click radius by 20%");
		}

		public override void SetDefaults()
		{
			item.width = 22;
			item.height = 22;
			item.value = 400;
			item.rare = 4;
			item.defense = 10;
		}

		public override void UpdateEquip(Player player)
		{
			/*player.GetModPlayer<ClickerPlayer>().clickerDamage += 0.12f;
			player.GetModPlayer<ClickerPlayer>().clickerRadius += 0.4f;*/
			ClickerCompat.SetDamageAdd(player, 0.12f);
			ClickerCompat.SetClickerRadiusAdd(player, 0.4f);
		}

		public override bool IsArmorSet(Item head, Item body, Item legs)
		{
			return body.type == 551 && legs.type == 552;
		}

		public override void UpdateArmorSet(Player player)
		{
			player.setBonus = "Increases click critical strike chance by 6%";
			/*player.GetModPlayer<ClickerPlayer>().clickerCrit += 6;*/
			ClickerCompat.SetClickerCritAdd(player, 6);
			ClickerCompat.EnableClickEffect(player, "ClickerClass:HolyNova");
		}

		public override void ArmorSetShadows(Player player)
		{
			player.armorEffectDrawOutlines = true;
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.HallowedBar, 12);
			recipe.SetResult(this);
			recipe.AddTile(134);
			recipe.AddRecipe();
		}
	}
}