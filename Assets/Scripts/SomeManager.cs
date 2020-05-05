using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SomeManager : MonoBehaviour
{
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    public void startGame()
    {
        SceneManager.LoadScene("MainGame");
    }

    public void gotoMenu()
    {
        SceneManager.LoadScene("Menu");
    }

    public void gotoCredits()
    {
        SceneManager.LoadScene("Credits");
       
    }
}
