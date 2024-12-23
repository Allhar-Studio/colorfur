using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : Singleton<GameManager>
{
    private bool isPaused = false;

    public bool IsPaused { get { return isPaused; } }

    private void Update()
    {
        if (InputHandler.Instance.Pause() && !IsPaused && IsValidScene())
        {
            PauseGame();
        }
        else if (InputHandler.Instance.Pause() && IsPaused)
        {
            ResumeGame();
        }
    }

    public void PauseGame()
    {
        isPaused = true;
        InputHandler.Instance.ChangeActionMap("Empty");
        Time.timeScale = 0f;
    }

    public void ResumeGame()
    {
        isPaused = false;
        Time.timeScale = 1f;
        InputHandler.Instance.ChangeActionMap("Gameplay");
    }

    void OnApplicationFocus(bool hasFocus)
    {
        if (!hasFocus && !isPaused)
        {
            if(IsValidScene())
                PauseGame();
        }
    }

    public bool IsValidScene()
    {
        var sceneName = SceneManager.GetActiveScene().name;
        return sceneName.StartsWith("Level ");
    }
}
