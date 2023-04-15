using HarmonyLib;
using UnityEngine;
using System;
using System.Reflection;

namespace SickGoToMedBed
{
    // Patch https://github.com/skairunner/sky-oni-mods/pull/97 ,
    // until it gets fixed upstream.
    public class DiseasesReimagined_SlimeLethalSickness_Patch
    {
        public static void Patch(Harmony harmony)
        {
            ConstructorInfo info = AccessTools.Constructor( AccessTools.TypeByName( "DiseasesReimagined.SlimeLethalSickness" ));
            if( info != null )
                harmony.Patch( info, postfix: new HarmonyMethod(
                    typeof( DiseasesReimagined_SlimeLethalSickness_Patch ).GetMethod( "ctor" )));
        }
        public static void ctor(ref Klei.AI.Sickness.Severity ___severity)
        {
            ___severity = Klei.AI.Sickness.Severity.Critical;
        }
    }
}
