using Terraria;
using Terraria.ID;
using Terraria.ModLoader;


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
            player.statDefense += 15; // Adds 15 defense (armor)
            player.statManaMax2 += 80; // Increases maximum mana by 80
            // player.*** += 20; // Добавили 20 (ability haste)
        }
        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ItemID.IronBar, 10);
            recipe.AddIngredient(ItemID.IceBlock, 20);
            recipe.AddIngredient(ItemID.ManaCrystal, 1);
            recipe.AddTile(TileID.TinkerersWorkbench);
            recipe.Register();
        }
    }
}
