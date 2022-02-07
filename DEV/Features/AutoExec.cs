using HarmonyLib;

namespace DEV {
  [HarmonyPatch(typeof(FejdStartup), "Awake")]
  public class FejdStartupAwake {
    public static void Postfix() {
      if (Settings.AutoExecBoot != "") Console.instance.TryRunCommand(Settings.AutoExecBoot);
    }
  }
  [HarmonyPatch(typeof(Game), "Awake")]
  public class AutoExec {
    public static void Postfix() {
      if (Settings.AutoExec != "") Console.instance.TryRunCommand(Settings.AutoExec);
    }
  }
}