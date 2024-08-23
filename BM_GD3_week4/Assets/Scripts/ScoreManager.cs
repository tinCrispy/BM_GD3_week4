using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class ScoreManager : MonoBehaviour
{

    public GameObject GameOverScreen;
    float timePassed;
    public TMP_Text timePassedText;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timePassed = Time.time;
        timePassedText.text = "Time : " + ((int)timePassed).ToString();
    }

    public void GameOver()
    {
        GameOverScreen.SetActive(true);
    }

    public void restart()
    {
        SceneManager.LoadScene(0);
        GameObject.FindObjectOfType<PlayerController>().Restart();
    }

}
