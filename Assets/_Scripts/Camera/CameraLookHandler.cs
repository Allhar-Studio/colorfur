using UnityEngine;
using Cinemachine;

public class CameraLookHandler : MonoBehaviour
{
    [SerializeField] CinemachineVirtualCamera normalCam;
    [SerializeField] CinemachineVirtualCamera lookCam;
    [SerializeField] float speed;

    private bool isLooking = false;

    private void Update()
    {
        if (InputHandler.Instance.IsLooking() && !isLooking)
        {
            lookCam.transform.position = normalCam.transform.position;
            isLooking = true;
            normalCam.Priority = 8;
        }
        else if (!InputHandler.Instance.IsLooking() && isLooking)
        {
            isLooking = false;
            normalCam.Priority = 10;
        }

        if (isLooking)
        {
            var newPos = new Vector3(InputHandler.Instance.Move().x * speed * Time.deltaTime, 0f, 0f);
            lookCam.transform.position += newPos;
        }
    }
}
