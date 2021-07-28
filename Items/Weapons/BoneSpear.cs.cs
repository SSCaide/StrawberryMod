using SSCStrawberryMod.Projectiles;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace SSCStrawberryMod.Items.Weapons
{
	public class BoneSpear : ModItem
	{

		public override void SetDefaults()
		{
			item.damage = 11;
			item.useStyle = ItemUseStyleID.HoldingOut;
			item.useAnimation = 29;
			item.useTime = 29;
			item.shootSpeed = 2.7f;
			item.knockBack = 6f;
			item.width = 38;
			item.height = 38;
			item.scale = 1f;
			item.rare = ItemRarityID.White;
			item.value = Item.sellPrice(silver: 11, copper: 70);

			item.melee = true;
			item.noMelee = true; // Important because the spear is actually a projectile instead of an item. This prevents the melee hitbox of this item.
			item.noUseGraphic = true; // Important, it's kind of wired if people see two spears at one time. This prevents the melee animation of this item.
			item.autoReuse = false; // Most spears don't autoReuse, but it's possible when used in conjunction with CanUseItem()

			item.UseSound = SoundID.Item1;
			item.shoot = ModContent.ProjectileType<BoneSpearProjectile>();
		}

		public override bool CanUseItem(Player player)
		{
			// Ensures no more than one spear can be thrown out, use this when using autoReuse
			return player.ownedProjectileCounts[item.shoot] < 1;
		}

        public override void AddRecipes()
        {
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.Bone, 12);
			recipe.AddIngredient(ItemID.SkeletonBanner);
			recipe.AddTile(TileID.Anvils);
			recipe.SetResult(this);
			recipe.AddRecipe();

			ModRecipe recipe2 = new ModRecipe(mod);
			recipe2.AddIngredient(ItemID.Bone, 8);
			recipe2.AddIngredient(ItemID.SkeletonBanner);
			recipe2.AddTile(TileID.Anvils);
			recipe2.SetResult(ItemID.BoneSword);
			recipe2.AddRecipe();

			ModRecipe recipe3 = new ModRecipe(mod);
			recipe3.AddIngredient(ItemID.Bone, 10);
			recipe3.AddRecipeGroup("Wood", 4);
			recipe3.AddIngredient(ItemID.SkeletonBanner);
			recipe3.AddTile(TileID.Anvils);
			recipe3.SetResult(ItemID.BonePickaxe);
			recipe3.AddRecipe();

		}
    }
}