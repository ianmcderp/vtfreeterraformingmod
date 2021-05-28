using HarmonyLib;
using System;
using System.Reflection;
using VoxelTycoon;
using VoxelTycoon.Modding;

namespace VTFreeTerraformingMod
{
    public class VTFreeTerraformingMod : Mod
    {
        Logger _logger = new Logger<VTFreeTerraformingMod>();

        protected override void OnGameStarted()
        {
            try
            {
                var harmony = new Harmony("com.github.ianmcderp");
                Harmony.DEBUG = true;
                harmony.PatchAll(Assembly.GetExecutingAssembly());
                harmony.PatchAll();
            }
            catch (Exception e)
            {
                _logger.LogError("Loading VTFreeTerraformingMod failed");
                _logger.LogException(e);
            }
        }
    }

    [HarmonyPatch(typeof(VoxelTycoon.Tools.ToolHelper), "GetFlattenPrice", new[] { typeof(Xyz), typeof(int) })]
    class PatchedToolHelper
    {
        static void Postfix(ref double __result)
        {   
            __result = 0;
        }
    }
}
