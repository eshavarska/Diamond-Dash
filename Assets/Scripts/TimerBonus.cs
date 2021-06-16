using TMPro;
using UnityEngine;

public class TimerBonus : MonoBehaviour
{
    private TextMeshProUGUI textField;

    private void Start()
    {
        textField = GetComponent<TextMeshProUGUI>();

        float t = Timer.GameTime;

        int minutes = ((int)t / 60);
        int seconds = ((int)(t % 60));

        if(minutes == 0 && seconds <= 30)
        {
            textField.text = "Score x2";
            textField.color = Color.green;
        }
        else if(minutes == 0 && seconds <= 60)
        {
            textField.text = "Score x1.5";
            textField.color = Color.green;
        }
        else if(minutes < 2)
        {
            textField.text = "Score x1";
        }
        else
        {
            textField.text = "Score x0.5";
            textField.color = Color.red;
        }
    }
}
