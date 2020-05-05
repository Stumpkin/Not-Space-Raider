using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Player : MonoBehaviour
{
    public Rigidbody2D rb;
    public float speed = 3f;
    public GameObject cannon;
    public GameObject bullet;
    [SerializeField] public static bool fired = false;
    [SerializeField] List<AudioClip> playerSounds;
    public AudioSource speaker;
    bool alive = true;
    float deadTimer = 0;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!alive)
        {
            deadTimer += 1 * Time.deltaTime;
            if (deadTimer >= 3)
            {
                Destroy(gameObject);
                SceneManager.LoadScene("Credits");
            }
        }

        else if (alive)
        {
            rb.velocity = new Vector2(Input.GetAxis("Horizontal") * speed, 0f); // 2D Movement
            cannon.transform.position = new Vector2(gameObject.transform.position.x, gameObject.transform.position.y + .8f); // Follow Player's Movement

            //Firing
            if (Input.GetKeyDown(KeyCode.Space) && !fired)
            {
                Fire(cannon);
                fired = true;
                speaker.clip = playerSounds[0];
                speaker.Play();
            }
        }
       
    }

    void Fire(GameObject spawnObject)
    {
        bullet.transform.position = spawnObject.transform.position;
        Instantiate(bullet);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject)
        {
            speaker.clip = playerSounds[1];
            speaker.Play();
            Destroy(collision.gameObject);
            alive = false;
        }
    }

    
}
