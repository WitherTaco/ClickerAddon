using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;

namespace ClickerAddon.Items.Accessories.Vanity
{
	public class MicePillarTest : ModItem
	{
		public override bool Autoload(ref string name)
		{
			return WitherTacoLib.IfMod();
		}
		
		public override void SetStaticDefaults() 
		{
			ClickerCompat.RegisterClickerItem(this);
			//Tooltip.SetDefault("Gain up to move speed based on your amount of clicks within a second");
		}

		public override void SetDefaults() 
		{
			item.width = 32;
			item.height = 32;
			item.value = 0;
			item.rare = ItemRarityID.Gray;
			item.accessory = true;
		}

		public override void UpdateAccessory(Player player, bool hideVisual) 
		{
			ClickerAddonPlayer modPlayer = player.GetModPlayer<ClickerAddonPlayer>();
			/*if (!hideVisual)
			{
				modPlayer.ZoneMiceMonolith = true;
			}
			else
			{
				modPlayer.ZoneTowerMice = true;
			}*/
			modPlayer.ZoneMiceMonolith = true;
		}
	}
}
