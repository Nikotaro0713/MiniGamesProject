using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossEventManager : MonoBehaviour
{
    [SerializeField] private GameObject gameClearText;
    [SerializeField] private GameObject gameOverText;
    [SerializeField] private GameObject retryButton;
    [SerializeField] private HpManager playerHpManager;
    [SerializeField] private HpManager bossHpManager;
    [SerializeField] private GameObject nextButton;
    [SerializeField] private SceneSwitcher sceneSwitcher;
    private bool isStart = false;
    [SerializeField] private GameObject gameStartText;

    private int playerHp;
    private int bossHp;

    private void Start()
    {
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

        playerHp = playerHpManager.GetHP;
        bossHp = bossHpManager.GetHP;

        if (playerHp <= 0)
        {
            Time.timeScale = 0;
            gameOverText.SetActive(true);
            retryButton.SetActive(true);
        }
        if (bossHp <= 0)
        {
            Time.timeScale = 0;
            gameClearText.SetActive(true);
            nextButton.SetActive(true);
        }
    }

    public void Next()
    {
        sceneSwitcher.LoadScene("TitleScene");
    }
}
