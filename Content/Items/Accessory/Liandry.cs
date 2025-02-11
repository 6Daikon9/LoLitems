using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace LoLitems.Content.Items.Accessory
{
    public class Liandry : ModItem
    {
        private const int BurnDuration = 180; // 3 секунды (180 тиков)
        private const float BurnPercentage = 0.005f; // 0.5% от макс. здоровья цели

        private bool isBurning = false; // Флаг горения
        private int burnTime = 0;       // Время горения
        private int burnDamage;         // Урон от горения
        private NPC burningTarget = null; // Цель горения

        public override void SetDefaults()
        {
            Item.width = 32;
            Item.height = 32;
            Item.accessory = true;
            Item.rare = ItemRarityID.Pink;
            Item.value = Item.sellPrice(0, 1, 0, 0);
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.GetDamage(DamageClass.Magic) += 0.50f; // Увеличиваем урон магией на 50%
            player.statLifeMax2 += 60; // Увеличиваем максимальное здоровье на 60

            // // Обновляем эффект горения
            // if (isBurning && burnTime > 0)
            // {
            //     ApplyBurnDamage();
            // }
        }

        // // Метод для применения горения
        // private void ApplyBurn(NPC target)
        // {
        //     if (target != null && !isBurning)
        //     {
        //         isBurning = true;
        //         burnTime = BurnDuration;
        //         burnDamage = (int)(target.lifeMax * BurnPercentage);
        //         burningTarget = target;
        //     }
        // }

        // // Метод для нанесения урона от горения
        // private void ApplyBurnDamage()
        // {
        //     if (isBurning && burningTarget != null)
        //     {
        //         // Наносим урон от горения
        //         NPC.HitInfo burnHitInfo = new NPC.HitInfo()
        //         {
        //             Damage = burnDamage,
        //             Crit = false,
        //             DamageType = DamageClass.Magic,
        //             HideCombatText = false,
        //             HitDirection = 0,
        //             Knockback = 0
        //         };

        //         burningTarget.StrikeNPC(burnHitInfo);

        //         burnTime--;

        //         // Прекращаем горение, если время истекло
        //         if (burnTime <= 0)
        //         {
        //             isBurning = false;
        //             burningTarget = null;
        //         }
        //     }
        // }

        // public override void ModifyHitNPCWithProj(Projectile proj, NPC target, ref NPC.HitModifiers modifiers)
        // {
        //     if (proj.DamageType == DamageClass.Magic)
        //     {
        //         ApplyBurn(target);
        //     }
        // }

        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ItemID.LifeCrystal, 1);
            recipe.AddIngredient(ItemID.Book, 3);
            recipe.AddTile(TileID.TinkerersWorkbench);
            recipe.Register();
        }
    }
}
