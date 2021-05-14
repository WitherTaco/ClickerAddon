using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;

namespace ClickerAddon.Items.CheatItem
{
	public class AutoClickBuff : ModItem
	{
		public override bool Autoload(ref string name)
		{
			return WitherTacoLib.IfMod();
		}
		
		public override void SetStaticDefaults() 
		{
			ClickerCompat.RegisterClickerItem(this);
			Tooltip.SetDefault("[c/FF0000:CHEAT ONLY]"
							+ "\nAdd a buff 'Auto Click'");
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
			//player.GetModPlayer<ClickerAddonPlayer>().autoClickerCheat = true;
			Mod clickerClass = ModLoader.GetMod("ClickerClass");

			player.AddBuff(clickerClass.BuffType("AutoClick"), 2, true);
			
		}
	}
}
