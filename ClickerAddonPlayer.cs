using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using Terraria;
using Terraria.ModLoader;
using Terraria.ModLoader.IO;
using Terraria.ID;
using Terraria.DataStructures;
using Terraria.GameInput;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace ClickerAddon
{
	public partial class ClickerAddonPlayer : ModPlayer
	{
		public bool clickerCobaltSet = false;
		public bool magmaChair = false;
		
		public bool cloneOverclock = false;
		public bool clonePrecursor = false;
		public bool cloneMice = false;
		public bool cloneMotherboard = false;
		
		private int clickerAddonTime = 0;
		
		public override void ResetEffects()
		{
			clickerCobaltSet = false;
			magmaChair = false;
			
			cloneOverclock = false;
			clonePrecursor = false;
			cloneMice = false;
			cloneMotherboard = false;
			
			clickerAddonTime = 0;
		}
		public override void PostUpdateEquips()
		{
			/*Player player = Main.LocalPlayer;*/
			clickerAddonTime++;
			
			if(clickerAddonTime >= 60)
			{
				
			}
		}
	}
}