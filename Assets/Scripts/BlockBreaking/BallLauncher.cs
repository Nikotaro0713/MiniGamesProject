using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallLauncher : MonoBehaviour
{
    public GameObject ballPrefab;   // ���˂���{�[���̃v���n�u
    public Transform launchPoint;   // ���ˈʒu
    public Vector3 launchDirection = new Vector3(1, -1, 0); // ���˕���
    public float launchForce = 5.0f;    // ���˗�

    public void FireBall()
    {
        GameObject ball = Instantiate(ballPrefab, launchPoint.position, Quaternion.identity);
        Rigidbody rb = ball.GetComponent<Rigidbody>();
        if(rb != null)
        {
            rb.velocity = Vector3.zero; //������
            rb.AddForce(launchDirection.normalized * launchForce, ForceMode.VelocityChange);
        }
    }
}
