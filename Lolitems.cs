using Terraria.ModLoader;

namespace LoLitems
{
    public class LoLitems : Mod
    {
        public override void Load()
        {
            // Код, который выполняется при загрузке мода
            Logger.Info("LoLitems мод загружен!");
        }

        public override void Unload()
        {
            // Код, который выполняется при выгрузке мода
            Logger.Info("LoLitems мод выгружен!");
        }
    }
}
