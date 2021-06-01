using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoyFunctions : MonoBehaviour
{
    private void OnMouseDown()
    {
        GameManager.Gender = GameManager.GenderName.Boy;
        Debug.Log(GameManager.Gender);
    }
}
