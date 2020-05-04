using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BadGuy : MonoBehaviour
{
    //public Rigidbody2D rb2;
    public GameObject cannon;
    public GameObject bullet;
    public int type;
    public bool alive = true;
    public static bool fired = false;
    public float timer = 0;
    // Start is called before the first frame update
    void Start()
    {
        //cannon = GetComponent<GameObject>();
        //bullet = GetComponent<GameObject>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!alive)
        {
            gameObject.SetActive(false);
        }

        cannon.transform.position = new Vector2(gameObject.transform.position.x, gameObject.transform.position.y - 0.8f);
        switch(type)
        {
            case 1:
                if (timer >= 5 && alive)
                {
                    Fire(cannon);
                    timer = 0;
                    fired = true;
                }
                break;

            case 2: 
                if (timer > 10 && alive)
                {
                    Fire(cannon);
                    timer = 0;
                    fired = true;
                }
                break;

            case 3:
                if (timer >= 15 && alive)
                {
                    Fire(cannon);
                    timer = 0;
                    fired = true;
                }
                break;

            case 4:
                if (timer > 22 && alive)
                {
                    Fire(cannon);
                    timer = 0;
                    fired = true;
                }
                break;

            default:
                break;
        }

        timer += 1 * Time.deltaTime;
        

    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Bullet")
        {
            alive = false;
            Destroy(collision.gameObject);
            Player.fired = false;
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

    public void oofed()
    {
        gameObject.SetActive(false);
        Destroy(gameObject);
    }
}
