using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Utilities;

namespace ClickerAddon.Items.CrossContent.Calamity
{
	public class ClickerAddonCalamityGlobalItem : GlobalItem
	{
		public override bool Autoload(ref string name)
		{
			return ModLoader.GetMod("CalamityMod") != null;
		}
		public override bool Shoot(Item item, Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
		{
			ClickerAddonPlayer clickerPlayer = player.GetModPlayer<ClickerAddonPlayer>();
			Mod calamity = ModLoader.GetMod("CalamityMod");
			if (ClickerCompat.IsClickerItem(item))
			{
				if (clickerPlayer.daedalusCapsuit && Main.rand.NextBool(5))
				{
					for (int i = 0; i < 5; i++)
					{
						int damageA = (int)(damage * 0.5f);
						Vector2 vec1 = Main.MouseWorld;
						Vector2 vec2 = new Vector2(Main.rand.NextFloat(-5f, 5f), Main.rand.NextFloat(-5f, 5f));
						Projectile.NewProjectile(vec1, vec2, ProjectileID.CrystalShard, damageA, knockBack, player.whoAmI);
					}
				}
				if (clickerPlayer.reaverCapsuit && Main.rand.NextBool(5))
				{
					int damageA = (int)(damage * 0.1f);
					for (int i = 0; i < 4; i++)
					{
						int numA = 50;
						Vector2 vec1 = new Vector2(Main.MouseWorld.X + Main.rand.Next(-numA, numA), Main.MouseWorld.Y + Main.rand.Next(-numA, numA));
						Vector2 vec2 = new Vector2(0f, 0f);
						if (Main.rand.NextBool(2))
						{
							Projectile.NewProjectile(vec1, vec2, ProjectileID.SporeTrap, damageA, knockBack, player.whoAmI);
						}
						else
						{
							Projectile.NewProjectile(vec1, vec2, ProjectileID.SporeTrap2, damageA, knockBack, player.whoAmI);

						}
					}
				}
				if (clickerPlayer.godSlayerCapsuit && Main.rand.NextBool(5))
				{
					int damageA = (int)(damage * 0.15f);
					for (int i = 0; i < 4; i++)
					{
						int numA = 50;
						Vector2 vec1 = new Vector2(Main.MouseWorld.X + Main.rand.Next(-numA, numA), Main.MouseWorld.Y + Main.rand.Next(-numA, numA));
						Vector2 vec2 = new Vector2(0f, 0f);
						Projectile.NewProjectile(vec1, vec2, calamity.ProjectileType("NebulaStar"), damageA, knockBack, player.whoAmI);
					}
				}
				return false;
			}
			return base.Shoot(item, player, ref position, ref speedX, ref speedY, ref type, ref damage, ref knockBack);
		}
	}
}