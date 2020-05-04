using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BManager : MonoBehaviour
{
    public List<BadGuy> badguys;
    public List<int> deadValues;
    public List<bool> visited;
    int xLeftLimit = -7;
    int xRightLimit = 6;
    public int timer = 0;
    bool left = true;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    { 
        if (badguys.Count == 0)
        {
            timer = 0;
        }

        else
        {
            timer++;
        }
        
        for (int x = 0; x < badguys.Count; x++)
        {
            if (!badguys[x].alive)
            {
                deadValues.Add(badguys[x].getType());
                visited.Add(false);
                badguys[x].oofed();
                badguys.RemoveAt(x);
                break;
            }
        } 

        if (timer == 150 && left)
        {
            if (transform.position.x <= xLeftLimit)
            {
                left = false;
                transform.position = new Vector3(transform.position.x, transform.position.y - .5f, transform.position.z);
                timer = 0;
            }

            else
            {
                transform.position = new Vector3(transform.position.x - .5f, transform.position.y, transform.position.z);
                timer = 0;
            }
        }

        else if (timer == 150 && !left)
        {
            if (transform.position.x >= xRightLimit)
            {
                left = true;
                transform.position = new Vector3(transform.position.x, transform.position.y - .5f, transform.position.z);
                timer = 0;
            }

            else
            {
                transform.position = new Vector3(transform.position.x + .5f, transform.position.y, transform.position.z);
                timer = 0;
            }
        }
    }

    bool findDead(ref List<BadGuy> a)
    {
        foreach(BadGuy d in a)
        {
            if (!d.alive)
            {
                return true;
            }
        }

        return false;
    }
}
