using System.Linq;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Localization;

namespace LoLitems.Content.Items.Accessory;
{
    public class Thornmail : ModItem
    {
        public override void SetDefaults()
        {
            Item.width = 24;
            Item.height = 28;
            Item.accessory = true;
            Item.rare = 2;
            Item.value = Item.sellPrice(gold: 1);
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            MyModPlayer modPlayer = player.GetModPlayer<MyModPlayer>();

            if (modPlayer.timeSinceHit >= modPlayer.hitCooldown && modPlayer.receivedBasicAttack)
            {
                modPlayer.ApplyOnHitDamage();
                modPlayer.receivedBasicAttack = false;
            }
            modPlayer.timeSinceHit++;
        }
    }
}
