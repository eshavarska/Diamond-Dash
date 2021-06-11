using UnityEngine;
using UnityEngine.SceneManagement;

public class ScreenManager : MonoBehaviour
{
    public static void Level1()
    {
        SceneManager.LoadScene("Level_1");
    }  
    public static void Level2()
    {
        SceneManager.LoadScene("Level_2");
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

    public static void LastLevel()
    {
        SceneManager.LoadScene("Level_" + GameManager.CurrentLevel.ToString());
    }
}
