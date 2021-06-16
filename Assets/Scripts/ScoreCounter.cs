using UnityEngine;
using TMPro;

public class ScoreCounter : MonoBehaviour
{
    private TextMeshProUGUI scoreCounterText;

    // Start is called before the first frame update
    void Start()
    {
        scoreCounterText = GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        scoreCounterText.text = PlayerController.Money.ToString();
    }
}
