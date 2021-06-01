using UnityEngine;

public class ChangeCursor : MonoBehaviour
{
    public Texture2D cursor;

    void OnMouseEnter()
    {
        Cursor.SetCursor(cursor, Vector2.zero, CursorMode.Auto);
        GetComponent<Animator>().SetBool("hover", true);
    }

    void OnMouseExit()
    {
        Cursor.SetCursor(null, Vector2.zero, CursorMode.Auto);
        GetComponent<Animator>().SetBool("hover", false);
    }

}
