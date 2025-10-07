using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{
    public GameObject cannon1;
    public GameObject cannon2;
    public GameObject ballPrefab;
    public float speed;

    bool isStart = false;
    Rigidbody rb;
    public float spawnInterval = 10f;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnBallRoutine());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator SpawnBallRoutine()
    {
        while (true)
        {
            SpawnBall(1);
            yield return new WaitForSeconds(spawnInterval);

            SpawnBall(2);
            yield return new WaitForSeconds(spawnInterval);
        }
    }

    void SpawnBall(int cannonNum)
    {
        if(cannonNum == 1)
        {
            Vector3 position = cannon1.transform.position;
            Instantiate(ballPrefab, position, Quaternion.identity);
            Rigidbody ballRb = ballPrefab.AddComponent<Rigidbody>();
            ballRb.AddForce(new Vector3(1, -1, 0) * speed, ForceMode.VelocityChange);
        }
        else if(cannonNum == 2)
        {
            Vector3 position = cannon2.transform.position;
            Instantiate(ballPrefab, position, Quaternion.identity);
            Rigidbody ballRb = ballPrefab.AddComponent<Rigidbody>();
            ballRb.AddForce(new Vector3(-1, -1, 0) * speed, ForceMode.VelocityChange);
        }
    }
}
