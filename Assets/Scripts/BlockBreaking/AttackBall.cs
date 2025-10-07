using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackBall : MonoBehaviour
{
    public GameObject explosionPrefab;
    public float speed = 3.0f;
    public float accelSpeed = 0.5f;
    Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Block"))
        {
            Destroy(collision.gameObject);
            GameObject explosion = Instantiate(explosionPrefab, collision.transform.position, Quaternion.identity);
            explosion.transform.localScale = new Vector3(0.6f, 0.6f, 0.6f);
        }

        if (collision.gameObject.name == "Wall_Bottom")
        {
            // プレイヤーのHPを減らす処理を記述
        }

        if(collision.gameObject.name == "Wall_Top")
        {
            // エネミーのHPを減らす処理を記述
        }

        if (collision.gameObject.name == "Bar")
        {
            Vector3 vec = transform.position - collision.transform.position;
            rb.velocity = Vector3.zero;
            rb.AddForce(vec.normalized * speed, ForceMode.VelocityChange);
        }
    }
}
