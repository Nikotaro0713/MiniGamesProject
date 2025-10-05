using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    public bool isDead = false; // ‘¬“x
    public float speed = 3.0f;  // ‰Á‘¬“x
    public float accelSpeed = 0.5f;
    public ScoreManager scoreManager;
    bool isStart = false;
    Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if(!isStart && Input.GetMouseButtonDown(0))
        {
            isStart = true;
            rb.AddForce(new Vector3(1, -1, 0) * speed, ForceMode.VelocityChange);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Block"))
        {
            scoreManager.AddScore();
            Destroy(collision.gameObject);
        }

        if(collision.gameObject.name == "Wall_Bottom")
        {
            isDead = true;
        }

        if(collision.gameObject.name == "Bar")
        {
            scoreManager.ResetCombo();
            speed += accelSpeed;
            Vector3 vec = transform.position - collision.transform.position;
            rb.velocity = Vector3.zero;
            rb.AddForce(vec.normalized * speed,ForceMode.VelocityChange);
        }
    }
}
