using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test : MonoBehaviour
{
    public int colorInt;
    public bool isPlayer;
    private Rigidbody2D rigidbody2D;
    private void Start()
    {
        colorInt = (int) Mathf.Round(Random.Range(0, 2));
        if (isPlayer)
        {
            rigidbody2D = GetComponentInChildren<Rigidbody2D>(true);
            rigidbody2D.isKinematic = false;
        }
    }
    /**
     * Initialises this test.cs object
     */
    public void Init()
    {
        if (colorInt == 0)
        {
            GetComponentInChildren<SpriteRenderer>().color = Color.cyan;
        }
        else if (colorInt == 1)
        {
            GetComponentInChildren<SpriteRenderer>().color = Color.magenta;
        }
    }
    /**
     * @param Collision2D collision Object collided with   
     */   
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<test>().colorInt == this.colorInt)
        {
            if (this.gameObject.activeInHierarchy)
            {
                this.gameObject.SetActive(false);
            }


        }
        else
        {
            Debug.Log("hit the wrong one");
        }
    }
}
