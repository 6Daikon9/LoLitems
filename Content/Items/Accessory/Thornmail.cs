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
            player.statDefense += 15;  // Adds 15 defenses (armor)
            player.statLifeMax2 += 70;  // Increase maximum health by 70
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

        // Применение урона при получении удара
// //         public void ApplyOnHitDamage()
// //         {
// //             if (attacker != null && receivedBasicAttack)
// //             {
// //                 int armorBonus = (int)(player.statDefense * 0.1f);  // 10% от брони
// //                 int totalDamage = 20 + armorBonus;  // Базовый урон + бонус от брони

// //                 // Создаём HitInfo для нанесения урона
// //                 NPC.HitInfo hitInfo = new NPC.HitInfo()
// //                 {
// //                     Damage = totalDamage,  // Урон
// //                     Crit = false,  // Без крита
// //                     DamageType = DamageClass.Default,  // Тип урона
// //                     HideCombatText = false,  // Показывать текст урона
// //                     HitDirection = 0,  // Направление отталкивания
// //                     InstantKill = false,  // Не используется для обычных атак
// //                     Knockback = 0  // Без отталкивания
// //                 };

// //                 // Наносим урон NPC
// //                 attacker.StrikeNPC(hitInfo);
// //             }
    }
}
