using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;

namespace ClickerAddon.Items.CheatItem
{
	public class AutoClicker10 : ModItem
	{
		public override bool Autoload(ref string name)
		{
			return WitherTacoLib.IfMod();
		}
		
		public override void SetStaticDefaults() 
		{
			ClickerCompat.RegisterClickerItem(this);
			DisplayName.SetDefault("Auto Clicker 10x");
			Tooltip.SetDefault("[c/FF0000:CHEAT ONLY]"
							+ "\nYour clickers have auto attack"
							+ "\n'I am speed'");
		}

		public override void SetDefaults() 
		{
			item.width = 32;
			item.height = 32;
			item.value = 0;
			item.rare = ItemRarityID.Expert;
			item.accessory = true;
		}

		public override void UpdateAccessory(Player player, bool hideVisual) 
		{
			player.GetModPlayer<ClickerAddonPlayer>().autoClicker = true;
			//player.GetModPlayer<ClickerAddonPlayer>().autoClicker10 = true;
			player.GetModPlayer<ClickerAddonPlayer>().autoClickerMultiplier = new float[] { 0.1f, 10f };
		}
	}
}
