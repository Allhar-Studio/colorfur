using MoreMountains.Feedbacks;
using UnityEngine;

public class ColorHandler : MonoBehaviour
{
    [SerializeField] SpriteRenderer sprite;
    [SerializeField] float errorMargin = 0.01f;

    private bool inCleaner = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (inCleaner)
            return;

        IColorCleaner cleaner = collision.GetComponent<IColorCleaner>();
        if (cleaner != null)
        {
            Player.Instance.Feedbacks.WaterFeedback.PlayFeedbacks();
        }

        IColorChanger changer = collision.GetComponent<IColorChanger>();
        if (changer != null)
        {
            Color changerColor = changer.GetColor();

            if (sprite.color == Color.white)
            {
                sprite.color = changerColor;
            }

            else
            {
                MixColors(changerColor);
            }
        }

        IColorGoal goal = collision.GetComponent<IColorGoal>();
        if (goal != null)
        {
            CheckIfIsGoalColor(goal);
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        IColorCleaner cleaner = collision.GetComponent<IColorCleaner>();
        if (cleaner != null)
        {
            inCleaner = true;
            sprite.color = Color.white;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        IColorCleaner cleaner = collision.GetComponent<IColorCleaner>();
        if (cleaner != null)
        {
            inCleaner = false;
        }
    }

    private void MixColors(Color changerColor)
    {
        var newR = sprite.color.r + changerColor.r;
        var newG = sprite.color.g + changerColor.g;
        var newB = sprite.color.b + changerColor.b;

        double mixedR = newR / 2;
        double mixedG = newG / 2;
        double mixedB = newB / 2;

        Color newColor = new Color((float)mixedR, (float)mixedG, (float)mixedB);
        sprite.color = newColor;
    }

    private void CheckIfIsGoalColor(IColorGoal goal)
    {
        var color = sprite.color;
        var goalColor = goal.GetGoalColor();

        /*if (Mathf.Abs(color.r - goalColor.r) < 0.01f &&
           Mathf.Abs(color.g - goalColor.g) < 0.01f &&
           Mathf.Abs(color.b - goalColor.b) < 0.01f)
            ChangeLevel();*/

        if (Mathf.Abs(color.r - goalColor.r) < errorMargin &&
           Mathf.Abs(color.g - goalColor.g) < errorMargin &&
           Mathf.Abs(color.b - goalColor.b) < errorMargin)
            ChangeLevel();
    }

    private void ChangeLevel()
    {
        EventManager.Instance.TriggerChangeLevelEvent();
    }
}
