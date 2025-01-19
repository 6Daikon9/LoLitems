using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Terraria.DataStructures; // Для использования HitInfo
using System.Linq;
using LoLitems;
using LoLitems.Content.Items.Accessory;

namespace LoLitems
{
    public class MyModPlayer : ModPlayer
    {
        // public float timeWithoutDamage = 0f; // Время без урона

        // // Обработчик получения урона от NPC
        // public override void ModifyHitByNPC(NPC npc, ref Player.HurtModifiers modifiers)
        // {
        //     timeWithoutDamage = 0f; // Сбросить время без урона при получении урона от NPC
        // }

                public override void ModifyHitByNPC(NPC npc, ref Player.HurtModifiers modifiers)
        {
            // if (Player.HasAccessory<Heartsteel>())
            // {
            //     Player.GetModPlayer<MyModPlayer>().PostUpdateHeartSteel();
            // }

            if (Player.HasAccessory<Liandry>())
            {
                Player.GetModPlayer<MyModPlayer>().PostUpdateLiandry();
            }

            // if (Player.HasAccessory<Warmog>())
            // {
            //     Player.GetModPlayer<MyModPlayer>().ModifyHitByNPCWarmog();
            // }
        }

// BOTRUK-BOTRUK-BOTRUK-BOTRUK-BOTRUK-BOTRUK-BOTRUK-BOTRUK-BOTRUK-BOTRUK-BOTRUK-BOTRUK-BOTRUK-BOTRUK

// FROZENHEART-FROZENHEART-FROZENHEART-FROZENHEART-FROZENHEART-FROZENHEART-FROZENHEART-FROZENHEART

// HEARTSTEEL-HEARTSTEEL-HEARTSTEEL-HEARTSTEEL-HEARTSTEEL-HEARTSTEEL-HEARTSTEEL-HEARTSTEEL-HEARTSTEEL

// LIANDRY-LIANDRY-LIANDRY-LIANDRY-LIANDRY-LIANDRY-LIANDRY-LIANDRY-LIANDRY-LIANDRY-LIANDRY-LIANDRY

// THORNMAIL-THORNMAIL-THORNMAIL-THORNMAIL-THORNMAIL-THORNMAIL-THORNMAIL-THORNMAIL-THORNMAIL-THORNMAIL
        public bool HasThornmailEquipped => Player.armor.Any(item => item.ModItem is Thornmail);
        public bool HasLiandryEquipped => Player.armor.Any(item => item.ModItem is Liandry);
        public int timeSinceHit = 0;
        public int hitCooldown = 1; // Кулдаун в тиках (60:1)
        public bool receivedBasicAttack = false;
        public NPC attacker = null;

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
        // public override void ModifyHitByNPC(NPC npc, ref Player.HurtModifiers modifiers)
        // {
        //     receivedBasicAttack = true; // Устанавливаем флаг
        //     attacker = npc; // Сохраняем атакующего NPC
        //     timeSinceHit = 0; // Сбрасываем кулдаун
        // }

// WARMOG-WARMOG-WARMOG-WARMOG-WARMOG-WARMOG-WARMOG-WARMOG-WARMOG-WARMOG-WARMOG-WARMOG-WARMOG-WARMOG
        // public float timeWithoutDamage = 0f; // Время без урона

        // // Обработчик получения урона
        // public override void ModifyHitByNPC(NPC npc, ref Player.HurtModifiers modifiers)
        // {
        //     timeWithoutDamage = 0f; // Сбросить время без урона при получении урона от NPC
        // }

        // // Обновление каждый кадр
        // public void PostUpdateWarmog()
        // {
        //     // Обновляем время без урона
        //     if (timeWithoutDamage < 8f)
        //     {
        //         timeWithoutDamage += 1f / 60f; // Увеличиваем время без урона (1 тик = 1/60 секунды)
        //     }

        //     // Если прошло 8 секунд без урона, активируем регенерацию
        //     if (timeWithoutDamage >= 8f)
        //     {
        //         ActivateRegeneration();
        //     }
        // }

        // Метод для активации регенерации
        private void ActivateRegeneration()
        {
            // Регенерация 10% от максимального здоровья в секунду
            Player.lifeRegen += (int)(Player.statLifeMax2 * 0.1f);
        }
    }
}
