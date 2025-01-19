using Microsoft.Xna.Framework;
using System.Linq;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Localization;

namespace LoLitems.Content.Items.Accessory
{	
    public class Heartsteel : ModItem
    {
        // private const float DetectionRadius = 700f; // Радиус обнаружения врагов
        // private const float HealthPercentage = 0.12f; // 12% от максимального здоровья
        // private const int MaxStacks = 3; // Максимальное количество стеков
        // private const int TimeDelay = 180; // Время задержки (3 секунды = 180 кадров)
        // private int stacks = 0;  // Количество стеков
        // private bool empoweredAttack = false; // Усиленная атака
        // private int bonusHealth = 0; // Бонусное здоровье

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

            // // Проверяем, есть ли враг в радиусе
            // NPC target = FindClosestEnemy(player);
            // if (target != null)
            // {
            //     // Увеличиваем стек, если враг рядом
            //     if (stacks < MaxStacks)
            //     {
            //         stacks++;
            //     }
            // }

            // // Если накопили 3 стака – активируем эффект
            // if (stacks == MaxStacks)
            // {
            //     empoweredAttack = true;
            //     bonusHealth = (int)(HealthPercentage * player.statLifeMax2); // 12% от макс. здоровья
            // }
            // else
            // {
            //     empoweredAttack = false;
            //     bonusHealth = 0;
            // }

            // // Если активирована усиленная атака, прибавляем бонусное здоровье
            // if (empoweredAttack)
            // {
            //     player.statLifeMax2 += bonusHealth;
            //     player.HealEffect(bonusHealth); // Визуальный эффект лечения
            //     stacks = 0; // Сбрасываем стеки после активации
            // }
        }

        // private NPC FindClosestEnemy(Player player)
        // {
        //     return Main.npc
        //         .Where(npc => npc.active && npc.CanBeChasedBy() && Vector2.Distance(player.Center, npc.Center) <= DetectionRadius)
        //         .FirstOrDefault();
        // }

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
