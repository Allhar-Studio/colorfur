using UnityEngine;

public class DashTrailColor : MonoBehaviour
{
    [SerializeField] TrailRenderer trail;
    [SerializeField] SpriteRenderer sprite;

    private void OnEnable()
    {
        /*print("Test");
        trail.startColor = sprite.color;
        var endColor = sprite.color;
        endColor.a = 0f;
        trail.endColor = endColor;*/
    }

    private void Update()
    {
        trail.startColor = sprite.color;
        var endColor = sprite.color;
        endColor.a = 0f;
        trail.endColor = endColor;
    }
}
