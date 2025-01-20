using System.Linq;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Localization;

namespace LoLitems.Content.Items.Accessory
{    
    public class Botruk : ModItem
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
            player.GetDamage(DamageClass.Melee) += 0.30f; // Увеличивает урон ближнего боя на 20%
            player.GetDamage(DamageClass.Ranged) += 0.20f; // Увеличивает урон дальнего боя на 20%
            player.GetDamage(DamageClass.Summon) += 0.20f; // Увеличивает урон от призванных существ на 20%
            player.GetDamage(DamageClass.Throwing) += 0.20f; // Увеличивает урон метательными оружиями на 20%
            
            player.GetAttackSpeed(DamageClass.Melee) += 0.25f; // Увеличивает скорость атаки ближнего боя на 25%
            player.GetAttackSpeed(DamageClass.Ranged) += 0.25f; // Увеличивает скорость атаки дальнего боя на 25%
            // player.GetModPlayer<MyModPlayer>().lifeSteal += 0.10f; // +10% лайфстила
        }

        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ItemID.IronPickaxe, 1);  // Железная кирка
            recipe.AddIngredient(ItemID.IronBroadsword, 2); // Железные мечи
            recipe.AddTile(TileID.TinkerersWorkbench);
            recipe.Register();
        }
    }
}
