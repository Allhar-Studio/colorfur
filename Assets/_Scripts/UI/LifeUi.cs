using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System.Collections.Generic;

public class LifeUi : MonoBehaviour
{
    [SerializeField] Sprite starFull;
    [SerializeField] Sprite starEmpty;

    [SerializeField] List<Image> stars;

    private Player player;

    private void OnEnable()
    {
        if (PlayerEvents.Instance != null)
            PlayerEvents.Instance.OnChangeHealth.AddListener(SetLifeUI);
    }

    private void Start()
    {
        player = FindObjectOfType<Player>();
    }

    private void SetLifeUI(int newHealth)
    {
        for (int i = 0; i < stars.Count; i++)
        {
            if (i < newHealth)
                stars[i].sprite = starFull;

            if (i >= newHealth)
                stars[i].sprite = starEmpty;

            if (i > player.Data.maxLives)
                stars[i].gameObject.SetActive(false);
        }
    }

    private void OnDisable()
    {
        if (PlayerEvents.Instance != null)
            PlayerEvents.Instance.OnChangeHealth.RemoveListener(SetLifeUI);
    }
}
