using UnityEngine;
using UnityEngine.SceneManagement;
using MoreMountains.Feedbacks;

public class SceneHanlder : Singleton<SceneHanlder>
{
    [SerializeField] MMF_Player loadFeedback;
    [SerializeField] MMF_Player reloadFeedback;

    private void OnEnable()
    {
        if (EventManager.Instance != null)
        {
            EventManager.Instance.OnLevelStart.AddListener(OnStartLevel);
            EventManager.Instance.OnReloadLevel.AddListener(OnRealoadLevel);
        }
    }

    private void OnDisable()
    {
        if (EventManager.Instance != null)
        {
            EventManager.Instance.OnLevelStart.RemoveListener(OnStartLevel);
            EventManager.Instance.OnReloadLevel.RemoveListener(OnRealoadLevel);
        }
    }

    private void OnStartLevel()
    {
        loadFeedback?.PlayFeedbacks();
    }

    private void OnRealoadLevel()
    {
        MMF_LoadScene reloadFb = reloadFeedback.GetFeedbackOfType<MMF_LoadScene>();
        var currentScene = SceneManager.GetActiveScene().name;
        reloadFb.DestinationSceneName = currentScene;

        if (!reloadFeedback.IsPlaying)
            reloadFeedback?.PlayFeedbacks();
    }
}
