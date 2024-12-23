using UnityEngine;

public class LookUI : MonoBehaviour
{
    [SerializeField] GameObject lookCanvas;

    private bool isLooking = false;

    private void Update()
    {
        if (InputHandler.Instance.IsLooking() && !isLooking)
        {
            isLooking = true;
            ToggleCanvas(isLooking);
        }
        else if (!InputHandler.Instance.IsLooking() && isLooking)
        {
            isLooking = false;
            ToggleCanvas(isLooking);
        }
    }

    private void ToggleCanvas(bool active)
    {
        lookCanvas.SetActive(active);
    }
}
