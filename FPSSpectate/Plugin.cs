using BepInEx;
using BepInEx.Logging;
using BepInEx.Configuration;
using HarmonyLib;
using UnityEngine.InputSystem;
using GameNetcodeStuff;
using UnityEngine;
using FPSSpectate.Patches;
using UnityEngine.InputSystem;
using System.Collections.Generic;
using System;

namespace FPSSpectate
{
    [BepInPlugin(modGUID, modName, modVersion)]
    public class FPSSpectate : BaseUnityPlugin
    {
        public const string modGUID = "5Bit.FPSSpectate";
        public const string modName = "FPSSpectate";
        public const string modVersion = "1.0.1";

        public readonly Harmony harmony = new Harmony(modGUID);

        public enum Keys
        {
            aKey, 
            bKey, 
            cKey, 
            dKey, 
            eKey, 
            fKey, 
            gKey, 
            hKey,
            iKey,
            jKey,
            kKey,
            lKey,
            mKey,
            nKey,
            oKey,
            pKey,
            qKey,
            rKey,
            sKey,
            tKey,
            uKey,
            vKey,
            wKey,
            xKey,
            yKey,
            zKey,
            digit0Key,
            digit1Key,
            digit2Key,
            digit3Key,
            digit4Key,
            digit5Key,
            digit6Key,
            digit7Key,
            digit8Key,
            digit9Key,
            f1Key,
            f2Key,
            f3Key,
            f4Key,
            f5Key,
            f6Key,
            f7Key,
            f8Key,
            f9Key,
            f10Key,
            f11Key,
            f12Key,
            numpad0Key,
            numpad1Key,
            numpad2Key,
            numpad3Key,
            numpad4Key,
            numpad5Key,
            numpad6Key,
            numpad7Key,
            numpad8Key,
            numpad9Key,
            altKey,
            leftAltKey,
            rightAltKey,
            shiftKey,
            leftShiftKey,
            rightShiftKey,
            ctrlKey,
            leftCtrlKey,
            rightCtrlKey,
            quoteKey,
            backQuoteKey,
            backslashKey,
            backspaceKey, 
            leftBracketKey,
            rightBracketKey,
            capsLockKey,
            commaKey,
            deleteKey,
            endKey,
            enterKey,
            equalsKey,
            homeKey,
            insertKey,
            minusKey,
            pageUpKey,
            pageDownKey,
            pauseKey,
            periodKey,
            printScreenKey,
            scrollLockKey,
            semicolonKey,
            slashKey,
            spaceKey,
            tabKey,
            leftArrowKey,
            rightArrowKey,
            upArrowKey,
            downArrowKey
        }
        public static Dictionary<string, Type> Languages = new Dictionary<string, Type>
        {
            { "aKey", typeof(Keys) },
            { "English", typeof(Keys) }
        };
        public static FPSSpectate Instance;
        public static ConfigEntry<Key> fpsKeyBind;
        public static ConfigEntry<bool> defaultViewConfig;
        public static ConfigEntry<float> SPECTATE_OFFSET;

        public static ManualLogSource mls;

        void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
            }
            ConfigEntry<Key> fpsKeyBind = Config.Bind("Settings", "Keybind", Key.V, "Which key to press to switch between third and first person.");
            ConfigEntry<bool> defaultViewConfig = Config.Bind("Settings", "Default to first person", true, "Whether or not to default to first person when spectating");
            ConfigEntry<float> spectateOffset = Config.Bind("Settings", "Spectate Offset", 1.5f, "Offset of the camera for spectate");
            FPSSpectatePatch.firstPerson = defaultViewConfig.Value; 
            FPSSpectatePatch.SPECTATE_OFFSET = spectateOffset.Value; 

            mls = BepInEx.Logging.Logger.CreateLogSource(modGUID);
            harmony.PatchAll();
        }
    }
}