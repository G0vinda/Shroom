using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Bean
{
    public class RedBean : Bean
    {
        public enum Effect
        {
            Spread,
            CriticalChance,
            CriticalMultiplier,
            InstantKill,
            KillFart
        }

        public List<Effect> effectOrder = new List<Effect>()
        {
            Effect.Spread, 
            Effect.CriticalChance,
            Effect.CriticalMultiplier,
            Effect.InstantKill,
            Effect.KillFart
        };
        
        public static class Attributes
        {
            public static int Collected = 0;
            public static int ExtraShotPerBean = 1;
            public static float CriticalChancePerBean = 0.05f;
            public static float CriticalMultiplierPerBean = 0.25f;
            public static float BaseCriticalMultiplier = 1.5f;
            public static float InstantKillChancePerBean = 0.025f;
            public static float KillFartRadius = 10.0f;
            public static List<Effect> ActivatedEffects = new List<Effect>();
            
            public static Dictionary<int, string> EffectInfo = new Dictionary<int, string>() {{1, "Shoot more red shots"}, 
                {2, "Red shots can deal critical damage"}, {3, "Critical damage multiplier increased"}, {4, "Chance for instantly kill enemies"}, {5, "Fart of Doom"}};
            public static void ToDefault()
            {
                Collected = 0;
                ActivatedEffects.Clear();
            }
        }
    }
}
