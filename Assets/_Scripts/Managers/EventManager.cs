using UnityEngine;
using UnityEngine.Events;

public class EventManager : Singleton<EventManager>
{
    public UnityEvent<float, float, float> OnCameraShake;

    public UnityEvent OnReloadLevel;
    public UnityEvent OnLevelStart;
    public UnityEvent OnChangeLevel;

    public void TriggerCameraShakeEvent(float amplitude, float frequency, float time)
    {
        OnCameraShake?.Invoke(amplitude, frequency, time);
    }

    public void TriggerReloadLevelEvent()
    {
        OnReloadLevel?.Invoke();
    }

    public void TriggerLevelStartEvent()
    {
        OnLevelStart?.Invoke();
    }

    public void TriggerChangeLevelEvent()
    {
        OnChangeLevel?.Invoke();
    }
}
