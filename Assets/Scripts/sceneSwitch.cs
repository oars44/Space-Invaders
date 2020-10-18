using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class sceneSwitch : MonoBehaviour
{
    public float timeToRestart = 5;

    private GameObject[] getCount;
    private GameObject player;
    private float count;
    private float timer = 0;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        player = GameObject.Find("tank");
        getCount = GameObject.FindGameObjectsWithTag("enemy");
        count = getCount.Length;

        if (SceneManager.GetActiveScene().name == "SampleScene" && count == 0 && player == null)
        {
            GoToCredits();
        }

        if (SceneManager.GetActiveScene().name == "Credits" && timer > timeToRestart)
        {
            GoToMenu();
        }
    }

    public void GoToGame()
    {
        SceneManager.LoadScene("SampleScene");
    }

    public void GoToMenu()
    {
        SceneManager.LoadScene("Menu");
    }

    public void GoToCredits()
    {
        timer = 0;
        SceneManager.LoadScene("Credits");
    }
}