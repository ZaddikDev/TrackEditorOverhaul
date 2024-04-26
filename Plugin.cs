using BepInEx;
using BepInEx.Logging;
using HarmonyLib;

namespace ZadDev.TrackEditorOverhaul
{
    [BepInPlugin(modGUID, modName, modVersion)]
    public class TrackEditorOvBase : BaseUnityPlugin
    {
        private const string modGUID = "ZadDev.TrackEditorOverhaul";
        private const string modName = "Track Editor Overhaul";
        private const string modVersion = "0.1.0";

        private readonly Harmony harmony = new Harmony(modGUID);

        public static TrackEditorOvBase Instance;

        public ManualLogSource mlogger;

        void Awake()
        {
            if(Instance == null) Instance = this;

            mlogger = BepInEx.Logging.Logger.CreateLogSource(modGUID);

            mlogger.LogInfo("Loading Track Editor Overhaul. Applying patches...");
            harmony.PatchAll();
            mlogger.LogInfo("Successfully applied Harmony patches");
        }
    }
}
