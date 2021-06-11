using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class EnemyController : MonoBehaviour
{
    public GameObject gameOverText;

    protected float speed = 0.03f;
    public Vector2 dest;
    protected Vector2 up, down, left, right;
    private Vector2 currentPos, lastPos;

    List<Vector2> directions = new List<Vector2>();
    System.Random randomDirection = new System.Random();

    // Start is called before the first frame update
    void Start()
    {
        up = new Vector2(0, 10);
        directions.Add(up);
        down = new Vector2(0, -10);
        directions.Add(down);
        left = new Vector2(-10, 0);
        directions.Add(left);
        right = new Vector2(10, 0);
        directions.Add(right);

        dest = left;
        currentPos = transform.position;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        // Move towards one end
        Vector2 p = Vector2.MoveTowards(transform.position, dest, speed);
        GetComponent<Rigidbody2D>().MovePosition(p);

        lastPos = currentPos;
        currentPos = transform.position;

        if (currentPos == lastPos)
        {
            dest = chooseDestination();
        }
    }


    //Function used to eat balls back
    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Ground")
        {
            dest = chooseDestination();
        }
        else if(other.gameObject.tag == "Player")
        {
            Debug.Log("hit player => player died");
            gameOverText.GetComponent<TextMeshProUGUI>().enabled = true;
            PlayerController.Money = 0;

            other.gameObject.GetComponent<Animator>().SetTrigger("dies");
            other.gameObject.GetComponent<PlayerController>().enabled = false;
            StartCoroutine(
                        loseGame());
        }
        else if (other.gameObject.tag == "Spider")
        {
            Physics2D.IgnoreCollision(other.gameObject.GetComponent<Collider2D>(), GetComponent<Collider2D>());
        }
    }

    Vector2 chooseDestination()
    {
        int directionChoice = randomDirection.Next(0, 4);
        //Debug.Log(directionChoice);

        while (!valid(directions[directionChoice]))
        {
            directionChoice = randomDirection.Next(0, 4);
            //Debug.Log(directionChoice);
        }

         return (Vector2)transform.position + directions[directionChoice];
    }

    bool valid(Vector2 dir)
    {
        dir /= 20;
        Vector2 pos = transform.position;
        RaycastHit2D hit = Physics2D.Linecast(pos + dir, pos);
        if (hit.collider != null)
        {
            if (hit.collider.tag == "Ground")
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        else
        {
            return true;
        }
    }

    IEnumerator loseGame()
    {
        yield return new WaitForSeconds(3);
        ScreenManager.GameOver();
    }
}
