using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria.DataStructures;
using Terraria.Enums;
using Terraria.ObjectData;

namespace ClickerAddon.Items.Weapons.Clickers
{
	public class OldOneClicker : ModItem
	{
		public override bool Autoload(ref string name)
		{
			return WitherTacoLib.IfMod();
		}

		public override void SetStaticDefaults()
		{
			ClickerCompat.RegisterClickerWeapon(this);
			DisplayName.SetDefault("Old One`s Clicker");
			Tooltip.SetDefault("Click on an enemy within range and sight to damage them");

			string Terra = ClickerCompat.RegisterClickEffect(mod, "BetsyExplosion", "Betsy`s Explosion", "Shoots 4 Batsy`s Wraths with 75% weapon damage", 8, new Color(190, 60, 70, 0), delegate (Player player, Vector2 position, int type, int damage, float knockBack)
			{
				Main.PlaySound(SoundID.DD2_WyvernScream.SoundId, (int)Main.MouseWorld.X, (int)Main.MouseWorld.Y, 5);
				Mod clickerClass = ModLoader.GetMod("ClickerClass");
				
				Projectile.NewProjectile(new Vector2(Main.MouseWorld.X, Main.MouseWorld.Y), new Vector2(-1f, 2f), 711, (int)(damage * 0.75f), knockBack, player.whoAmI);
				Projectile.NewProjectile(new Vector2(Main.MouseWorld.X, Main.MouseWorld.Y), new Vector2(-0.5f, 3f), 711, (int)(damage * 0.75f), knockBack, player.whoAmI);
				Projectile.NewProjectile(new Vector2(Main.MouseWorld.X, Main.MouseWorld.Y), new Vector2(0.5f, 3f), 711, (int)(damage * 0.75f), knockBack, player.whoAmI);
				Projectile.NewProjectile(new Vector2(Main.MouseWorld.X, Main.MouseWorld.Y), new Vector2(1f, 2f), 711, (int)(damage * 0.75f), knockBack, player.whoAmI);
			});
		}
		
		public override void SetDefaults()
		{
			ClickerCompat.SetClickerWeaponDefaults(item);
			ClickerCompat.SetRadius(item, 6f);
			ClickerCompat.SetColor(item, new Color(190, 60, 70, 0));
			ClickerCompat.SetDust(item, 87);
			//ClickerCompat.SetEffectW(item, "Holy Nova", 9);
			ClickerCompat.AddEffect(item, "ClickerAddon:BetsyExplosion");
			
			item.damage = 85;
			item.width = 30;
			item.height = 30;
			item.knockBack = 1f;
			item.value = 75000;
			item.rare = ItemRarityID.Yellow;
		}
	}
}
