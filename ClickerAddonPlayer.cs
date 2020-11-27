using Microsoft.Xna.Framework;
using System;
using Terraria;
using Terraria.ModLoader;

namespace ClickerAddon
{
	public partial class ClickerAddonPlayer : ModPlayer
	{
		private static Player player = Main.LocalPlayer;
		
		public bool clickerCobaltSet = false;
		public bool gamerBoots = false;
		public bool magmaChair = false;
		
		private int clickerAddonTime = 0;
		private int pastClickerTotel = 0;
		public int clicksPerClicks = 0;
		
		public override void ResetEffects()
		{
			clickerCobaltSet = false;
			gamerBoots = false;
			magmaChair = false;
			
			clickerAddonTime = 0;
			pastClickerTotel = 0;
			clicksPerClicks = 0;
		}
		public override void PostUpdateEquips()
		{
			/*Player player = Main.LocalPlayer;*/
			clickerAddonTime++;
			
			if(clickerAddonTime >= 60)
			{
				clicksPerClicks = ClickerCompat.GetClickAmount(player) - pastClickerTotel; 
				pastClickerTotel = ClickerCompat.GetClickAmount(player);
			}
			if(gamerBoots)
			{
				player.moveSpeed += (float)(clicksPerClicks * 0.15f);
			}
		}
	}
}