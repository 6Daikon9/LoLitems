// using Terraria;
// using Terraria.ModLoader;

// namespace LoLitems.Content
// {
//     public class MyModPlayer : ModPlayer
//     {
//         public override bool CanEquipAccessory(int slot, Item item, bool modded)
//         {
//             // Проверяем, носит ли игрок BamiCinder
//             bool hasBamiCinder = Player.armor.Any(i => i.type == ModContent.ItemType<BamiCinder>());

//             // Проверяем, носит ли игрок SunfireAegis
//             bool hasSunfireAegis = Player.armor.Any(i => i.type == ModContent.ItemType<SunfireAegis>());

//             // Если игрок уже носит один из аксессуаров, запретить экипировку второго
//             if ((item.type == ModContent.ItemType<BamiCinder>() && hasSunfireAegis) ||
//                 (item.type == ModContent.ItemType<SunfireAegis>() && hasBamiCinder))
//             {
//                 return false; // Не даём экипировать
//             }

//             return base.CanEquipAccessory(slot, item, modded);
//         }
//     }
// }



// //          {
// //         private int timeSinceHit = 0;      // Таймер отслеживания времени после удара
// //         private const int hitCooldown = 1; // Кулдаун (60 тиков = 1 секунда)
// //         private bool receivedBasicAttack = false; // Флаг получения обычного урона
// //         private NPC attacker = null;        // NPC, который атакует игрока

// //         public override void ResetEffects()
// //         {
// //             // Сбрасываем флаг в начале
// //             receivedBasicAttack = false;
// //         }

// //         public override void OnHitByNPC(NPC npc, ref Player.HurtModifiers modifiers)
// //         {
// //             receivedBasicAttack = true;  // Устанавливаем флаг получения урона
// //             attacker = npc;              // Сохраняем атакующего NPC
// //             timeSinceHit = 0;            // Сбрасываем таймер
// //         }

// //         public override void UpdateLifeRegen()
// //         {
// //             if (timeSinceHit >= hitCooldown && receivedBasicAttack)
// //             {
// //                 ApplyOnHitDamage(); // Применение урона при получении удара
// //                 receivedBasicAttack = false; // Сброс флага
// //             }
// //             timeSinceHit++; // Увеличиваем таймер
// //         }

// //         // Применение урона при получении удара
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
// //         }
// // }
// //}

// TODO: do something with this code