using System;
using System.IO;
using Terraria;
using Terraria.IO;
using Terraria.ModLoader;

namespace tgmod
{
    public static class Config
    {
        public static int version = 2;
        public static bool forceRolling = false;
        public static bool sellSummons = true;
        public static bool chooseClass = true;
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
                int readVersion = 0;
                Configuration.Get("version", ref readVersion);
                if (readVersion == version)
                {
                    Configuration.Get("forceRolling", ref forceRolling);
                    Configuration.Get("sellSummons", ref sellSummons);
                    Configuration.Get("chooseClass", ref chooseClass);
                    return true;
                }
            }
            return false;
        }

        static void CreateConfig()
        {
            Configuration.Clear();
            Configuration.Put("version", version);
            Configuration.Put("forceRolling", forceRolling);
            Configuration.Put("sellSummons", sellSummons);
            Configuration.Put("chooseClass", chooseClass);
            Configuration.Save();
        }
    }
}
