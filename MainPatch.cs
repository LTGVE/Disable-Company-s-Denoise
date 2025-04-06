using BepInEx.Configuration;
using Dissonance.Audio.Capture;
using Dissonance.Config;
using GameNetcodeStuff;
using HarmonyLib;
using UnityEngine;
using static Plugin;

public class MainPatch
{
    [HarmonyPatch(typeof(PlayerControllerB))]
    public class DissonanceVoicePatch
    {
        public static ConfigEntry<bool> enableNoiseSuppression;
        public static void initConfig()
        {
            enableNoiseSuppression = config.Bind<bool>("DissonanceVoice", "Enable Noise Suppression", false, "Enable Dissonance Voice Noise Suppression(Need to restart Game)");
        }
        [HarmonyPostfix]

        [HarmonyPatch(typeof(PlayerControllerB), nameof(PlayerControllerB.SpawnPlayerAnimation))]
        public static void Update(ref PlayerControllerB __instance)
        {
            var noiseLevel = enableNoiseSuppression.Value ? NoiseSuppressionLevels.Moderate : NoiseSuppressionLevels.Disabled;
            Debug.Log("Noise Suppression Level: " + noiseLevel.ToString());
            VoiceSettings.Instance.DenoiseAmount = noiseLevel;
        }
    }
}

