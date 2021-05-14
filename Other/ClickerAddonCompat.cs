using Terraria;
using Terraria.ModLoader;

namespace ClickerAddon.Other
{
	/// <summary>
	/// Central file used for mod.Call wrappers.
	/// </summary>
	internal static class ClickerAddonCompat
	{
		private static Mod clickerAddon;
		/// <summary>
		///Used for get Clicker Addon Mod info
		/// </summary>
		internal static Mod ClickerAddon
		{
			get
			{
				if (clickerAddon == null)
				{
					clickerAddon = ModLoader.GetMod("ClickerAddon");
				}
				return clickerAddon;
			}
		}
		internal static void Unload()
		{
			clickerAddon = null;
		}
		/// <summary>
		/// Call to set a specific player accessory effect (i.e. to emulate "Wi-fi Kit" you need to have set multiple effects). Supported accessories:
		/// magmaChair, bigRedButton, bandOfClicking, dice
		/// </summary>
		/// <param name="player">The Player</param>
		/// <param name="accessory">Accessory name</param>
		internal static void SetAccessory(Player player, string accessory)
		{
			ClickerAddon?.Call("ClickerAddonStat", player, "SetAccessory", accessory);
		}
		/// <summary>
		/// Call to set a specific player armor effect. Supported armor sets:
		/// reaver, hydrothermic, bloodflare, godslayer, silva (Calamity Only)
		/// </summary>
		/// <param name="player">The Player</param>
		/// <param name="armor">Armor Set name</param>
		internal static void SetArmorSet(Player player, string armor)
		{
			ClickerAddon?.Call("ClickerAddonStat", player, "SetArmorSet", armor);
		}
		/// <summary>
		/// Call to set a specific player other effect. Supported effects:
		/// carbonatedPotion, cheatautoclick
		/// cheatautoclick have a variant with "10" added to increase click rates.
		/// </summary>
		/// <param name="player">The Player</param>
		/// <param name="otherEffect">Other Effect name</param>
		internal static void SetOtherEffect(Player player, string otherEffect)
		{
			ClickerAddon?.Call("ClickerAddonStat", player, "SetOtherEffect", otherEffect);
		}
	}
}