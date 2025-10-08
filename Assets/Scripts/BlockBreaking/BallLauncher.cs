using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallLauncher : MonoBehaviour
{
    public GameObject ballPrefab;   // 発射するボールのプレハブ
    public Transform launchPoint;   // 発射位置
    public Vector3 launchDirection = new Vector3(1, -1, 0); // 発射方向
    public float launchForce = 5.0f;    // 発射力

    public void FireBall()
    {
        GameObject ball = Instantiate(ballPrefab, launchPoint.position, Quaternion.identity);
        Rigidbody rb = ball.GetComponent<Rigidbody>();
        if(rb != null)
        {
            rb.velocity = Vector3.zero; //初期化
            rb.AddForce(launchDirection.normalized * launchForce, ForceMode.VelocityChange);
        }
    }
}
