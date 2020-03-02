using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Rigidbody2D rb;
    public float speed = 3f;
    public GameObject cannon;
    public GameObject bullet;
    [SerializeField] public static bool fired = false;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity = new Vector2(Input.GetAxis("Horizontal") * speed, 0f); // 2D Movement
        cannon.transform.position = new Vector2(gameObject.transform.position.x, gameObject.transform.position.y + .3f); // Follow Player's Movement
        
        //Firing
        if (Input.GetKeyDown(KeyCode.Space) && !fired)
        {
            Fire(cannon);
            fired = true;
        }

       
    }

    void Fire(GameObject spawnObject)
    {
        bullet.transform.position = spawnObject.transform.position;
        Instantiate(bullet);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Bullet")
        {
            Debug.Log("OUCH");
            Destroy(collision.gameObject);
            Destroy(gameObject);
        }
    }
}
