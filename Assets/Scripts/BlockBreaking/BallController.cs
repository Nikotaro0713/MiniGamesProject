using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{
    public BallLauncher leftLauncher;
    public BallLauncher rightLauncher;
    public float interval = 5.0f;

    void Start()
    {
        
    }

    public void StartFiring()
    {
        StartCoroutine(FireAlternately());
    }

    IEnumerator FireAlternately()
    {
        while (true)
        {
            leftLauncher.FireBall();
            yield return new WaitForSeconds(interval);

            rightLauncher.FireBall();
            yield return new WaitForSeconds(interval);
        }
    }
}
