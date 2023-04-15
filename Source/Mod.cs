using HarmonyLib;

namespace SickGoToMedBed
{
    public class Mod : KMod.UserMod2
    {
        public override void OnLoad( Harmony harmony )
        {
            base.OnLoad( harmony );
            DiseasesReimagined_SlimeLethalSickness_Patch.Patch( harmony );
        }
    }
}
