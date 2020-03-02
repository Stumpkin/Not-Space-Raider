using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UI : MonoBehaviour
{
    public TextMeshProUGUI tm;
    int thousand, hond, ten, ones = 0;
    // Start is called before the first frame update
    void Start()
    {
        tm = GetComponent<TextMeshProUGUI>();
        //tm.text = string.Format("{0}{1}{2}{3}", thousand.ToString(), hond.ToString(), ten.ToString(), ones.ToString());
    }

    // Update is called once per frame
    void Update()
    {
        /*
        switch(BadGuy.getType())
        {
            case 1:
                ones++;
                break;

            case 2:
                ten++;
                break;

            case 3:
                hond++;
                break;

            case 4:
                thousand++;
                break;

            default:
                break;
        }
        */
        if (Input.GetKeyDown(KeyCode.Q))
        {
            ones++;
        }

        if (Input.GetKeyDown(KeyCode.E))
        {
            hond++;
        }

        if (ones >= 10)
        {
            ten++;
            ones = 0;
        }
        
        if (ten >= 10)
        {
            hond++;
            ten = 0;
        }

        if (hond >= 10)
        {
            thousand++;
            hond = 0;
        }

        tm.text = string.Format("{0}{1}{2}{3}", thousand.ToString(), hond.ToString(), ten.ToString(), ones.ToString());
    }
}
