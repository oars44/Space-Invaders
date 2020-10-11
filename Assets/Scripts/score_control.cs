using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class score_control : MonoBehaviour
{
    public Text Score;
    public Text Hiscore;
    public float score = 0.0f;
    private float hiscore = 0.0f;
    public bool restart = false;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Score.text = score.ToString("0000");

        if (restart)
        {
            if (score > hiscore)
            {
                hiscore = score;
                Hiscore.text = hiscore.ToString("0000");
            }
            score = 0;
            restart = false;
        }
    }
}