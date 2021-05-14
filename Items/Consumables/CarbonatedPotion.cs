using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using ClickerAddon.Buffs;
using Microsoft.Xna.Framework;

namespace ClickerAddon.Items.Consumables
{
	public class CarbonatedPotion : ModItem
	{
		public override bool Autoload(ref string name)
		{
			return WitherTacoLib.IfMod();
		}
		public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("If drinked, add a new clicker effect."
							+ "\nShoot bubbles every 8 clicks");
			string Bubble = ClickerCompat.RegisterClickEffect(mod, "Carbonated", "Carbonated Bubble", "Shoot a Bubbles", 8, new Color(0, 150, 255, 0), delegate (Player player, Vector2 position, int type, int damage, float knockBack)
			{
				for (int k = 0; k < 10; k++)
				{
					Projectile.NewProjectile(Main.MouseWorld.X, Main.MouseWorld.Y, Main.rand.NextFloat(-4f, 4f), Main.rand.NextFloat(-4f, 4f), mod.ProjectileType("ClickBubble"), (int)(damage * 0.05f), knockBack, player.whoAmI);
				}
			});
		}

		public override void SetDefaults()
        {
            item.width = 20;
            item.height = 26;
            item.useStyle = ItemUseStyleID.EatingUsing;
            item.useAnimation = 15;
            item.useTime = 15;
            item.useTurn = true;
            item.UseSound = SoundID.Item3;
            item.maxStack = 30;
            item.consumable = true;
            item.rare = ItemRarityID.Orange;
            item.value = 25;
            item.buffType = ModContent.BuffType<CarbonatedBuff>();
            item.buffTime = 5*60*60;
        }
		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			
			recipe.AddIngredient(ItemID.BottledWater, 1);
			recipe.AddIngredient(ItemID.DoubleCod, 1);
			recipe.AddIngredient(ItemID.Blinkroot, 1);
			recipe.AddIngredient(ItemID.FallenStar, 1);
			
			recipe.AddTile(TileID.Bottles);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
    }
}
