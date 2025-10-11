using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public GameObject gameClearText;
    public GameObject gameOverText;
    public GameObject ball;
    public GameObject retryButton;
    public GameObject nextButton;

    void Update()
    {
        GameObject[] blocks = GameObject.FindGameObjectsWithTag("Block");
        if(blocks.Length == 0)
        {
            gameClearText.SetActive(true);
            ball.GetComponent<Rigidbody>().isKinematic = true;
            nextButton.SetActive(true);
        }

        if(ball.GetComponent<Ball>().isDead == true)
        {
            gameOverText.SetActive(true);
            ball.GetComponent<Rigidbody>().isKinematic = true;
            retryButton.SetActive(true);
        }
    }

    public void Retry()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void Next()
    {
        SceneManager.LoadScene("BlockBreaking_2nd");
    }
}
