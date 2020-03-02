using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BadGuy : MonoBehaviour
{
    //public Rigidbody2D rb2;
    public GameObject cannon;
    public GameObject bullet;
    public int type;
    public static bool alive = true;
    public static bool fired = false;
    private float timer = 0;
    // Start is called before the first frame update
    void Start()
    {
        //cannon = GetComponent<GameObject>();
        //bullet = GetComponent<GameObject>();
    }

    // Update is called once per frame
    void Update()
    {
        cannon.transform.position = new Vector2(gameObject.transform.position.x, gameObject.transform.position.y - 0.3f);
        
        if(timer >= 10 && !fired)
        {
            //Fire(cannon);
            timer = 0;
            fired = true;
        }
        timer += 1 * Time.deltaTime;

    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Bullet")
        {
            alive = false;
            Destroy(gameObject);
            Destroy(collision.gameObject);
            Player.fired = false;
            getType();
        }
    }

    void Fire(GameObject spawnObject)
    {
        bullet.transform.position = cannon.transform.position;
        Instantiate(bullet);
    }

    public int getType()
    {
        return type;
    }
}
