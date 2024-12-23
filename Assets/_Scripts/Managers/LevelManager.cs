using MoreMountains.Feedbacks;
using Udar.SceneField;
using UnityEngine;
using UnityEngine.Events;

public class LevelManager : Singleton<LevelManager>
{
    [SerializeField] string sceneName;
    [SerializeField] MMF_Player nextLevelFbPlayer;

    private MMF_LoadScene nextLevelFb;
    private MMF_Destroy destroyObjFb;
    private Player player;

    private bool isChangingScene = false;

    public bool IsChangingScene { get { return isChangingScene; } }

    private void OnEnable()
    {
        if (EventManager.Instance != null)
            EventManager.Instance.OnChangeLevel.AddListener(NextScene);
    }

    private void OnDisable()
    {
        if (EventManager.Instance != null)
            EventManager.Instance.OnChangeLevel.RemoveListener(NextScene);
    }

    private void Start()
    {
        EventManager.Instance.TriggerLevelStartEvent();
        nextLevelFb = nextLevelFbPlayer.GetFeedbackOfType<MMF_LoadScene>();
        destroyObjFb = nextLevelFbPlayer.GetFeedbackOfType<MMF_Destroy>();
        player = Player.Instance;
    }

    public void NextScene()
    {
        nextLevelFb.DestinationSceneName = sceneName;

        var playerObj = player.gameObject;
        destroyObjFb.TargetGameObject = playerObj;

        PlayerPrefs.SetInt(sceneName, 1);

        nextLevelFbPlayer.PlayFeedbacks();

        isChangingScene = true;
    }
}
