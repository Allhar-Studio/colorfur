using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionVisuals : MonoBehaviour
{
    public void ToggleVisuals()
    {
        var visuals = GetComponentsInChildren<SpriteRenderer>();

        foreach (var visual in visuals)
        {
            visual.enabled = !visual.enabled;
        }
    }
}
