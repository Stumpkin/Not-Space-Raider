using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public Rigidbody2D brb;
    public float speed = 4f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Player.fired)
        {
            if (gameObject.transform.position.y > 6)
            {
                Destroy(gameObject);
                Player.fired = false;
            }

            brb.velocity = Vector2.up * speed;
        }
        /*
        if (BadGuy.fired)
        {
            brb.velocity = Vector2.down * speed;
        }
        */
    }
}
