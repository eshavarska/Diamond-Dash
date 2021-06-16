using TMPro;
using UnityEngine;

public class TimerPoints : MonoBehaviour
{
    private TextMeshProUGUI textField;

    void Start()
    {
        textField = GetComponent<TextMeshProUGUI>();

        float t = Timer.GameTime;

        string minutes = ((int)t / 60).ToString();
        string seconds = (t % 60).ToString("f0");

        textField.text = minutes + ":" + seconds;
    }
}
