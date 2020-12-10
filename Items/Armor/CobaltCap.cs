using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ClickerAddon.Items.Armor
{
	[AutoloadEquip(EquipType.Head)]
	public class CobaltCap : ModItem
	{
		public override bool Autoload(ref string name)
		{
			return ClickerCompat.ClickerClass != null;
		}
		
		public override void SetStaticDefaults()
		{
			ClickerCompat.RegisterClickerItem(this);
			DisplayName.SetDefault("Cobalt Capsuit");
			Tooltip.SetDefault("Increases click damage by 4%"
							+ "\nIncreases your base click radius by 20%");
		}

		public override void SetDefaults()
		{
			item.width = 22;
			item.height = 22;
			item.value = 400;
			item.rare = 4;
			item.defense = 6;
		}

		public override void UpdateEquip(Player player)
		{
			/*player.GetModPlayer<ClickerPlayer>().clickerDamage += 0.04f;
			player.GetModPlayer<ClickerPlayer>().clickerRadius += 0.4f;*/
			ClickerCompat.SetDamageAdd(player, 0.04f);
			ClickerCompat.SetClickerRadiusAdd(player, 0.4f);
		}

		public override bool IsArmorSet(Item head, Item body, Item legs)
		{
			return body.type == 374 && legs.type == 375;
		}

		public override void UpdateArmorSet(Player player)
		{
			player.setBonus = "Every 5 clicks to get buff 'Haste'";
			//player.GetModPlayer<ClickerAddonPlayer>().clickerCobaltSet = true;
			ClickerCompat.EnableClickEffect(player, "ClickerClass:Haste");
		}

		public override void ArmorSetShadows(Player player)
		{
			player.armorEffectDrawOutlines = true;
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.CobaltBar, 10);
			recipe.SetResult(this);
			recipe.AddTile(16);
			recipe.AddRecipe();
		}
	}
}