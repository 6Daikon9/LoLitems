using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace LoLitems.Content.Items.Accessory
{	
    public class Warmog : ModItem
    {
        private const float regenTime = 8f; // Время для активации регенерации
        private const float regenAmount = 0.1f; // 10% от макс. здоровья

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
            player.statLifeMax2 += 100; // Увеличение максимального здоровья
            player.lifeRegen += player.lifeRegen; // Удваиваем регенерацию здоровья
            player.moveSpeed += 0.04f; // Увеличивает скорость передвижения на 4%

            // Проверка на активность регенерации
            if (player.GetModPlayer<MyModPlayer>().timeWithoutDamage >= regenTime)
            {
                // Активируем регенерацию здоровья (10% от максимального здоровья)
                player.lifeRegen += (int)(player.statLifeMax2 * regenAmount); 
            }
            else
            {
                player.GetModPlayer<MyModPlayer>().timeWithoutDamage += 1f / 60f; // Добавляем время без урона
            }
        }

        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ItemID.IronBar, 10);
            recipe.AddIngredient(ItemID.LifeCrystal, 4); // Лайф Кристалл
            recipe.AddTile(TileID.TinkerersWorkbench);
            recipe.Register();
        }
    }
}
