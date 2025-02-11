using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace LoLitems.Content.Items.Accessory
{
    public class BamiCinder : ModItem
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
            player.statLifeMax2 += 30; // Увеличиваем максимальное здоровье на 30
        }

        public override bool CanAccessoryBeEquippedWith(Item equippedItem, Item incomingItem, Player player)
        {
            // Запрещаем одновременное ношение BamiCinder и SunfireAegis
            if ((equippedItem.type == ModContent.ItemType<BamiCinder>() && incomingItem.type == ModContent.ItemType<SunfireAegis>()) ||
                (equippedItem.type == ModContent.ItemType<SunfireAegis>() && incomingItem.type == ModContent.ItemType<BamiCinder>()))
            {
                return false; // Оба аксессуара нельзя носить вместе
            }

            return true; // Если конфликтов нет, разрешаем экипировку
        }

        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ItemID.LifeCrystal, 1);
            recipe.AddTile(TileID.TinkerersWorkbench);
            recipe.Register();
        }
    }
}
