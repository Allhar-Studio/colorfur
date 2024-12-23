using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(CollisionVisuals))]
public class CollisionVisualsEditor : Editor
{
    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();

        CollisionVisuals collVisual = (CollisionVisuals)target;

        if (GUILayout.Button("Toggle Collision Visuals"))
        {
            collVisual.ToggleVisuals();
        }
    }
}
