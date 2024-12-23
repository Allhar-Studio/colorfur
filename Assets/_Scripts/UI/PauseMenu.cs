using DG.Tweening;
using MoreMountains.Feedbacks;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] GameObject pauseCanvas;

    [SerializeField] Button defaultButton;

    [SerializeField] List<Button> buttons;
    [SerializeField] List<Color> colors;

    private bool isPaused = false;

    private void InitPauseMenu()
    {
        var colorId = Random.Range(0, colors.Count);
        var newColor = colors[colorId];

        foreach (var button in buttons)
        {
            ColorBlock colorVar = button.colors;
            colorVar.selectedColor = newColor;
            colorVar.highlightedColor = newColor;
            button.colors = colorVar;
        }

        pauseCanvas.SetActive(true);

        EventSystem.current.SetSelectedGameObject(defaultButton.gameObject);
        defaultButton.Select();
    }

    private void Update()
    {
        if (GameManager.Instance.IsPaused && !isPaused)
        {
            isPaused = true;
            InitPauseMenu();
        }
        else if (!GameManager.Instance.IsPaused && isPaused)
        {
            isPaused = false;
            UnPause();
        }
    }

    public void UnPause()
    {
        GameManager.Instance.ResumeGame();
        DOVirtual.DelayedCall(0.2f, () => { pauseCanvas.SetActive(false); }, false);
    }

    public void Quit()
    {
        #if UNITY_EDITOR
            // Application.Quit() does not work in the editor so
            // UnityEditor.EditorApplication.isPlaying need to be set to false to end the game
            UnityEditor.EditorApplication.isPlaying = false;
        #endif

        Application.Quit();
    }
}
