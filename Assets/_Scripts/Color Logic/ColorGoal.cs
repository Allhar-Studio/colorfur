using UnityEngine;

public class ColorGoal : MonoBehaviour, IColorGoal
{
    [SerializeField] Color colorOne;
    [SerializeField] Color colorTwo;

    private SpriteRenderer sprite;

    private void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
        var newColor = MixColors();
        sprite.color = newColor;
    }

    private Color MixColors()
    {
        var newR = colorOne.r + colorTwo.r;
        var newG = colorOne.g + colorTwo.g;
        var newB = colorOne.b + colorTwo.b;

        double mixedR = newR / 2;
        double mixedG = newG / 2;
        double mixedB = newB / 2;

        Color newColor = new Color((float)mixedR, (float)mixedG, (float)mixedB);
        return newColor;
    }

    public Color GetGoalColor()
    {
        return sprite.color;
    }
}
