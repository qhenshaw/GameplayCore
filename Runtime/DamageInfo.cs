using UnityEngine;

namespace GameplayCore
{
    public struct DamageInfo
    {
        public float Amount { get; set; }
        public bool IsCrit { get; set; }
        public GameObject Instigator { get; set; }
        public GameObject Source { get; set; }
        public GameObject Victim { get; set; }
        public object AdditionalArgs { get; set; }

        public DamageInfo(float amount, bool isCrit, GameObject instigator, GameObject source, GameObject victim)
        {
            Amount = amount;
            IsCrit = isCrit;
            Instigator = instigator;
            Source = source;
            Victim = victim;
            AdditionalArgs = null;
        }

        public DamageInfo(float amount, bool isCrit, GameObject instigator, GameObject source, GameObject victim, object additionalArgs)
        {
            Amount = amount;
            IsCrit = isCrit;
            Instigator = instigator;
            Source = source;
            Victim = victim;
            AdditionalArgs = additionalArgs;
        }
    }
}
