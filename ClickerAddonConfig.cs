using System.ComponentModel;
using System.Runtime.Serialization;
using Terraria;
using Terraria.ModLoader.Config;

namespace ClickerAddon
{
	[Label("Configuration")]
	public class ClickerAddonConfigClient : ModConfig
	{
		public override ConfigScope Mode => ConfigScope.ClientSide;
		public static ClickerAddonConfigClient Instance;
		
		[Header("Force of Programm")]
		//Enchantment
		[Label("[c/5960DB:Mice Enchantment]")]
		[Tooltip("Conflicts with Motherboard Enchantment")]
		[DefaultValue(false)]
		public bool MiceEnch;

		[Label("[c/CC651A:Precursor Enchantment]")]
		[DefaultValue(true)]
		public bool PrecursorEnch;

		[Label("[c/DF3333:Overclock Enchantment]")]
		[DefaultValue(true)]
		public bool OverclockEnch;

		[Label("[c/DF3333:Regal Clicking Glove]")]
		[DefaultValue(true)]
		public bool RegalClickingGlove;

		[Label("[c/AEC3D7:Motherboard Enchantment]")]
		[Tooltip("Conflicts with Mice Enchantment")]
		[DefaultValue(true)]
		public bool MotherboardEnch;

		[Label("[c/AEC3D7:Sticky Keychain]")]
		[DefaultValue(true)]
		public bool StickyKeychain;


		[Header("Computer Soul")]
		//Acc
		[Label("Show Enchanted LED")]
		[Tooltip("True - always show particle"
				+ "\nFalse - show if in visual")]
		[DefaultValue(false)]
		public bool ShowEnchLED;

		[Label("Cookie")]
		[DefaultValue(true)]
		public bool Cookie;

		[Label("Chocolate Chip")]
		[DefaultValue(true)]
		public bool ChocolateChip;


		[Header("Other Config")]

		[Label("Auto Clicker Multiplier")]
		[Tooltip("Only for Configurable Auto Clicker")]
		[DefaultValue(1f)]
		[Range(1f, 15f)]
		public float AutoClickerMultiplier;
	}
}