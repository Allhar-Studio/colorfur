using MoreMountains.Feedbacks;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ColorChangerDestructable : ColorChanger
{
    [SerializeField] Collider2D coll;

    [SerializeField] List<SpriteRenderer> secondarySprites;

    [SerializeField] MMF_Player feedback;

    public override Color GetColor()
    {
        var color = base.GetColor();
        sprite.enabled = false;
        coll.enabled = false;

        if (feedback != null)
            feedback.PlayFeedbacks();

        Destroy(gameObject, 0.1f);

        if (secondarySprites != null && secondarySprites.Any())
            secondarySprites.ForEach(s => s.enabled = false);

        return color;
    }
}
