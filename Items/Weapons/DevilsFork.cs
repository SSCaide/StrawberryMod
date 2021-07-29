using Microsoft.Xna.Framework;
using SSCStrawberryMod.Projectiles;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace SSCStrawberryMod.Items.Weapons
{
	public class DevilsFork : ModItem
	{

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Devil's Fork");
		}

		public override void SetDefaults()
		{
			item.damage = 12;
			item.useStyle = ItemUseStyleID.HoldingOut;
			item.useAnimation = 25;
			item.useTime = 25;
			item.shootSpeed = 2.7f;
			item.knockBack = 6.5f;
			item.width = 38;
			item.height = 38;
			item.scale = 1f;
			item.rare = ItemRarityID.Blue;
			item.value = Item.sellPrice(silver: 17, copper: 55);

			item.melee = true;
			item.noMelee = true; // Important because the spear is actually a projectile instead of an item. This prevents the melee hitbox of this item.
			item.noUseGraphic = true; // Important, it's kind of wired if people see two spears at one time. This prevents the melee animation of this item.
			item.autoReuse = false; // Most spears don't autoReuse, but it's possible when used in conjunction with CanUseItem()

			item.UseSound = SoundID.Item1;
			item.shoot = ModContent.ProjectileType<DevilsForkProjectile>();
		}

		public override bool CanUseItem(Player player)
		{
			// Ensures no more than one spear can be thrown out, use this when using autoReuse
			return player.ownedProjectileCounts[item.shoot] < 1;
		}

		

		public override void AddRecipes()
        {
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.DemoniteBar, 12);
			recipe.AddIngredient(ItemID.ShadowScale, 12);
			recipe.AddTile(TileID.Anvils);
			recipe.SetResult(this);
			recipe.AddRecipe();

			ModRecipe recipe2 = new ModRecipe(mod);
			recipe2.AddIngredient(ItemID.DemoniteBar, 3);
			recipe2.AddIngredient(ItemID.ShadowScale, 3);
			recipe2.AddIngredient(ItemID.RottenChunk, 3);
			recipe2.AddIngredient(ItemID.Star, 3);
			recipe2.AddTile(TileID.DemonAltar);
			recipe2.SetResult(ItemID.ShadowOrb);
			recipe2.AddRecipe();

			ModRecipe recipe3 = new ModRecipe(mod);
			recipe3.AddIngredient(ItemID.CrimtaneBar, 12);
			recipe3.AddIngredient(ItemID.TissueSample, 6);
			recipe3.AddTile(TileID.Anvils);
			recipe3.SetResult(ItemID.TheRottedFork);
			recipe3.AddRecipe();

			ModRecipe recipe4 = new ModRecipe(mod);
			recipe4.AddIngredient(ItemID.CrimtaneBar, 3);
			recipe4.AddIngredient(ItemID.TissueSample, 3);
			recipe4.AddIngredient(ItemID.Vertebrae, 3);
			recipe4.AddIngredient(ItemID.Star, 3);
			recipe4.AddTile(TileID.DemonAltar);
			recipe4.SetResult(ItemID.CrimsonHeart);
			recipe4.AddRecipe();
		}
    }
}