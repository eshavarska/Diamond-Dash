using UnityEngine;
using UnityEngine.SceneManagement;

public class ScreenManager : MonoBehaviour
{
    public void LoadLevel()
    {
        SceneManager.LoadScene("Level_" + GameManager.CurrentLevel.ToString());
    }

    public static void MainMenuScene()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public static void LevelsScene()
    {
        SceneManager.LoadScene("Levels");
    }

    public static void Win()
    {
        SceneManager.LoadScene("Win");
    }

    public static void GameOver()
    {
       SceneManager.LoadScene("GameOver");
    }


    public static void HighScores()
    {
        SceneManager.LoadScene("HighScores");
    }
}
