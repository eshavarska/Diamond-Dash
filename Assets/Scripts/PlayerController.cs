using UnityEngine;
using UnityEngine.Experimental.U2D.Animation;


public class PlayerController : MonoBehaviour
{
    public SpriteResolver spriteResolver;
    public GameObject Diamonds;

    public RuntimeAnimatorController GirlAnimator;
    public RuntimeAnimatorController BoyAnimator;

    private float speed = 3f;
    private Vector2 dest = Vector2.zero;
    private Vector2 up = new Vector2(0, 0.3f);
    private Vector2 right = new Vector2(0.3f, 0);
    private Vector2 currentPos, lastPos;

    private System.Random rand;

    private static int money;
    public static int Money
    {
        get { return money; }
        set { money = value; }

    }

    void Start()
    {
        money = 0;
        dest = transform.position;
        currentPos = transform.position;

        if (GameManager.Gender == GameManager.GenderName.Girl)
            gameObject.GetComponent<Animator>().runtimeAnimatorController = GirlAnimator;
        else 
            gameObject.GetComponent<Animator>().runtimeAnimatorController = BoyAnimator;

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
        } 
        if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
        {
            if (GetComponent<SpriteRenderer>().flipX)
            {
                GetComponent<SpriteRenderer>().flipX = false;
            }
            dest = (Vector2)transform.position + right;
        }           
        if (Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.S))
        {
            dest = (Vector2)transform.position - up;
        }
            
        if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))
        {
            if (!GetComponent<SpriteRenderer>().flipX)
            {
                GetComponent<SpriteRenderer>().flipX = true;
            }
            dest = (Vector2)transform.position - right;
        }

       

        if ((Vector2)transform.position != dest)
        {
            Move();
        }

        lastPos = currentPos;
        currentPos = transform.position;

        if (currentPos == lastPos)
        {
            GetComponent<Animator>().SetBool("walk", false);
        }
        else
        {
            GetComponent<Animator>().SetBool("walk", true);
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
