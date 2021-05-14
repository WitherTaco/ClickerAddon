using Terraria;
using Terraria.ModLoader;

namespace ClickerAddon.Other
{
	internal static class CalamityCompat
	{
		private static Mod calamity;
		/// <summary>
		///Used for get Calamity Mod info
		/// </summary>
		internal static Mod Calamity
		{
			get
			{
				if (calamity == null)
				{
					calamity = ModLoader.GetMod("CalamityMod");
				}
				return calamity;
			}
		}
		internal static void Unload()
		{
			calamity = null;
		}
		/// <summary>
		///Calamity Mod rarity list
		/// </summary>
		public class CalamityRarity
		{
			public static int ItemSpecific = -1;
			public static int NoEffect = 0;
			public static int Turquoise = 12;
			public static int PureGreen = 13;
			public static int DarkBlue = 14;
			public static int Violet = 15;
			public static int Developer = 16;
			public static int Rainbow = 30;
			public static int RareVariant = 31;
			public static int Dedicated = 32;
			public static int DraedonRust = 33;
		}
		internal static void CalamityArmorSetBonus(Player player, string name)
		{
			Calamity?.Call(new object[4]
			{
				(object) "SetSetBonus",
				(object) player,
				(object) name,
				(object) true
			});
		}
		/// <summary>
		/// Call to add to the players' rogue damage value in %
		/// </summary>
		/// <param name="player">The player</param>
		/// <param name="add">damage added in %</param>
		internal static void SetRogueDamageAdd(Player player, float add)
		{
			Calamity?.Call(new object[3]
			{
				(object) "AddRogueDamage",
				(object) player,
				(object) add
			});
		}
		/// <summary>
		/// Call to add to the players' rogue crit value
		/// </summary>
		/// <param name="player">The player</param>
		/// <param name="add">crit chance added</param>
		internal static void SetRogueCritAdd(Player player, int add)
		{
			Calamity?.Call(new object[3]
			{
				(object) "AddRogueCrit",
				(object) player,
				(object) add
			});
		}
		/// <summary>
		/// Call to add to the players' rogue velocity value in %
		/// </summary>
		/// <param name="player">The player</param>
		/// <param name="add">velocity added in %</param>
		internal static void SetRogueVelocityAdd(Player player, float add)
		{
			Calamity?.Call(new object[3]
			{
				(object) "AddRogueVelocity",
				(object) player,
				(object) add
			});
		}
		/// <summary>
		/// Call to set item rariry from Calamity
		/// </summary>
		/// /// <param name="item">The item</param>
		/// <param name="rariryNum">Calamity rariry number</param>
		internal static void SetCalamityRarity(Item item, int rariryNum)
		{
			Calamity?.Call(new object[3] 
				{
					"SetCalamityRarity",
					item,
					rariryNum
				}
			);
		}
	}
}