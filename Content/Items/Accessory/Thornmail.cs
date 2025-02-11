using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace LoLitems.Content.Items.Accessory
{
    public class Thornmail : ModItem
    {
        public override void SetDefaults()
        {
            Item.width = 32;
            Item.height = 32;
            Item.accessory = true;
            Item.rare = 3;
            Item.value = Item.sellPrice(gold: 1);
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.statDefense += 15;  // Добавляем 15 защиты
            player.statLifeMax2 += 30;  // Увеличиваем максимальное здоровье на 30
        }

        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ItemID.IronBar, 10);
            recipe.AddIngredient(ItemID.LifeCrystal, 1);
            recipe.AddIngredient(ItemID.CactusBreastplate, 1);
            recipe.AddTile(TileID.TinkerersWorkbench);
            recipe.Register();
        }
    }
}
