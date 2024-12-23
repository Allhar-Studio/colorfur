using UnityEngine;
using System.Collections.Generic;
using System.Linq;
using MoreMountains.Feedbacks;

public class LevelSelection : MonoBehaviour
{
    [SerializeField] List<WorldSelection> worlds;

    [SerializeField] MMF_Player loadFeedback;

    private int currentWorldId = 1;

    private void Start()
    {
        loadFeedback.PlayFeedbacks();
        var currentWorld = worlds[0];
        currentWorld.EnterWorld();
    }

    private void Update()
    {
        if (InputHandler.Instance.Next() && currentWorldId < worlds.Count)
        {
            NextWorld();
        }

        if (InputHandler.Instance.Prev() && currentWorldId > 1)
        {
            PrevWorld();
        }
    }

    private void NextWorld()
    {
        var currentWorld = worlds.Where(w => w.world == currentWorldId).First();
        currentWorld.ExitWorld();
        currentWorldId++;
        var nextWorld = worlds.Where(w => w.world == currentWorldId).First();
        nextWorld.EnterWorld();
    }

    private void PrevWorld()
    {
        var currentWorld = worlds.Where(w => w.world == currentWorldId).First();
        currentWorld.ExitWorld();
        currentWorldId--;
        var nextWorld = worlds.Where(w => w.world == currentWorldId).First();
        nextWorld.EnterWorld();
    }
}
