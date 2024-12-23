using MoreMountains.Feedbacks;
using Udar.SceneField;
using UnityEngine;
using UnityEngine.UI;

public class HandleLevelUnlocked : MonoBehaviour
{
    [SerializeField] string sceneName;
    [SerializeField] GameObject lockedSprite;
    [SerializeField] bool isDefaultLevel;

    private Button button;
    private Image image;
    private MMF_Player feedbacks;
    private MMF_LoadScene loadFeedback;

    private void Start()
    {
        button = GetComponent<Button>();
        image = GetComponent<Image>();
        feedbacks = GetComponentInChildren<MMF_Player>();

        if (feedbacks != null)
            loadFeedback = feedbacks.GetFeedbackOfType<MMF_LoadScene>();

        if (loadFeedback != null)
            loadFeedback.DestinationSceneName = sceneName;
        
        if (isDefaultLevel || PlayerPrefs.GetInt(sceneName, 0) == 1)
        {
            image.raycastTarget = true;
            button.interactable = true;
            lockedSprite.SetActive(false);
        }
    }
}
