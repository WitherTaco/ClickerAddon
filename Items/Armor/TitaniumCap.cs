using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ClickerAddon.Items.Armor
{
	[AutoloadEquip(EquipType.Head)]
	public class TitaniumCap : ModItem
	{
		public override bool Autoload(ref string name)
		{
			return ClickerCompat.ClickerClass != null;
		}
		
		public override void SetStaticDefaults()
		{
			ClickerCompat.RegisterClickerItem(this);
			DisplayName.SetDefault("Titanium Capsuit");
			Tooltip.SetDefault("Increases click damage by 8%"
							+ "\nIncreases your base click radius by 10%");
		}

		public override void SetDefaults()
		{
			item.width = 22;
			item.height = 22;
			item.value = 400;
			item.rare = 4;
			item.defense = 7;
		}

		public override void UpdateEquip(Player player)
		{
			/*player.GetModPlayer<ClickerPlayer>().clickerDamage += 0.08f;
			player.GetModPlayer<ClickerPlayer>().clickerRadius += 0.2f;*/
			ClickerCompat.SetDamageAdd(player, 0.08f);
			ClickerCompat.SetClickerRadiusAdd(player, 0.2f);
		}

		public override bool IsArmorSet(Item head, Item body, Item legs)
		{
			return body.type == 1218 && legs.type == 1219;
		}

		public override void UpdateArmorSet(Player player)
		{
			player.setBonus = "Briefly become invulnerable after striking an enemy";
			player.onHitDodge = true;
			ClickerCompat.EnableClickEffect(player, "ClickerClass:RazorsEdge");
		}

		public override void ArmorSetShadows(Player player)
		{
			player.armorEffectDrawOutlines = true;
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.TitaniumBar, 13);
			recipe.SetResult(this);
			recipe.AddTile(134);
			recipe.AddRecipe();
		}
	}
}