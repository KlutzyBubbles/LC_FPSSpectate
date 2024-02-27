using BepInEx;
using BepInEx.Logging;
using BepInEx.Configuration;
using HarmonyLib;
using UnityEngine.InputSystem;
using FPSSpectate.Patches;

namespace FPSSpectate
{
    [BepInPlugin(modGUID, modName, modVersion)]
    public class FPSSpectate : BaseUnityPlugin
    {
        public const string modGUID = "5Bit.FPSSpectate";
        public const string modName = "FPSSpectate";
        public const string modVersion = "1.0.2";

        public readonly Harmony harmony = new Harmony(modGUID);

        public static FPSSpectate Instance;
        public static ConfigEntry<Key> fpsKeyBind {  get; set; }
        public static ConfigEntry<bool> defaultViewConfig { get; set; }

        public static ManualLogSource mls;

        void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
            }
            fpsKeyBind = Config.Bind("Settings", "Keybind", Key.V, "Which key to press to switch between third and first person.");
            defaultViewConfig = Config.Bind("Settings", "Default to first person", true, "Whether or not to default to first person when spectating");
            mls = BepInEx.Logging.Logger.CreateLogSource(modGUID);
            harmony.PatchAll();
        }
    }
}