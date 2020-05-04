using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shields : MonoBehaviour
{
    private int HP = 4;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(HP == 0)
        {
            Destroy(gameObject);
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        //Debug.Log("TAKING FIRE!!! " + collision.gameObject.name);
        HP--;
        string name = collision.gameObject.tag;
        if (name == "Bullet")
        {
            Player.fired = false;
        }

        else
        {
            BadGuy.fired = true;
        }

        Destroy(collision.gameObject);

    }
}
