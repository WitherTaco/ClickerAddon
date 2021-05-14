using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Utilities;
//using ClickerClass;
using ClickerAddon.Items.CrossContent.Redemption.Weapons.Clickers;

namespace ClickerAddon.Items
{
	public class ClickerAddonGlobalItem : GlobalItem
	{
		//private const int skillDelay = 0;
		public override float MeleeSpeedMultiplier(Item item, Player player)
		{
			ClickerAddonPlayer modPlayer = player.GetModPlayer<ClickerAddonPlayer>();
			if (ClickerCompat.IsClickerWeapon(item))
			{
				if (!modPlayer.autoClicker)
				{
					if (modPlayer.silvaCapsuit)
					{
						item.autoReuse = true;
						return 0.5f;
					}
					else
					{
						return 1f;
					}
				}
				else
				{
					item.autoReuse = true;
					//return 0.1f;
					return modPlayer.autoClickerMultiplier[0];
				}
				/*if(modPlayer.autoClicker || modPlayer.silvaCapsuit || player.HasBuff(ModLoader.GetMod("ClickerClass").BuffType("AutoClick")) || ClickerCompat.GetAccessory(player, "HandCream"))
				{
					item.autoReuse = true;
				}
				else
				{
					item.autoReuse = false;
				}
				return modPlayer.autoClickerMultiplier[0];*/
			}
			else
			{
				return 1f;
			}
		}
		public override float UseTimeMultiplier(Item item, Player player)
		{
			ClickerAddonPlayer modPlayer = player.GetModPlayer<ClickerAddonPlayer>();
			if (ClickerCompat.IsClickerWeapon(item))
			{
				if (!player.GetModPlayer<ClickerAddonPlayer>().autoClicker)
				{
					if (player.GetModPlayer<ClickerAddonPlayer>().silvaCapsuit)
					{
						item.autoReuse = true;
						return 2f;
					}
					else
					{
						return 1f;
					}
				}
				else
				{
					item.autoReuse = true;
					//return 10f;
					return player.GetModPlayer<ClickerAddonPlayer>().autoClickerMultiplier[1];
				}
				//return modPlayer.autoClickerMultiplier[1];
			}
			else
			{
				return 1f;
			}
		}
		/*public override bool CanUseItem(Item item, Player player)
		{
			if (ClickerCompat.IsClickerItem(item))
			{
				if (player.GetModPlayer<ClickerAddonPlayer>().autoClickerCheat)
				{
					item.autoReuse = true;
				}
				else
				{
					item.autoReuse = false;
				}
				//return true;
			}
			//bool inRange = Vector2.Distance(Main.MouseWorld, player.Center) < ClickerCompat. && Collision.CanHit(new Vector2(player.Center.X, player.Center.Y - 12), 1, 1, Main.MouseWorld, 1, 1);
			return base.CanUseItem(item, player);
		}*/
		public override void OpenVanillaBag(string context, Player player, int arg)
		{
			Mod redemption = ModLoader.GetMod("Redemption");
			switch (context)
			{
				case "bossBag":
					switch (arg)
					{
						/*case redemption.ItemType("ThornBag"):
							if(Main.rand.Next(4))
							{
								player.QuickSpawnItem(mod.ItemType("CursedRootClicker"));
							}
							break;*/
						case ItemID.BossBagBetsy:
							if (Main.rand.NextBool(4))
							{
								player.QuickSpawnItem(mod.ItemType("OldOneClicker"));
							}
							break;
						case ItemID.FishronBossBag:
							if (Main.rand.NextBool(4))
							{
								player.QuickSpawnItem(mod.ItemType("FishronsClicker"));
							}
							break;
						case ItemID.QueenBeeBossBag:
							if (Main.rand.NextBool(3))
							{
								player.QuickSpawnItem(mod.ItemType("BeeClicker"));
							}
							break;

					}
					break;
			}
		}
		public override bool AltFunctionUse(Item item, Player player)
		{
			if(ClickerCompat.IsClickerWeapon(item))
			{
				//ClickerAddonPlayer modPlayer = player.GetModPlayer<ClickerAddonPlayer>();
				if(player.GetModPlayer<ClickerAddonPlayer>().cloneMotherboard || player.GetModPlayer<ClickerAddonPlayer>().cloneMice)
				{
					return true;
				}
				else
				{
					return false;
				}
			}
			return base.AltFunctionUse(item, player);
		}
		public override bool Shoot(Item item, Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
		{
			ClickerAddonPlayer clickerPlayer = player.GetModPlayer<ClickerAddonPlayer>();
			if (ClickerCompat.IsClickerWeapon(item))
			{
				Mod clickerClass = ModLoader.GetMod("ClickerClass");

				//ClickerPlayer clickerPlayer = player.GetModPlayer<ClickerPlayer>();
				//ClickerAddonPlayer modPlayer = player.GetModPlayer<ClickerAddonPlayer>();

				/*if (skillDelay > 0)
				{
					skillDelay--;
				}*/
				if (player.altFunctionUse == 2)
				{
					if(clickerPlayer.setAbilityDelayTimer == 0)
					{
						if(clickerPlayer.cloneMice)
						{
							bool canTeleport = false;
							if(!ClickerCompat.HasClickEffect(player, "PhaseReach"))
							{
								if(Vector2.Distance(Main.MouseWorld, player.Center) < ClickerCompat.GetClickerRadius(player) * 100 && Collision.CanHitLine(new Vector2(player.Center.X, player.Center.Y - 12), 1, 1, Main.MouseWorld, 1, 1))
								{
									canTeleport = true;
								}
							}
							else
							{
								canTeleport = true;
							}
							if(canTeleport)
							{
								Main.PlaySound(SoundID.Item, (int)Main.MouseWorld.X, (int)Main.MouseWorld.Y, 115);
								Main.SetCameraLerp(0.1f, 0);
								player.Center = Main.MouseWorld;
								NetMessage.SendData(MessageID.PlayerControls, number: player.whoAmI);
								player.fallStart = (int)(player.position.Y / 16f);
								clickerPlayer.setAbilityDelayTimer = 60;
								//skillDelay = 60;
							}
						}
						/*else if(player.GetModPlayer<ClickerAddonPlayer>().cloneMotherboard)
						{
							//Main.PlaySound(SoundID.Camera, Main.MouseWorld.X, Main.MouseWorld.Y, 0);
							clickerPlayer.SetMotherboardRelativePosition(Main.MouseWorld);
							player.GetModPlayer<ClickerAddonPlayer>().setAbilityDelayTimer = 60;
						}*/
					}
				}
				if(ClickerCompat.GetClickAmount(player) % 5 == 0 && clickerPlayer.clickerCobaltSet)
				{
					Main.PlaySound(SoundID.Item, (int)Main.MouseWorld.X, (int)Main.MouseWorld.Y, 24);
					player.AddBuff(clickerClass.BuffType("Haste"), 300, false);
					for (int i = 0; i < 15; i++)
					{
						int num6 = Dust.NewDust(player.position, 20, 20, 56, 0f, 0f, 150, default(Color), 1.25f);
						Main.dust[num6].noGravity = true;
						Main.dust[num6].velocity *= 0.75f;
						int num7 = Main.rand.Next(-50, 51);
						int num8 = Main.rand.Next(-50, 51);
						Dust dust = Main.dust[num6];
						dust.position.X = dust.position.X + (float)num7;
						Dust dust2 = Main.dust[num6];
						dust2.position.Y = dust2.position.Y + (float)num8;
						Main.dust[num6].velocity.X = -(float)num7 * 0.075f;
						Main.dust[num6].velocity.Y = -(float)num8 * 0.075f;
					}
				}
				
				if(clickerPlayer.clonePrecursor)
				{
					Projectile.NewProjectile(Main.MouseWorld.X, Main.MouseWorld.Y, 0f, 0f, clickerClass.ProjectileType("PrecursorPro"), (int)(damage * 0.25f), knockBack, player.whoAmI);
				}
				
				if(ClickerCompat.GetClickAmount(player) % 100 == 0 && clickerPlayer.cloneOverclock)
				{
					Main.PlaySound(SoundID.Item, (int)Main.MouseWorld.X, (int)Main.MouseWorld.Y, 94);
					player.AddBuff(clickerClass.BuffType("OverclockBuff"), 180, false);
					for (int i = 0; i < 25; i++)
					{
						int num6 = Dust.NewDust(player.position, 20, 20, 90, 0f, 0f, 150, default(Color), 1.35f);
						Main.dust[num6].noGravity = true;
						Main.dust[num6].velocity *= 0.75f;
						int num7 = Main.rand.Next(-50, 51);
						int num8 = Main.rand.Next(-50, 51);
						Dust dust = Main.dust[num6];
						dust.position.X = dust.position.X + (float)num7;
						Dust dust2 = Main.dust[num6];
						dust2.position.Y = dust2.position.Y + (float)num8;
						Main.dust[num6].velocity.X = -(float)num7 * 0.075f;
						Main.dust[num6].velocity.Y = -(float)num8 * 0.075f;
					}
				}
				if(clickerPlayer.diceEffect && Main.rand.NextBool(10))
				{
					Projectile.NewProjectile(Main.MouseWorld.X, Main.MouseWorld.Y, 0f, 0f, clickerClass.ProjectileType("ClickDamage"), damage, knockBack, player.whoAmI);
				}
				/*if(clickerPlayer.ataxiaCapsuit && Main.rand.NextBool(4))
				{
					Mod calamity = ModLoader.GetMod("CalamityMod");
					Vector2 vec1 = Main.MouseWorld;
					int num1 = 50;
					Vector2 vec2 = new Vector2(Main.rand.Next(-num1, num1), Main.rand.Next(-num1, num1));
					Projectile.NewProjectile(vec1, vec2, calamity.ProjectileType("AtaxiaHealOrb"), damage, knockBack, player.whoAmI);
				}*/
				return false;
			}
			return base.Shoot(item, player, ref position, ref speedX, ref speedY, ref type, ref damage, ref knockBack);
		}
		/*public override void UpdateEquip(Item item, Player player)
		{
			Mod calamity = ModLoader.GetMod("CalamityMod");

			if (item.type == mod.ItemType("AutoClicker"))
				item.autoReuse = true;

			if (calamity != null)
				if (item.type == mod.ItemType("SilvaCapsuit") || player.GetModPlayer<ClickerAddonPlayer>().silvaCapsuit)
					item.autoReuse = true;
		}*/
	}
}