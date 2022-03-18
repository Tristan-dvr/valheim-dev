using HarmonyLib;

namespace ServerDevcommands {
  [HarmonyPatch(typeof(Player), nameof(Player.IsDodgeInvincible))]
  public class GodAlwaysDodge {
    public static void Postfix(Player __instance, ref bool __result) {
      var noUsage = Settings.GodModeAlwaysDodge && __instance.InGodMode();
      if (noUsage) __result = true;
    }
  }
}
