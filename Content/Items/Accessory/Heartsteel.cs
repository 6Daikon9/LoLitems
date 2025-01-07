using System.Linq;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Localization;

namespace LoLitems.Content.Items.Accessory;
{
    public class Heartsteel : ModItem
    {
        private const float DetectionRadius = 50f; // Радиус для обнаружения босса (убрал f)
        private const float HealthPercentage = 0.12f; // 12% от максимального здоровья
        private const int TimeDelay = 180; // Время задержки (3 секунды = 180 кадрам)

        public override void SetStaticDefaults()
        {
            // DisplayName = Language.GetText("Mods.LoLitems.ItemName.Heartsteel");
            // Tooltip = Language.GetText("Mods.LoLitems.ItemTooltip.Heartsteel");
        }

        public override void SetDefaults()
        {
            Item.width = 24; // Ширина спрайта
            Item.height = 28; // Высота спрайта
            Item.accessory = true; // Указывает, что это аксессуар
            Item.rare = ItemRarityID.Green; // Редкость
            Item.value = Item.sellPrice(0, 1, 0, 0); // Цена продажи
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            // Добавляем стандартные эффекты Heartsteel
            player.statLifeMax2 += 90; // Увеличение максимального здоровья
            player.lifeRegen += player.lifeRegen; // Удваиваем регенерацию здоровья

            // Логика усиления при нахождении рядом с боссом и атаке его
            MyModPlayer modPlayer = player.GetModPlayer<MyModPlayer>();
            NPC boss = FindClosestBoss(player);
            if (boss != null && Vector2.Distance(player.Center, boss.Center) <= DetectionRadius)
            {
                if (modPlayer.timeSinceBossHit >= TimeDelay && modPlayer.hasHitBoss)
                {
                    // Увеличиваем здоровье на 12% от максимального
                    int additionalHealth = (int)(player.statLifeMax * HealthPercentage);
                    player.statLifeMax2 += additionalHealth;
                    player.HealEffect(additionalHealth);

                    // Сбрасываем флаг
                    modPlayer.hasHitBoss = false;
                }
                else
                {
                    modPlayer.timeSinceBossHit++;
                }
            }
            else
            {
                // Если босса нет в радиусе, сбрасываем таймер
                modPlayer.timeSinceBossHit = 0;
                modPlayer.hasHitBoss = false;
            }
        }

        private NPC FindClosestBoss(Player player)
        {
            // Находим ближайшего босса в радиусе
            return Main.npc.Where(npc => npc.active && npc.boss && Vector2.Distance(player.Center, npc.Center) <= DetectionRadius).FirstOrDefault();
        }

        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ItemID.LifeCrystal, 3); // Лайф Кристалл
            recipe.AddIngredient(ItemID.Shackle, 2); // Кандалы
            recipe.AddTile(TileID.TinkerersWorkbench); // Верстак, где создается предмет
            recipe.Register();
        }
    }
}
LoLitems
    Content
        Items
            Accessory
                Heartsteel.cs
                Thornmail.cs
            MyModPlayer.cs
        