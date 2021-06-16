using UnityEngine;
using UnityEngine.Experimental.U2D.Animation;
using UnityEngine.Tilemaps;

public class PlayerController_backup : MonoBehaviour
{
    public Tilemap tiles;
    public SpriteResolver spriteResolver;
    public GameObject Diamonds;

    public Vector3Int location;

    private float speed = 3f;
    private Vector2 dest = Vector2.zero;
    private Vector2 up = new Vector2(0, 0.3f);
    private Vector2 right = new Vector2(0.3f, 0);
    private Vector2 dir = Vector2.zero;

    private System.Random rand;

    private static int money = 0;
    public static int Money
    {
        get { return money; }
        set { money = value; }

    }

    void Start()
    {
        dest = transform.position;
        spriteResolver.SetCategoryAndLabel("Body", GameManager.Gender.ToString());
        rand = new System.Random();
    }

    void FixedUpdate()
    {
        if (Diamonds.transform.childCount <= 0)
        {
            ScreenManager.Win();
        }

        if (Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.W))
        {
            dest = (Vector2)transform.position + up;
            dir = dest + new Vector2(0, 0.2f) - (Vector2)transform.position;
        } 
        if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
        {
            if (GetComponent<SpriteRenderer>().flipX)
            {
                GetComponent<SpriteRenderer>().flipX = false;
            }
            dest = (Vector2)transform.position + right;
            dir = dest - (Vector2)transform.position;
        }           
        if (Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.S))
        {
            dest = (Vector2)transform.position - up;
            dir = dest - new Vector2(0, 0.2f) - (Vector2)transform.position;
        }
            
        if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))
        {
            if (!GetComponent<SpriteRenderer>().flipX)
            {
                GetComponent<SpriteRenderer>().flipX = true;
            }
            dest = (Vector2)transform.position - right;
            dir = dest - (Vector2)transform.position;
        }
           


        if (Input.GetKey(KeyCode.Space))
        {
            Dig(dir);
            GetComponent<Animator>().SetTrigger("dig");
        }

        if((Vector2)transform.position != dest)
        {
            Move();
            GetComponent<Animator>().SetBool("walk", true);
        }
        else
        {
            GetComponent<Animator>().SetBool("walk", false);
        }

       
    }

    protected void Dig(Vector2 dir)
    {
        Vector2 pos = transform.position;
        RaycastHit2D hit = Physics2D.Linecast(pos + dir, pos);
        if (hit.collider != null)
        {
            if (hit.collider.tag == "Ground")
            {
                location = tiles.WorldToCell(pos + dir);
                tiles.SetTile(location, null);
            }
        }

    }

    public virtual void Move()
    {
        // Move closer to Destination
        Vector2 p = Vector2.MoveTowards(transform.position, dest, speed * Time.fixedDeltaTime);
        GetComponent<Rigidbody2D>().MovePosition(p);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Diamond")
        {
            Destroy(other.gameObject);
            money += 100;
        }
        if (other.gameObject.tag == "Bitcoin")
        {
            Destroy(other.gameObject);
            money += rand.Next(-100, 300);
        }
    }
}
