using Terraria.ModLoader;

namespace RecurrenceMod
{
	public class Recurrence : Mod
	{
		private static Recurrence instance;

        public static Recurrence Instance { get => instance; private set => instance = value; }

        public override void Load()
        {
            instance = this;
        }

        public override void Unload()
        {
            instance = null;
        }

    }
}