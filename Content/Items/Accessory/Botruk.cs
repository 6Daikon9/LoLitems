using Terraria;
using Terraria.ID;
using Terraria.ModLoader;


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
            player.GetDamage(DamageClass.Melee) += 0.30f; // Increases melee damage by 20%
            player.GetDamage(DamageClass.Ranged) += 0.20f; // Increases ranged damage by 20%
            player.GetDamage(DamageClass.Summon) += 0.20f; // Increases damage from summoned creatures by 20%
            player.GetDamage(DamageClass.Throwing) += 0.20f; // Increases the damage of throwing weapons by 20%
            
            player.GetAttackSpeed(DamageClass.Melee) += 0.25f; // Increases melee attack speed by 25%
            player.GetAttackSpeed(DamageClass.Ranged) += 0.25f; // Increases ranged attack speed by 25%
            // player.GetModPlayer<MyModPlayer>().lifeSteal += 0.10f; // +10% лайфстила
        }

        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ItemID.IronPickaxe, 1);
            recipe.AddIngredient(ItemID.IronBroadsword, 2);
            recipe.AddTile(TileID.TinkerersWorkbench);
            recipe.Register();
        }
    }
}
