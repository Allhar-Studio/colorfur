using UnityEngine;

public class ColorChanger : MonoBehaviour, IColorChanger
{
    [SerializeField] protected SpriteRenderer sprite;
    private Color spriteColor;

    public virtual Color GetColor()
    {
        return spriteColor;
    }

    private void Start()
    {
        spriteColor = sprite ? sprite.color : GetComponent<SpriteRenderer>().color;
    }
}
