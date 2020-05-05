using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class CreditsScript : MonoBehaviour
{
    public float endTimer;
    // Start is called before the first frame update
    void Start()
    {
        endTimer = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (endTimer >= 5)
        {
            SceneManager.LoadScene("Menu");
        }

        else
        {
            endTimer += 1 * Time.deltaTime;
        }
    }
}
