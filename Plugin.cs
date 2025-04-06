using BepInEx;
using BepInEx.Configuration;
using HarmonyLib;

[BepInPlugin("DisableCompanysDenoise", "DisableCompanysDenoise", "1.0.0")]
public class Plugin : BaseUnityPlugin
{
    public static ConfigFile config;
    // public static string config = Path.Combine(Paths.ConfigPath + "/lt_gve.LCGraphicRemover.cfg");
    public static Plugin Instance { get; private set; } = null!;

    private void Awake()
    {
        Instance = this;
        config = base.Config;
        MainPatch.DissonanceVoicePatch.initConfig();
        Harmony.CreateAndPatchAll(typeof(MainPatch.DissonanceVoicePatch));
        Logger.LogInfo($"Disable Company's Denoise v1.0.0 has loaded!");
    }
}