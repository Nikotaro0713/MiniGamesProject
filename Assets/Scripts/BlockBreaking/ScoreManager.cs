using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    int score = 0;
    int basicScore = 10;
    int combo = 0;

    void Start()
    {
        
    }

    void Update()
    {
        GetComponent<Text>().text = "ScoreÅF" + score;
    }

    public void AddScore()
    {
        combo++;
        score += combo * basicScore;
    }

    public void ResetCombo()
    {
        combo = 0;
    }
}
