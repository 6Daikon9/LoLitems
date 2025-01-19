using System.Linq;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Localization;

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
            player.statDefense += 8; // Добавляет 8 защиты (armor)
            player.statLifeMax2 += 15; // Увеличивает максимальное здоровье на 15

            MyModPlayer modPlayer = player.GetModPlayer<MyModPlayer>();

            if (modPlayer.timeSinceHit >= modPlayer.hitCooldown && modPlayer.receivedBasicAttack)
            {
                modPlayer.ApplyOnHitDamage();
                modPlayer.receivedBasicAttack = false;
            }
            modPlayer.timeSinceHit++;
        }
        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ItemID.IronBar, 10);
            recipe.AddIngredient(ItemID.LifeCrystal, 1); // Лайф Кристалл
            recipe.AddIngredient(ItemID.CactusBreastplate, 1); //Кактусовый нагрудник
            recipe.AddTile(TileID.TinkerersWorkbench);
            recipe.Register();
        }
    }
}
