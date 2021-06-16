using UnityEngine;

public class GirlFunctions : MonoBehaviour
{
    private void OnMouseDown()
    {
        GameManager.Gender = GameManager.GenderName.Girl;
        Debug.Log(GameManager.Gender);
    }

}
