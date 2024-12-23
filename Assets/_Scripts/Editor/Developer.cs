using UnityEngine;
using UnityEditor;
using UnityEngine.SceneManagement;

public class Developer
{
    [MenuItem("Developer/Restart Level")]
    public static void RestartLevel()
    {
        var sceneName = SceneManager.GetActiveScene().name;
        SceneManager.LoadScene(sceneName);
    }

    [MenuItem("Developer/Abilities/Toggle Double Jump")]
    public static void ToggleDoubleJump()
    {
        var player = Object.FindObjectOfType<Player>();
        player.Data.hasDoubleJump = !player.Data.hasDoubleJump;
    }

    [MenuItem("Developer/Abilities/Toggle Dash")]
    public static void ToggleDash()
    {
        var player = Object.FindObjectOfType<Player>();
        player.Data.hasDash = !player.Data.hasDash;
    }

    [MenuItem("Developer/Frame Rate/Default FPS")]
    public static void ChangeFrameRateToDefault()
    {
        Application.targetFrameRate = -1;
    }

    [MenuItem("Developer/Frame Rate/10 FPS")]
    public static void ChangeFrameRateTo10()
    {
        Application.targetFrameRate = 10;
    }

    [MenuItem("Developer/Frame Rate/30 FPS")]
    public static void ChangeFrameRateTo30()
    {
        Application.targetFrameRate = 30;
    }
}
