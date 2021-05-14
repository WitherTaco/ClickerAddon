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
using ClickerAddon;
using ClickerAddon.Items.Armor.Gel;

namespace ClickerAddon
{
	public partial class ClickerAddonPlayer : ModPlayer
	{
		public bool clickerCobaltSet = false;
		public bool magmaChair = false;
		public bool autoClicker = false;
		public bool autoClicker10 = false;
		public float[] autoClickerMultiplier = new float[] { 1f, 1f };
		public bool bandOfClicking = false;
		public bool diceEffect = false;
		public bool bigRedButton = false;

		public bool frostCoolerArmor = false;

		public bool daedalusCapsuit = false;
		public bool reaverCapsuit = false;
		public bool ataxiaCapsuit = false;
		public bool bloodflareCapsuit = false;
		public bool godSlayerCapsuit = false;
		public bool silvaCapsuit = false;
		
		public bool cloneOverclock = false;
		public bool clonePrecursor = false;
		public bool cloneMice = false;
		public bool cloneMotherboard = false;
		
		public int clickerAddonTime = 0;
		public int setAbilityDelayTimer = 0;
		public bool ZoneMiceMonolith = false;
		public bool ZoneTowerMice = false;

		public Color lunarColor;
		private static Color[] fragmentColors = { new Color(252, 201, 60), new Color(35, 255, 163), new Color(253, 126, 221), new Color(77, 206, 226), new Color(85, 87, 105) };
		private int lunarColorNum = 0;
		public override void ResetEffects()
		{
			clickerCobaltSet = false;
			magmaChair = false;
			autoClicker = false;
			autoClicker10 = false;
			autoClickerMultiplier = new float[] { 1f, 1f };
			bandOfClicking = false;
			diceEffect = false;
			bigRedButton = false;

			frostCoolerArmor = false;

			daedalusCapsuit = false;
			reaverCapsuit = false;
			ataxiaCapsuit = false;
			bloodflareCapsuit = false;
			godSlayerCapsuit = false;
			silvaCapsuit = false;
			//auricTeslaCapsuit = false;

			cloneOverclock = false;
			clonePrecursor = false;
			cloneMice = false;
			cloneMotherboard = false;

			ZoneMiceMonolith = false;
			ZoneTowerMice = false;
		}
		public override void PostUpdateEquips()
		{
			/*Player player = Main.LocalPlayer;*/
			clickerAddonTime++;
			lunarColor = fragmentColors[lunarColorNum];
			if (bloodflareCapsuit)
			{
				float bloodflareRadius = 0.25f * (player.statLifeMax2 / player.statLife);
				ClickerCompat.SetClickerRadiusAdd(player, bloodflareRadius);
			}
			if(setAbilityDelayTimer > 0)
			{
				setAbilityDelayTimer--;
			}
			
			if(clickerAddonTime >= 60)
			{
				if (lunarColorNum >= 4)
				{
					lunarColorNum = 0;
				}
				else
				{
					lunarColorNum++;
				}
				clickerAddonTime = 0;
			}
			if (bandOfClicking)
			{
				player.accRunSpeed += (float)(ClickerCompat.GetClickerPerSecond(player) * 0.15f);
			}

			if (bigRedButton)
			{
				float fluct = 1f + (float)Math.Sin(2 * Math.PI * (Main.GameUpdateCount % 60) / 60f);
				ClickerCompat.SetClickerRadiusAdd(player, fluct / 2);
			}
		}
		public override void UpdateBiomes()
		{
			ZoneTowerMice = false;
			if (!player.ZoneTowerSolar && !player.ZoneTowerVortex && !player.ZoneTowerNebula && !player.ZoneTowerStardust)
			{
				for (int i = 0; i < Main.maxNPCs; i++)
				{
					var npc = Main.npc[i];
					if (npc != null && npc.active && npc.type == mod.NPCType("MicePillar") && player.Distance(npc.Center) <= 4000f)
					{
						ZoneTowerMice = true;
					}
				}
			}
		}
		public override bool CustomBiomesMatch(Player other)
		{
			var modOther = other.GetModPlayer<ClickerAddonPlayer>();
			return ZoneTowerMice == modOther.ZoneTowerMice;
		}

		public override void CopyCustomBiomesTo(Player other)
		{
			var modOther = other.GetModPlayer<ClickerAddonPlayer>();
			modOther.ZoneTowerMice = ZoneTowerMice;
		}
		public override void UpdateBiomeVisuals()
		{
			bool useMice = ZoneTowerMice || ZoneMiceMonolith;
			player.ManageSpecialBiomeVisuals("ClickerAddon:Mice", useMice);

			//player.ManageSpecialBiomeVisuals("ClickerAddon:Mice", ZoneMiceMonolith);
		}
	}
}