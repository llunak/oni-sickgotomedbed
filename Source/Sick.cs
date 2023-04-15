using HarmonyLib;

namespace SickGoToMedBed
{
    [HarmonyPatch(typeof(Clinic))]
    public class Clinic_Patch
    {
        // Allow assigning sick dupes to the medical bed, i.e. copy that part from the auto variant.
        // Additionally the CanManuallyAssignTo() function is a prerequisite for CanAutoAssignTo(),
        // so without this automatic going to the hospital wouldn't work.
        [HarmonyPostfix]
        [HarmonyPatch(nameof(CanManuallyAssignTo))]
        public static void CanManuallyAssignTo(Clinic __instance, ref bool __result, MinionAssignablesProxy worker)
        {
            MinionIdentity minionIdentity = worker.target as MinionIdentity;
            if (minionIdentity != null)
            if (!__result && IsValidEffect(__instance.diseaseEffect))
                __result = minionIdentity.GetComponent<MinionModifiers>().sicknesses.Count > 0;
        }

        private static bool IsValidEffect(string effect)
        {
            if (effect != null)
                return effect != "";
            return false;
        }
    }
}
