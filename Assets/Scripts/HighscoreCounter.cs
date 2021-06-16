using TMPro;
using UnityEngine;

public class HighscoreCounter : MonoBehaviour
{
    private TextMeshProUGUI textField;

    // Start is called before the first frame update
    void Start()
    {
        if (GameManager.HighScores[GameManager.CurrentLevel-1] < PlayerController.Money)
        {
            GameManager.HighScores[GameManager.CurrentLevel-1] = PlayerController.Money;
        }

        textField = GetComponent<TextMeshProUGUI>();
        textField.text = GameManager.HighScores[GameManager.CurrentLevel-1].ToString();

        PlayerController.Money = 0;
    }
}
