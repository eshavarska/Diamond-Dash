using System.Collections;
using UnityEngine;
using TMPro;
using System;
using System.Linq;

public class Highscore_list : MonoBehaviour
{
    private TextMeshProUGUI textField;
    private int level;

    // Start is called before the first frame update
    void Start()
    {
        textField = GetComponent<TextMeshProUGUI>();
        level = (int)Char.GetNumericValue(gameObject.name.Last());
        textField.text = GameManager.HighScores[level-1].ToString();
    }
}

