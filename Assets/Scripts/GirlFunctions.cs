using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GirlFunctions : MonoBehaviour
{
    private void OnMouseDown()
    {
        GameManager.Gender = GameManager.GenderName.Girl;
        Debug.Log(GameManager.Gender);
    }

}
