using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FaderUI : MonoBehaviour
{
    [SerializeField] List<GameObject> faderCanvasImages;

    private void Awake()
    {
        foreach (var image in faderCanvasImages)
        {
            image.SetActive(true);
        }
    } 
}

