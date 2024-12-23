using UnityEngine;
using UnityEngine.EventSystems;
using System.Collections.Generic;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    [SerializeField] Button defaultButton;
    [SerializeField] Image furTitle;
    [SerializeField] List<Color> colors;
    [SerializeField] List<Button> buttons;

    private void Start()
    {
        var colorId = Random.Range(0, colors.Count);
        var newColor = colors[colorId];

        if(furTitle != null)
            furTitle.color = newColor;

        foreach (var button in buttons)
        {
            ColorBlock colorVar = button.colors;
            colorVar.selectedColor = newColor;
            colorVar.highlightedColor = newColor;
            button.colors = colorVar;
        }

        EventSystem.current.SetSelectedGameObject(defaultButton.gameObject);
        defaultButton.Select();
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
