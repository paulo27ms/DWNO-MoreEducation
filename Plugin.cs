using BepInEx;
using BepInEx.Configuration;
using BepInEx.Logging;
using BepInEx.Unity.IL2CPP;
using HarmonyLib;

namespace MoreEducation;

[BepInPlugin(GUID, PluginName, PluginVersion)]
[BepInProcess("Digimon World Next Order.exe")]
public class Plugin : BasePlugin
{
    public static ManualLogSource Logger;
    internal const string GUID = "MoreEducation";
    internal const string PluginName = "MoreEducation";
    internal const string PluginVersion = "1.0.0";

    public static ConfigEntry<float> extraTime;
    public static float worldTimeTracker;
    public static bool worldTimeTrackerFlag = false;

    public override void Load()
    {
        extraTime = Config.Bind("#Education", "ExtraTimeUntilEducation", 120f, "How many extra in-game minutes until an education action is forcibly triggered, if education is no longer on the 2 hour cooldown (meaning education will be forced every 2 hours + the minutes set here).");
        Logger = Log;
        Harmony.CreateAndPatchAll(typeof(Plugin));
    }

    [HarmonyPatch(typeof(PlayerCtrl), "Walking")]
    [HarmonyPostfix]
    public static void Process_PostFix()
    {
        MainGameManager mainGameManager = MainGameManager.m_instance;
        PartnerCtrl partnerCtrl1 = mainGameManager.m_PartnerCtrls[0];
        float educationTime = StorageData.m_playerData.m_educationTime;
        float worldDay = StorageData.m_worldData.m_totalDay;
        float worldTime = StorageData.m_worldData.m_time;
        float worldTimeMinutes = worldDay * 1440 + worldTime;
        if (educationTime <= 0f)
        {
            if (extraTime.Value > 0f)
            {
                if (!worldTimeTrackerFlag)
                {
                    worldTimeTracker = worldTimeMinutes;
                    worldTimeTrackerFlag = true;
                }
                else
                {
                    if (worldTimeMinutes > worldTimeTracker + extraTime.Value)
                    {
                        worldTimeTrackerFlag = false;
                        partnerCtrl1.m_EmotionIdx = 101;
                    }
                }
            }
            else
            {
                partnerCtrl1.m_EmotionIdx = 101;
            }
        }
    }
}