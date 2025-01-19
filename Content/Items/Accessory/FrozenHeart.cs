using System.Linq;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Localization;

namespace LoLitems.Content.Items.Accessory
{	
	public class FrozenHeart : ModItem
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
            player.statDefense += 8; // Добавляет 8 защиты (armor)
            player.statManaMax2 += 40; // Увеличивает максимальную ману на 40
            // player.*** += 20; // Добавили 20 (ability haste)
        }
        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ItemID.IronBar, 10);
            recipe.AddIngredient(ItemID.IceBlock, 20);  // Лед
            recipe.AddIngredient(ItemID.ManaCrystal, 1);  // Мана кристал
            recipe.AddTile(TileID.TinkerersWorkbench);
            recipe.Register();
        }
    }
}
