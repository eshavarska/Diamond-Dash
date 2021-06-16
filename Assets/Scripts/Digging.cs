using UnityEngine;
using UnityEngine.Tilemaps;

public class Digging : MonoBehaviour
{
    public Tilemap tiles;
    public Vector3Int location;

    private Vector2 up = new Vector2(0, 0.5f);
    private Vector2 right = new Vector2(0.5f, 0);

    private Vector2 dir = Vector2.zero;

    void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.W))
        {
            dir = up;
        }
        if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
        {
            dir = right;
        }
        if (Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.S))
        {
            dir = -up;
        }

        if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))
        {
            dir = -right;
        }


        if (Input.GetKey(KeyCode.Space))
        {
            Dig(dir);
            GetComponent<Animator>().SetTrigger("dig");
        }

    }
    protected void Dig(Vector2 dir)
    {
        Vector2 pos = (Vector2)transform.position + new Vector2(-0.1f, 0.5f);
        RaycastHit2D hit = Physics2D.Linecast(pos + dir, pos);
        if (hit.collider != null)
        {
            if (hit.collider.tag == "Ground")
            {
                location = tiles.WorldToCell(pos + dir);
                tiles.SetTile(location, null);

                FindObjectOfType<AudioManager>().Play("Dig");
            }
        }

    }
}
