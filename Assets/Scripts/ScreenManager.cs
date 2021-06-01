using UnityEngine;
using UnityEngine.SceneManagement;

public class ScreenManager : MonoBehaviour
{

    public void StartScene()
    {
        SceneManager.LoadScene("SampleScene");
    }

    public void MainMenuScene()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
