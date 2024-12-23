using DG.Tweening;
using UnityEngine;

public class TweenSettings : MonoBehaviour
{
    [SerializeField] int tweenCapacity = 300;
    [SerializeField] int sequencyCapacity = 100;
    private void Awake()
    {
        DOTween.SetTweensCapacity(tweenCapacity, sequencyCapacity);
    }
}
