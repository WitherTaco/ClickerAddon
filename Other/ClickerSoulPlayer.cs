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

namespace ClickerAddon.Other
{
	public partial class ClickerSoulPlayer : ModPlayer
	{
		public void MotherboardEnch(bool IfConfig = true)
		{
			if (ClickerAddonConfigClient.Instance.MotherboardEnch || !IfConfig)
			{
				//player.GetModPlayer<ClickerAddonPlayer>().cloneMotherboard = true;
				ClickerCompat.ClickerClass.GetItem("MotherboardHelmet").UpdateArmorSet(player);
			}
			if (ClickerAddonConfigClient.Instance.StickyKeychain)
			{
				ClickerCompat.EnableClickEffect(player, "ClickerClass:StickyKeychain"); 
			}
		}
		public void OverclockEnch(bool IfConfig = true)
		{
			if (ClickerAddonConfigClient.Instance.OverclockEnch || !IfConfig)
			{
				player.GetModPlayer<ClickerAddonPlayer>().cloneOverclock = true;
				//ClickerCompat.ClickerClass.GetItem("OverclockHelmet").UpdateArmorSet(player);
			}
			if (ClickerAddonConfigClient.Instance.RegalClickingGlove)
			{
				ClickerCompat.SetAccessory(player, "RegalClickingGlove");
			}
		}
		public void PrecursorEnch(bool IfConfig = true)
		{
			if (ClickerAddonConfigClient.Instance.PrecursorEnch || !IfConfig)
			{
				player.GetModPlayer<ClickerAddonPlayer>().clonePrecursor = true;
				//ClickerCompat.ClickerClass.GetItem("PrecursorHelmet").UpdateArmorSet(player);
			}
		}
		public void MiceEnch(bool IfConfig = true)
		{
			if (ClickerAddonConfigClient.Instance.MiceEnch || !IfConfig)
			{
				player.GetModPlayer<ClickerAddonPlayer>().cloneMice = true;
				//ClickerCompat.ClickerClass.GetItem("MiceMask").UpdateArmorSet(player);
			}
		}
		public void ForceOfProgram()
		{
			MotherboardEnch();
			OverclockEnch();
			PrecursorEnch();
			MiceEnch();
		}
		public void AllClickerAcc(bool hideVisual)
		{
			//ClickerCompat.ClickerClass.GetItem("ChocolateMilkCookies").UpdateAccessory(player, hideVisual);
			ClickerCompat.SetAccessory(player, "GlassOfMilk");
			ClickerCompat.SetAccessory(player, "HandCream");
			if (ClickerAddonConfigClient.Instance.Cookie)
			{
				ClickerCompat.SetAccessory(player, "Cookie2"); 
			}
			if (ClickerAddonConfigClient.Instance.ChocolateChip)
			{
				ClickerCompat.EnableClickEffect(player, "ClickerClass:ChocolateChip"); 
			}
			if (ClickerAddonConfigClient.Instance.ShowEnchLED || !hideVisual)
			{
				ClickerCompat.SetAccessory(player, "EnchantedLED");
				ClickerCompat.SetAccessory(player, "EnchantedLED2");
			}
		}
	}
}