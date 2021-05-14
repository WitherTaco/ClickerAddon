using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria.DataStructures;
using Terraria.Enums;
using Terraria.ObjectData;
using ClickerAddon.Projectiles.Clickers;

namespace ClickerAddon.Items.Weapons.Clickers
{
	public class BeeClicker : ModItem
	{
		public override bool Autoload(ref string name)
		{
			return WitherTacoLib.IfMod();
		}

		public override void SetStaticDefaults()
		{
			ClickerCompat.RegisterClickerWeapon(this);
			//DisplayName.SetDefault("The Bejeweled Clicker");
			Tooltip.SetDefault("Click on an enemy within range and sight to damage them");
			string BeeEffect = ClickerCompat.RegisterClickEffect(mod, "Bee", "Not the bees!", "Shoots bees", 8, new Color(255, 255, 0, 0), delegate (Player player, Vector2 position, int type, int damage, float knockBack)
			{
				Mod clickerClass = ModLoader.GetMod("ClickerClass");
				//Projectile.NewProjectile(Main.MouseWorld.X, Main.MouseWorld.Y, 0f, 0f, ModContent.ProjectileType<LordsClickerProSuper>(), damage, knockBack, player.whoAmI);
				Main.PlaySound(SoundID.Item97.SoundId, (int)Main.MouseWorld.X, (int)Main.MouseWorld.Y, 5);
				for (int i = 0; i < 8; i++)
				{
					Projectile.NewProjectile(Main.MouseWorld.X, Main.MouseWorld.Y, Main.rand.NextFloat(-5f, 5f), Main.rand.NextFloat(-5f, 5f), ProjectileID.Bee, (int)(damage * 0.2f), knockBack, player.whoAmI);
				}
			});
		}
		
		public override void SetDefaults()
		{
			ClickerCompat.SetClickerWeaponDefaults(item);
			ClickerCompat.SetRadius(item, 3.1f);
			ClickerCompat.SetColor(item, new Color(255, 255, 0, 0));
			ClickerCompat.SetDust(item, 87);
			ClickerCompat.AddEffect(item, "ClickerAddon:Bee");

			item.damage = 14;
			item.width = 30;
			item.height = 30;
			item.knockBack = 1f;
			item.value = 10000;
			item.rare = ItemRarityID.Orange;
		}
	}
}
