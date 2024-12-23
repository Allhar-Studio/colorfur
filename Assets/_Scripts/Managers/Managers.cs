using UnityEngine;

public class Managers : SingletonPersistent<Managers>
{
    [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
    private static void Setup()
    {
        GameObject _Managers_Prefab = Resources.Load<GameObject>("Managers");
        if (_Managers_Prefab == null)
        {
            Debug.LogError("Failed to Find GameManager Prefab, Game may behave unexpectedly");
            return;
        }
        Instantiate(_Managers_Prefab);
    }
    //TODO: Pause menu and option to go back to level selection
}
