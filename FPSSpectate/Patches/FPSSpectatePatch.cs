using GameNetcodeStuff;
using HarmonyLib;
using UnityEngine;
using UnityEngine.InputSystem;
using FPSSpectate;
using UnityEngine.UIElements;

namespace FPSSpectate.Patches
{
    [HarmonyPatch(typeof(PlayerControllerB))]
    internal class FPSSpectatePatch
    {
        public static float SPECTATE_OFFSET = 1.5f;
        public static bool debounced = false;
        public static bool firstPerson = true;
        [HarmonyPatch("LateUpdate")]
        [HarmonyPostfix]
        private static void LateUpdate(PlayerControllerB __instance)
        {
            var Key = FPSSpectate.fpsKeyBind.Value;
            if (Keyboard.current[Key].wasPressedThisFrame && !debounced)
            {
                firstPerson = !firstPerson;
                debounced = true;
            }

            if (Keyboard.current[Key].wasReleasedThisFrame)
            {
                debounced = false;
            }

            if (__instance.spectatedPlayerScript != null && firstPerson)
            {
                Transform specPivotTransform = __instance.spectateCameraPivot.transform;
                Transform specVisorTransform = __instance.spectatedPlayerScript.visorCamera.transform;
                specPivotTransform.position = specVisorTransform.position + specVisorTransform.forward.normalized * SPECTATE_OFFSET;
                specPivotTransform.rotation = specVisorTransform.rotation;
            }
        }
    }
}
