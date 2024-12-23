using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using TMPro;

public class WorldSelection : MonoBehaviour
{
    [Header("World Settings")]
    public int world = 1;
    [SerializeField] string worldTitle;
    [SerializeField] TextMeshProUGUI titleAsset;

    [Header("Levels")]
    [SerializeField] GameObject levels;

    [Header("Buttons")]
    [SerializeField] Button defaultButton;
    [SerializeField] List<Button> buttons;
    [SerializeField] List<Color> colors;

    private Animator animator;

    private void Start()
    {
        animator = GetComponent<Animator>();

        titleAsset.text = worldTitle;
    }

    public void EnterWorld()
    {
        animator.SetTrigger("Enter");
        levels.SetActive(true);

        var colorId = Random.Range(0, colors.Count);
        var newColor = colors[colorId];

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

    public void ExitWorld()
    {
        animator.SetTrigger("Exit");
        levels.SetActive(false);
    }
}
