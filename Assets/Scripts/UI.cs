using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UI : MonoBehaviour
{
    public TextMeshProUGUI tm;
    public TextMeshProUGUI high;
    public BManager bManager;
    int thousand, hond, ten, ones = 0;
    // Start is called before the first frame update
    void Start()
    {
        high.text = PlayerPrefs.GetString("high Scores");
    }

    // Update is called once per frame
    void Update()
    {
       if (bManager.deadValues.Count >= 1)
        {
            int type = bManager.deadValues[bManager.deadValues.Count - 1];
            if (!bManager.visited[bManager.deadValues.Count - 1])
            {
                switch (type)
                {
                    case 1:
                        ones++;
                        bManager.visited[bManager.deadValues.Count - 1] = true;
                        break;

                    case 2:
                        ones += 3;
                        bManager.visited[bManager.deadValues.Count - 1] = true;
                        break;

                    case 3:
                        ten++;
                        bManager.visited[bManager.deadValues.Count - 1] = true;
                        break;

                    case 4:
                        hond++;
                        bManager.visited[bManager.deadValues.Count - 1] = true;
                        break;

                    default:
                        break;
                }
            }
        }
        
    if (ones >= 10)
        {
            int dev = ones / 10;
            ten += dev;
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
        int formatedCurrent = int.Parse(tm.text);
        int formatedHigh = int.Parse(high.text);
        Debug.Log(string.Format("{0} : {1}", high.text, tm.text));
        if (formatedCurrent >= formatedHigh)
        {
            PlayerPrefs.SetString("high Scores", tm.text);
            formatedHigh = formatedCurrent;
            high.text = tm.text;
        }

    }
}
