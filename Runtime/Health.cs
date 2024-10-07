using UnityEngine;
using UnityEngine.Events;

namespace GameplayCore
{
    public class Health : MonoBehaviour, IDamageable
    {
        [field: Header("Tuning")]
        [field: SerializeField] public float Current { get; protected set; } = 100f;
        [field: SerializeField] public float Max { get; protected set; } = 100f;

        public float Percentage => Current / Max;
        public bool IsAlive => Current >= 1;

        [Header("Events")]
        public UnityEvent<DamageInfo> OnDamage;
        public UnityEvent<DamageInfo> OnDeath;

        public virtual void Damage(DamageInfo damageInfo)
        {
            if(!IsAlive) return;

            Current = Mathf.Clamp(Current - damageInfo.Amount, 0f, Max);
            OnDamage.Invoke(damageInfo);
            if(!IsAlive) OnDeath.Invoke(damageInfo);
        }

        [ContextMenu("Damage Test")]
        public virtual void DamageTest()
        {
            DamageInfo damageInfo = new DamageInfo
            {
                Amount = Max * 0.1f,
                IsCrit = false,
                Instigator = gameObject,
                Source = gameObject,
                Victim = gameObject
            };
            Damage(damageInfo);
        }
    }
}
