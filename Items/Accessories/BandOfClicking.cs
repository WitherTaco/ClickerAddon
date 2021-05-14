using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;

namespace ClickerAddon.Items.Accessories
{
	public class BandOfClicking : ModItem
	{
		public override bool Autoload(ref string name)
		{
			return WitherTacoLib.IfMod();
		}
		
		public override void SetStaticDefaults() 
		{
			ClickerCompat.RegisterClickerItem(this);
			Tooltip.SetDefault("Gain up to move speed based on your amount of clicks within a second");
		}

		public override void SetDefaults() 
		{
			item.width = 32;
			item.height = 32;
			item.value = 50000;
			item.rare = ItemRarityID.Orange;
			item.accessory = true;
		}

		public override void UpdateAccessory(Player player, bool hideVisual) 
		{
			//player.GetModPlayer<ClickerAddonPlayer>().gamerBoots = true;
			//player.moveSpeed += (float)(ClickerCompat.GetClickerPerSecond(player) * 0.2f);
			player.GetModPlayer<ClickerAddonPlayer>().bandOfClicking = true;
		}
	}
}
