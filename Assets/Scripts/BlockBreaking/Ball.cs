using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    public bool isDead = false; // 速度
    public float speed = 3.0f;  // 加速度
    public float accelSpeed = 0.5f;
    public ScoreManager scoreManager;
    public GameObject explosionPrefab;
    public AudioClip touchBarSE;    // バーに当たった時の効果音
    public AudioClip touchOtherSE;  // それ以外に当たった時の効果音
    
    bool isStart = false;
    Rigidbody rb;
    AudioSource audioSource;
    public GameObject gameStartText;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        if(!isStart && Input.GetMouseButtonDown(0))
        {
            gameStartText.SetActive(false);
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
            GameObject explosion = Instantiate(explosionPrefab,collision.transform.position,Quaternion.identity);
            explosion.transform.localScale = new Vector3(0.6f, 0.6f, 0.6f);
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
            audioSource.PlayOneShot(touchBarSE);
        }
        else
        {
            audioSource.PlayOneShot(touchOtherSE);
        }
    }
}
