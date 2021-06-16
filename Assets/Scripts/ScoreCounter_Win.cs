using UnityEngine;
using TMPro;

public class ScoreCounter_Win : MonoBehaviour
{
    private TextMeshProUGUI textField;

    // Start is called before the first frame update
    void Start()
    {
        float t = Timer.GameTime;
        textField = GetComponent<TextMeshProUGUI>();

        int minutes = ((int)t / 60);
        int seconds = ((int)(t % 60));
        Debug.Log("Money before calculation: " + PlayerController.Money);

        if (minutes == 0 && seconds <= 30)
        {
            PlayerController.Money *= 2;
        }
        else if (minutes == 0 && seconds <= 60)
        {

            double temp = PlayerController.Money * 1.5;
            PlayerController.Money = (int)temp;
        }
        else if (minutes >= 2)
        {
            double temp = PlayerController.Money * 0.5;
            PlayerController.Money = (int)temp;
        }

        Debug.Log("Money after calculation: " + PlayerController.Money);

        textField.text = PlayerController.Money.ToString();
    }

}
