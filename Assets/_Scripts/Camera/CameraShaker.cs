using UnityEngine;
using Cinemachine;
using DG.Tweening;

public class CameraShaker : MonoBehaviour
{
    [SerializeField] CinemachineVirtualCamera vCam;
    private CinemachineBasicMultiChannelPerlin camChannelPerlin;

    private void OnEnable()
    {
        if (EventManager.Instance != null)
            EventManager.Instance.OnCameraShake.AddListener(CameraShake);
    }

    private void Start()
    {
        camChannelPerlin = vCam.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();
    }

    private void Update()
    {
        
    }

    public void CameraShake(float amplitude, float frequency, float time)
    {
        camChannelPerlin.m_AmplitudeGain = amplitude;
        camChannelPerlin.m_FrequencyGain = frequency;
        DOVirtual.DelayedCall(time, () => { 
            camChannelPerlin.m_AmplitudeGain = 0;
            camChannelPerlin.m_FrequencyGain = 1;
        }, false);
    }

    private void OnDisable()
    {
        if (EventManager.Instance != null)
            EventManager.Instance.OnCameraShake.RemoveListener(CameraShake);
    }
}
