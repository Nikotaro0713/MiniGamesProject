using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventManager : MonoBehaviour
{
    public GameObject gameClearText;
    public GameObject gameOverText;
    public GameObject retryButton;
    public HpManager hpManager;
    public GameObject nextButton;
    public SceneSwitcher sceneSwitcher;

    private int hp;

    private void Start()
    {
        Time.timeScale = 1.0f;
    }

    void Update()
    {
        GameObject[] blocks = GameObject.FindGameObjectsWithTag("Block");
        if (blocks.Length == 0)
        {
            Time.timeScale = 0;
            gameClearText.SetActive(true);
            nextButton.SetActive(true);
        }

        hp = hpManager.GetHP;

        Console.WriteLine(hp);
        Debug.Log(hp);
        if(hp <= 0)
        {
            Time.timeScale = 0;
            gameOverText.SetActive(true);
            retryButton.SetActive(true);
        }
    }

    public void Next()
    {
        sceneSwitcher.LoadScene("TitleScene");
    }
}
