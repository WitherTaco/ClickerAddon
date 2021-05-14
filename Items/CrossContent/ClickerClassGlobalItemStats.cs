using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ModLoader.IO;
using Terraria.Utilities;
//using CalamityMod.CalPlayer;

namespace ClickerAddon.Items.CrossContent
{
	public class ClickerClassGlobalItemStats : GlobalItem
	{
		public static bool[] astralArmor;
		/*public override void Load(Item item, TagCompound tag)
		{
			astralArmor = new bool[3] { false, false, false };
		}*/
		public override void UpdateEquip(Item item, Player player)
		{
			Mod fargo = ModLoader.GetMod("FargowiltasSouls");
			Mod fargoDLC = ModLoader.GetMod("FargowiltasSoulsDLC");
			Mod calamity = ModLoader.GetMod("CalamityMod");
			Mod SoA = ModLoader.GetMod("SacredTools");


			if (fargo != null)
			{
				//Fargo`s Mod: Acc
				if (item.type == fargo.ItemType("UniverseSoul")) { 
					ClickerCompat.SetClickerCritAdd(player, 25);
					ClickerCompat.SetDamageAdd(player, 0.66f);
				}
				if (item.type == fargo.ItemType("EternitySoul"))
					ClickerCompat.SetClickerCritAdd(player, 10);

				if (item.type == fargo.ItemType("PumpkingsCape"))
					ClickerCompat.SetClickerCritAdd(player, 5);
				if (item.type == fargo.ItemType("HeartoftheMasochist")) {
					ClickerCompat.SetClickerCritAdd(player, 5);
					ClickerCompat.SetDamageAdd(player, 0.05f);
				}
				if (item.type == fargo.ItemType("MutantAntibodies"))
					ClickerCompat.SetDamageAdd(player, 0.2f);
				if (item.type == fargo.ItemType("MasochistSoul"))
					ClickerCompat.SetDamageAdd(player, 0.5f);
				if (item.type == fargo.ItemType("SupremeDeathbringerFairy"))
					ClickerCompat.SetDamageAdd(player, 0.1f);
				if (item.type == fargo.ItemType("AgitatingLens") && player.statLife < player.statLifeMax2 / 2)
					ClickerCompat.SetDamageAdd(player, 0.1f);

				//Fargo`s Mod: Armor
				if (item.type == fargo.ItemType("GaiaHelmet"))
				{
					ClickerCompat.SetClickerCritAdd(player, 5);
					ClickerCompat.SetDamageAdd(player, 0.1f);
				}
				if (item.type == fargo.ItemType("GaiaPlate"))
				{
					ClickerCompat.SetClickerCritAdd(player, 5);
					ClickerCompat.SetDamageAdd(player, 0.1f);
				}
				if (item.type == fargo.ItemType("GaiaGreaves"))
				{
					ClickerCompat.SetClickerCritAdd(player, 5);
					ClickerCompat.SetDamageAdd(player, 0.1f);
				}

				if (item.type == fargo.ItemType("EridanusHat"))
				{
					ClickerCompat.SetClickerCritAdd(player, 5);
					ClickerCompat.SetDamageAdd(player, 0.05f);
				}
				if (item.type == fargo.ItemType("EridanusBattleplate"))
				{
					ClickerCompat.SetClickerCritAdd(player, 10);
					ClickerCompat.SetDamageAdd(player, 0.1f);
				}
				if (item.type == fargo.ItemType("EridanusLegwear"))
				{
					ClickerCompat.SetClickerCritAdd(player, 5);
					ClickerCompat.SetDamageAdd(player, 0.05f);
				}

				if (item.type == fargo.ItemType("MutantMask"))
				{
					ClickerCompat.SetClickerCritAdd(player, 20);
					ClickerCompat.SetDamageAdd(player, 0.5f);
				}
				if (item.type == fargo.ItemType("MutantBody"))
				{
					ClickerCompat.SetClickerCritAdd(player, 30);
					ClickerCompat.SetDamageAdd(player, 0.7f);
				}
				if (item.type == fargo.ItemType("MutantPants"))
				{
					ClickerCompat.SetClickerCritAdd(player, 20);
					ClickerCompat.SetDamageAdd(player, 0.5f);
				}

				//Fargo`s Mod DLC
				if (fargoDLC != null)
				{
					if (calamity != null)
					{
						if (item.type == fargoDLC.ItemType("DaedalusEnchant") || item.type == fargoDLC.ItemType("DesolationForce") || item.type == fargoDLC.ItemType("CalamitySoul") || item.type == fargo.ItemType("EternitySoul"))
							player.GetModPlayer<ClickerAddonPlayer>().daedalusCapsuit = true;
						if (item.type == fargoDLC.ItemType("ReaverEnchant") || item.type == fargoDLC.ItemType("DevastationForce") || item.type == fargoDLC.ItemType("CalamitySoul") || item.type == fargo.ItemType("EternitySoul"))
							player.GetModPlayer<ClickerAddonPlayer>().reaverCapsuit = true;
						if (item.type == fargoDLC.ItemType("AtaxiaEnchant") || item.type == fargoDLC.ItemType("AnnihilationForce") || item.type == fargoDLC.ItemType("CalamitySoul") || item.type == fargo.ItemType("EternitySoul"))
							player.GetModPlayer<ClickerAddonPlayer>().ataxiaCapsuit = true;
						if (item.type == fargoDLC.ItemType("BloodflareEnchant") || item.type == fargoDLC.ItemType("AuricEnchant") || item.type == fargoDLC.ItemType("ExaltationForce") || item.type == fargoDLC.ItemType("CalamitySoul") || item.type == fargo.ItemType("EternitySoul"))
							player.GetModPlayer<ClickerAddonPlayer>().bloodflareCapsuit = true;
						if (item.type == fargoDLC.ItemType("GodSlayerEnchant") || item.type == fargoDLC.ItemType("AuricEnchant") || item.type == fargoDLC.ItemType("ExaltationForce") || item.type == fargoDLC.ItemType("CalamitySoul") || item.type == fargo.ItemType("EternitySoul"))
							player.GetModPlayer<ClickerAddonPlayer>().godSlayerCapsuit = true;
						if (item.type == fargoDLC.ItemType("SilvaEnchant") || item.type == fargoDLC.ItemType("AuricEnchant") || item.type == fargoDLC.ItemType("ExaltationForce") || item.type == fargoDLC.ItemType("CalamitySoul") || item.type == fargo.ItemType("EternitySoul"))
							player.GetModPlayer<ClickerAddonPlayer>().silvaCapsuit = true;

						/*if (item.type == fargoDLC.ItemType("AstralEnchant"))
							ifAstralEnch = true;*/
					}
				}
			}

			//Shadows of Abbadon
			if (SoA != null)
			{
				if (item.type == SoA.ItemType("MementoMori"))
					ClickerCompat.SetClickerCritAdd(player, 12);
				if (item.type == SoA.ItemType("VoidHelm"))
					ClickerCompat.SetClickerCritAdd(player, 18);
				if (item.type == SoA.ItemType("VulcanHelm"))
					ClickerCompat.SetClickerCritAdd(player, 10);
			}

			//Calamity
			if (calamity != null)
			{
				//CalamityPlayer modPlayer = player.GetModPlayer<CalamityPlayer>();

				//Pre-Hardmode Armor
				if (item.type == calamity.ItemType("WulfrumArmor"))
					ClickerCompat.SetClickerCritAdd(player, 3);
				if (item.type == calamity.ItemType("VictideBreastplate"))
					ClickerCompat.SetClickerCritAdd(player, 5);
				if (item.type == calamity.ItemType("AerospecBreastplate"))
					ClickerCompat.SetClickerCritAdd(player, 3);
				if (item.type == calamity.ItemType("StatigelArmor"))
					ClickerCompat.SetClickerCritAdd(player, 5);

				//Hardmode Armor
				if (item.type == calamity.ItemType("DaedalusBreastplate"))
					ClickerCompat.SetClickerCritAdd(player, 3);
				if (item.type == calamity.ItemType("DaedalusLeggings"))
					ClickerCompat.SetClickerCritAdd(player, 3);
				if (item.type == calamity.ItemType("ReaverScaleMail"))
					ClickerCompat.SetClickerCritAdd(player, 4);
				if (item.type == calamity.ItemType("ReaverCuisses"))
					ClickerCompat.SetClickerCritAdd(player, 5);
				if (item.type == calamity.ItemType("AtaxiaArmor"))
					ClickerCompat.SetClickerCritAdd(player, 4);
				if (item.type == calamity.ItemType("AtaxiaSubligar"))
					ClickerCompat.SetClickerCritAdd(player, 3);
				/*if (item.type == calamity.ItemType("AstralHelm") && item.type == calamity.ItemType("AstralBreastplate") && item.type == calamity.ItemType("AstralLeggings"))
					ClickerCompat.SetClickerCritAdd(player, 21);*/
				if (item.type == calamity.ItemType("AstralHelm"))
					astralArmor[0] = true;
				else
					astralArmor[0] = false;
				if (item.type == calamity.ItemType("AstralBreastplate"))
					astralArmor[1] = true;
				else
					astralArmor[1] = false;
				if (item.type == calamity.ItemType("AstralLeggings"))
					astralArmor[2] = true;
				else
					astralArmor[2] = false;
				if (astralArmor[0] && astralArmor[1] && astralArmor[2])
					ClickerCompat.SetClickerCritAdd(player, 21);

				/*if(modPlayer.astralStarRain && !ifAstralEnch)
					ClickerCompat.SetClickerCritAdd(player, 21);*/

				//Post-ML Armor
				if (item.type == calamity.ItemType("TarragonBreastplate"))
					ClickerCompat.SetClickerCritAdd(player, 5);
				if (item.type == calamity.ItemType("TarragonLeggings"))
					ClickerCompat.SetClickerCritAdd(player, 6);
				if (item.type == calamity.ItemType("BloodflareBodyArmor"))
					ClickerCompat.SetClickerCritAdd(player, 8);
				if (item.type == calamity.ItemType("BloodflareCuisses"))
					ClickerCompat.SetClickerCritAdd(player, 7);
				if (item.type == calamity.ItemType("OmegaBlueHelmet"))
					ClickerCompat.SetClickerCritAdd(player, 8);
				if (item.type == calamity.ItemType("OmegaBlueChestplate"))
					ClickerCompat.SetClickerCritAdd(player, 8);
				if (item.type == calamity.ItemType("OmegaBlueLeggings"))
					ClickerCompat.SetClickerCritAdd(player, 8);
				if (item.type == calamity.ItemType("GodSlayerChestplate"))
					ClickerCompat.SetClickerCritAdd(player, 6);
				if (item.type == calamity.ItemType("GodSlayerLeggings"))
					ClickerCompat.SetClickerCritAdd(player, 10);
				if (item.type == calamity.ItemType("FearmongerPlateMail"))
					ClickerCompat.SetClickerCritAdd(player, 5);
				if (item.type == calamity.ItemType("SilvaArmor"))
					ClickerCompat.SetClickerCritAdd(player, 8);
				if (item.type == calamity.ItemType("SilvaLeggings"))
					ClickerCompat.SetClickerCritAdd(player, 7);
				if (item.type == calamity.ItemType("AuricTeslaBodyArmor"))
					ClickerCompat.SetClickerCritAdd(player, 5);
				if (item.type == calamity.ItemType("AuricTeslaCuisses"))
					ClickerCompat.SetClickerCritAdd(player, 5);
				if (item.type == calamity.ItemType("DemonshadeHelm"))
					ClickerCompat.SetClickerCritAdd(player, 15);
				if (item.type == calamity.ItemType("DemonshadeBreastplate"))
					ClickerCompat.SetClickerCritAdd(player, 15);
			}
		}
	}
}