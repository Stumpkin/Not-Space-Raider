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
        //cannon = GetComponent<GameObject>();
        //cannon 
    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity = new Vector2(Input.GetAxis("Horizontal") * speed, 0f);
        cannon.transform.position = new Vector2(gameObject.transform.position.x, gameObject.transform.position.y + .3f);

        if (Input.GetKeyDown(KeyCode.Space) && !fired)
        {
            Fire(cannon);
            fired = true;
        }

        if (fired)
        {
            if (bullet.transform.position.y > 6)
            {
                fired = false;
            }
        }
    }

    void Fire(GameObject spawnObject)
    {
        bullet.transform.position = spawnObject.transform.position;
        Instantiate(bullet);
    }
}
