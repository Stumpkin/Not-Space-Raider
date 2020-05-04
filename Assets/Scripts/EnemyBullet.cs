using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    public Rigidbody2D rb2D;
    float speed = 4f;
    // Update is called once per frame
    void Update()
    {
        if (BadGuy.fired)
        {
            if (gameObject.transform.position.y < -5)
            {
                Destroy(gameObject);
            }
            rb2D.velocity = Vector2.down * speed;
        }
    }
}
