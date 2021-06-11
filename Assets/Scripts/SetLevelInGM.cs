using UnityEngine;
using TMPro;
using System;
using UnityEngine.UI;

public class SetLevelInGM : MonoBehaviour
{
    public void SetLevel()
    {
        GameManager.CurrentLevel = Int32.Parse(gameObject.GetComponentInChildren<Text>().text);
        Debug.Log(GameManager.CurrentLevel);
    }
}
