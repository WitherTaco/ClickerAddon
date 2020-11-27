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
		
		[Header("Soul Options")]
		
		[Label("Show Enchanted LED")]
		[Tooltip("True - always show particle"
				+"\nFalse - show if in visual")]
		[DefaultValue(true)]
		public bool ShowEnchLED = true;

	}
}