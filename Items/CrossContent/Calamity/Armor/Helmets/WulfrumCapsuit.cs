using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ClickerAddon.Items.CrossContent.Calamity.Armor.Helmets
{
	[AutoloadEquip(EquipType.Head)]
	public class WulfrumCapsuit : ModItem
	{
		public override bool Autoload(ref string name)
		{
			return WitherTacoLib.IfMod("CalamityMod");
		}

		public override void SetStaticDefaults()
		{
			ClickerCompat.RegisterClickerItem(this);
			//DisplayName.SetDefault("Capsuit of Fallen");
			Tooltip.SetDefault("3% increased clicker damage");
		}

		public override void SetDefaults()
		{
			item.width = 22;
			item.height = 22;
			item.value = Item.sellPrice(silver: 75);
			item.rare = ItemRarityID.White;
			item.defense = 1;
		}

		public override void UpdateEquip(Player player)
		{
			ClickerCompat.SetDamageAdd(player, 0.03f);
			//ClickerCompat.SetClickerCritAdd(player, 6);
			//ClickerCompat.SetClickerRadiusAdd(player, WitherTacoLib.Math.Radius(0.15f));
		}

		public override bool IsArmorSet(Item head, Item body, Item legs)
		{
			Mod calamity = ModLoader.GetMod("CalamityMod");
			return body.type == calamity.ItemType("WulfrumArmor") && legs.type == calamity.ItemType("WulfrumLeggings");
		}

		public override void UpdateArmorSet(Player player)
		{
			player.setBonus = "+3 defense\n+5 defense when below 50% life";
			Mod calamity = ModLoader.GetMod("CalamityMod");
			//CalamityPlayer modPlayer = player.GetModPlayer<CalamityPlayer>();

			player.statDefense += 3;
			if(player.statLife > (int)(player.statLifeMax2 * 0.5))
			{
				player.statDefense += 5;
			}
		}
		/*public override void DrawHair(ref bool drawHair, ref bool drawAltHair)
		{
			drawAltHair = true; 
		}*/

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			Mod calamity = ModLoader.GetMod("CalamityMod");

			recipe.AddIngredient(calamity.ItemType("WulfrumShard"), 5); 
			recipe.AddIngredient(calamity.ItemType("EnergyCore"));

			recipe.SetResult(this);
			recipe.AddTile(TileID.Anvils);
			recipe.AddRecipe();
		}
	}
}