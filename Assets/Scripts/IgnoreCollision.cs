using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IgnoreCollision : MonoBehaviour
{

    public GameObject[] other;

    // Start is called before the first frame update
    void Start()
    {
        foreach(GameObject obj in other)
        Physics2D.IgnoreCollision(obj.GetComponent<Collider2D>(), GetComponent<Collider2D>());
    }
}
