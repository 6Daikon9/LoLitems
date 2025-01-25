using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace LoLitems.Content.Items.Accessory
{	
    public class Heartsteel : ModItem
    {
        // private const float DetectionRadius = 700f; // Радиус обнаружения врагов
        private const float HealthPercentage = 0.12f; // 12% от максимального здоровья

        public override void SetDefaults()
        {
            Item.width = 32;
            Item.height = 32;
            Item.accessory = true;
            Item.rare = ItemRarityID.Green;
            Item.value = Item.sellPrice(0, 1, 0, 0);
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.statLifeMax2 += 90; // Увеличение максимального здоровья
            player.lifeRegen += player.lifeRegen; // Удваиваем регенерацию здоровья
        }

        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ItemID.LifeCrystal, 3);
            recipe.AddIngredient(ItemID.Shackle, 2);
            recipe.AddTile(TileID.TinkerersWorkbench);
            recipe.Register();
        }
    }
}
