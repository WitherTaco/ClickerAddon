using System.Collections.Generic;
using Terraria.ModLoader;
using ClickerAddon.Other;
using ClickerAddon.Items.Weapons.Clickers;
using ClickerAddon.Items.CrossContent.Redemption.Weapons.Clickers;
using Terraria;
using System;
using Terraria.ID;
using Terraria.GameContent.UI;
using ClickerAddon.Items.CrossContent;
using ClickerAddon.Items.CrossContent.SoA;
using ClickerAddon.NPCs.Bosses;
using Terraria.Graphics.Effects;
using Terraria.UI;

namespace ClickerAddon
{
	//TODO for developers:
	//Add some projectile example
	public class ClickerAddon : Mod
	{
		internal static ClickerAddon mod;
		public static int LunarCoinCloneID;
		public override void Load()
		{
			mod = this;
			ClickerCompat.Load();
			if(ModLoader.GetMod("SacredTools") != null)
				LunarCoinCloneID = CustomCurrencyManager.RegisterCurrency( (CustomCurrencySystem) new LunarCoinClone(ModLoader.GetMod("SacredTools").ItemType("LunarCoin"), 999L) );

			if (!Main.dedServ)
			{
				MiceSky.PlanetTexture = GetTexture("NPCs/Bosses/MicePlanet");
				Filters.Scene["ClickerAddon:Mice"] = new Filter(new MiceData("FilterMiniTower").UseColor(0.45f, 0.5f, 0.85f).UseOpacity(0.82f), EffectPriority.VeryHigh);
				SkyManager.Instance["ClickerAddon:Mice"] = new MiceSky();
			}
			ClickerClassGlobalItemStats.astralArmor = new bool[3] { false, false, false };
		}

		public override void Unload()
		{
			mod = null;
			ClickerCompat.Unload();
			CalamityCompat.Unload();
			ClickerAddonCompat.Unload();
		}
		public override void PostSetupContent()
		{
			Mod bossChecklist = ModLoader.GetMod("BossChecklist");
			Mod clickerClass = ModLoader.GetMod("ClickerClass");

			if (bossChecklist != null)
			{
				bossChecklist.Call(
					"AddToBossLoot",
					"Terraria",
					"KingSlime",
					new List<int>() {
						clickerClass.ItemType("StickyKeychain")
					}
				);
				bossChecklist.Call(
					"AddToBossLoot", 
					"Terraria", 
					"Pumpking",
					new List<int>() { 
						clickerClass.ItemType("WitchClicker") 
					}
				);
				bossChecklist.Call(
					"AddToBossLoot",
					"Terraria",
					"IceQueen",
					new List<int>() {
						clickerClass.ItemType("FrozenClicker")
					}
				);
				bossChecklist.Call(
					"AddToBossLoot",
					"Terraria",
					"MartianSaucer",
					new List<int>() {
						clickerClass.ItemType("HighTechClicker")
					}
				);
				bossChecklist.Call(
					"AddToBossLoot",
					"Terraria",
					"MoonLord",
					new List<int>() {
						clickerClass.ItemType("LordsClicker"),
						clickerClass.ItemType("TheClicker")
					}
				);
				bossChecklist.Call(
					"AddToBossLoot",
					"Terraria",
					"DukeFishron",
					new List<int>() {
						ModContent.ItemType<FishronsClicker>()
					}
				);
				bossChecklist.Call(
					"AddToBossLoot",
					"Terraria",
					"QueenBee",
					new List<int>() {
						ModContent.ItemType<BeeClicker>()
					}
				);
				bossChecklist.Call(
					"AddToBossLoot",
					"Redemption",
					"Thorn, Bane of the Forest",
					new List<int>() {
						ModContent.ItemType<CursedRootClicker>()
					}
				);


				bossChecklist.Call(
					"AddToBossLoot",
					"Terraria",
					"Pumpkin Moon",
					new List<int>() {
						clickerClass.ItemType("WitchClicker")
					}
				);
				bossChecklist.Call(
					"AddToBossLoot",
					"Terraria",
					"Frost Moon",
					new List<int>() {
						clickerClass.ItemType("FrozenClicker")
					}
				);
				bossChecklist.Call(
					"AddToBossLoot",
					"Terraria",
					"Blood Moon",
					new List<int>() {
						clickerClass.ItemType("HemoClicker")
					}
				);
				bossChecklist.Call(
					"AddToBossLoot",
					"Terraria",
					"Goblin Army",
					new List<int>() {
						clickerClass.ItemType("ShadowyClicker")
					}
				);
				bossChecklist.Call(
					"AddToBossLoot",
					"Terraria",
					"Pirate Invasion",
					new List<int>() {
						clickerClass.ItemType("CaptainsClicker")
					}
				);
				bossChecklist.Call(
					"AddToBossLoot",
					"Terraria",
					"Martian Madness",
					new List<int>() {
						clickerClass.ItemType("HighTechClicker")
					}
				);
				bossChecklist.Call(
					"AddToBossLoot",
					"Terraria",
					"Solar Eclipse",
					new List<int>() {
						clickerClass.ItemType("EclipticClicker")
					}
				);
				bossChecklist.Call(
					"AddToBossLoot",
					"Terraria",
					"Lunar Event",
					new List<int>() {
						clickerClass.ItemType("MiceFragment")
					}
				);
				bossChecklist.Call(
					"AddToBossLoot",
					"Terraria",
					"DD2Betsy",
					new List<int>() {
						ModContent.ItemType<OldOneClicker>()
					}
				);
			}
			/*RecipeBrowser_AddToFilter("Clicker Armor", "Armor", "UI/RecipeBrowser_ClickerArmor", (Item item) =>
			{
				return ClickerCompat.IsClickerItem(item) && !ClickerCompat.IsClickerWeapon(item) && !item.accessory && item.defense > 0;
			});*/
			///. Added new filter for armor (Recipe Browser)
			///	. Clicker Armor
		}
		public override object Call(params object[] args)
		{
			return ClickerAddonModCalls.Call(args);
		}
		public override void AddRecipeGroups()
		{
			Mod clickerMod = ModLoader.GetMod("ClickerClass");
			Mod clickerAddon = ModLoader.GetMod("ClickerAddon");
			RecipeGroup.RegisterGroup("ClickerAddon:AnyGoldClicker", new RecipeGroup((Func<string>)(() => Lang.misc[37].ToString() + " Gold Clicker"), new int[2]
			{
				clickerMod.ItemType("GoldClicker"),
				clickerMod.ItemType("PlatinumClicker")
			}));
			RecipeGroup.RegisterGroup("ClickerAddon:AnyGoldBar", new RecipeGroup((Func<string>)(() => Lang.misc[37].ToString() + " Gold Bar"), new int[2]
			{
				ItemID.GoldBar,
				ItemID.PlatinumBar
			}));
			if (RecipeGroup.recipeGroupIDs.ContainsKey("FargowiltasSoulsDLC:AnyAerospecHelmet"))
			{
				int index = RecipeGroup.recipeGroupIDs["FargowiltasSoulsDLC:AnyAerospecHelmet"];
				RecipeGroup group = RecipeGroup.recipeGroups[index];
				group.ValidItems.Add(clickerAddon.ItemType("AerospecCapsuit"));
			}
		}

		/// <summary>
		/// Attempts to add a subcategory to Recipe Browser
		/// </summary>
		/// <param name="name">The displayed subcategory name</param>
		/// <param name="category">The parent category</param>
		/// <param name="texture">The 24x24 path to texture within the mod</param>
		/// <param name="predicate">The condition at which an item is listed in this subcategory</param>
		private void RecipeBrowser_AddToFilter(string name, string category, string texture, Predicate<Item> predicate)
		{
			Mod recipeBrowser = ModLoader.GetMod("RecipeBrowser");
			if (recipeBrowser != null && !Main.dedServ)
			{
				recipeBrowser.Call(new object[5]
				{
					"AddItemFilter",
					name,
					category,
					this.GetTexture(texture), // 24x24 icon
					predicate
				});
			}
		}
	}
}
