using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Terraria.DataStructures; // Для использования HitInfo
using System.Linq;

namespace LoLitems.Content.Items;
{
    public class MyModPlayer : ModPlayer
    {
        public int timeSinceHit = 0;
        public int hitCooldown = 60; // Кулдаун в тиках (пример: 1 секунда)
        public bool receivedBasicAttack = false;
        public NPC attacker = null;
        public bool hasHitBoss = false;
        public int timeSinceBossHit = 0;

        // Проверка на наличие аксессуара Thornmail
        public bool HasThornmailEquipped => Player.armor.Any(item => item.ModItem is LoLitems.Content.Items.Accessory.Thornmail);

        // Метод для нанесения урона атакующему
        public void ApplyOnHitDamage()
        {
            if (attacker != null && receivedBasicAttack && HasThornmailEquipped)
            {
                int armorBonus = (int)(Player.statDefense * 0.1f); // 10% от брони
                int totalDamage = 20 + armorBonus; // Базовый урон + бонус

                // Создаем HitInfo для нанесения урона
                NPC.HitInfo hitInfo = new NPC.HitInfo()
                {
                    Damage = totalDamage, // Урон
                    Crit = false, // Шанс на крит, если нужно
                    DamageType = DamageClass.Default, // Тип урона
                    HideCombatText = false, // Показать текст урона
                    HitDirection = 0, // Направление отталкивания
                    InstantKill = false, // Не использовано для обычных атак
                    Knockback = 0 // Без отталкивания
                };

                // Наносим урон NPC с использованием HitInfo
                attacker.StrikeNPC(hitInfo); // Передаем HitInfo
            }
        }

        // Обрабатываем получение урона от NPC
        public override void ModifyHitByNPC(NPC npc, ref Player.HurtModifiers modifiers)
        {
            receivedBasicAttack = true; // Устанавливаем флаг
            attacker = npc; // Сохраняем атакующего NPC
            timeSinceHit = 0; // Сбрасываем кулдаун
        }
    }
}
