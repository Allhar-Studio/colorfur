using System;
using UnityEngine;
using UnityEngine.Events;

public class PlayerEvents : Singleton<PlayerEvents>
{
    //public event Action<IState> TestEvent;
    public UnityEvent<float> OnDashEvent;
    public UnityEvent<Vector2, DamagerType> OnTakeDamage;
    public UnityEvent<int> OnChangeHealth;

    public void TriggerDashEvent(float dashTime)
    {
        OnDashEvent?.Invoke(dashTime);
    }

    public void TriggerDamageEvent(Vector2 damagerPos, DamagerType damagerType)
    {
        OnTakeDamage?.Invoke(damagerPos, damagerType);
    }

    public void TriggerChangeHealthEvent(int health)
    {
        OnChangeHealth?.Invoke(health);
    }
}
