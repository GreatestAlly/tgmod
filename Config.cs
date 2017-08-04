using System;
using System.IO;
using Terraria;
using Terraria.IO;
using Terraria.ModLoader;

namespace tgmod
{
    public static class Config
    {
        public static bool forceRolling = true;
        public static bool netSynced = false;

        static string ConfigPath = Path.Combine(Main.SavePath, "Mod Configs", "tgmod.json");

        static Preferences Configuration = new Preferences(ConfigPath);

        public static void Load()
        {
            // read the config file

            bool loadSuccess = ReadConfig();
            netSynced = false;

            if (!loadSuccess)
            {
                ErrorLogger.Log("Fail to read tgmod's config file! Recreating Config...");
                CreateConfig();
            }
        }

        static bool ReadConfig()
        {
            if (Configuration.Load())
            {
                Configuration.Get("forceRolling", ref forceRolling);
                return true;
            }
            return false;
        }

        static void CreateConfig()
        {
            Configuration.Clear();
            Configuration.Put("forceRolling", true);
            Configuration.Save();
        }
    }
}
