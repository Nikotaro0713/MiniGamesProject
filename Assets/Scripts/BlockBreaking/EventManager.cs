using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EventManager : MonoBehaviour
{
    public GameObject gameClearText;
    public GameObject gameOverText;
    public GameObject retryButton;
    public HpManager hpManager;
    public GameObject nextButton;
    public SceneSwitcher sceneSwitcher;
    private bool isStart = false;
    [SerializeField] private GameObject gameStartText;

    private int hp;

    private void Start()
    {
        Debug.Log("ŠJŽn");
        Time.timeScale = 0.0f;
    }

    void Update()
    {
        if (!isStart && Input.GetMouseButtonDown(0))
        {
            gameStartText.SetActive(false);
            isStart = true;
            Time.timeScale = 1.0f;
        }

        GameObject[] blocks = GameObject.FindGameObjectsWithTag("Block");
        if (blocks.Length == 0)
        {
            Time.timeScale = 0;
            gameClearText.SetActive(true);
            nextButton.SetActive(true);
        }

        hp = hpManager.GetHP;

        Console.WriteLine(hp);
        //Debug.Log(hp);
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
