using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BossEventManager : MonoBehaviour
{
    [SerializeField] private GameObject gameClearText;
    [SerializeField] private GameObject gameOverText;
    [SerializeField] private GameObject retryButton;
    [SerializeField] private Player player;
    [SerializeField] private BossCore boss;
    [SerializeField] private GameObject nextButton;
    [SerializeField] private SceneSwitcher sceneSwitcher;
    private bool isStart = false;
    [SerializeField] private GameObject gameStartText;
    [SerializeField] private BallController ballController;

    private int playerHp;
    private int bossHp;

    private void Start()
    {
        Time.timeScale = 0.0f;
        playerHp = player.GetPlayerHp;
        bossHp = boss.GetBossHp;
    }

    void Update()
    {
        if (!isStart && Input.GetMouseButtonDown(0))
        {
            gameStartText.SetActive(false);
            isStart = true;
            Time.timeScale = 1.0f;
            ballController.StartFiring();
        }

        if(playerHp > 0)
        {
            playerHp = player.GetPlayerHp;

        }
        if(bossHp > 0)
        {
            bossHp = boss.GetBossHp;
        }

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
        Debug.Log("ƒV[ƒ“‘JˆÚ");
        sceneSwitcher.LoadScene("TitleScene");
    }

    [ContextMenu("Test Next")]
    private void TestNext()
    {
        Next();
    }

    public void Retry()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
