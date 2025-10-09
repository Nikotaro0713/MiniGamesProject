using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackBall : MonoBehaviour
{
    public GameObject explosionPrefab;
    public float speed = 3.0f;
    Rigidbody rb;

    private float lastReflectTime = 0f;
    private float reflectCooldown = 0.05f; // 50ミリ秒間は反射無効

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (rb.velocity.magnitude < speed * 0.99f)
        {
            rb.velocity = rb.velocity.normalized * speed;
        }
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
            Destroy(this.gameObject);
            // プレイヤーのHPを減らす
            HpManager.Instance.TakeDamage(10);
        }

        if(collision.gameObject.name == "Wall_Top")
        {
            Destroy(this.gameObject);
            // エネミーのHPを減らす処理を記述
        }

        if (collision.gameObject.CompareTag("Wall"))
        {
            if (Time.time - lastReflectTime < reflectCooldown)
                return; // 反射しすぎを防ぐ

            lastReflectTime = Time.time;

            Vector3 incomingVelocity = rb.velocity;
            Vector3 normal = collision.contacts[0].normal;

            // 主軸方向に丸める（X軸 or Y軸）
            if (Mathf.Abs(normal.x) > Mathf.Abs(normal.y))
                normal = new Vector3(Mathf.Sign(normal.x), 0, 0);
            else
                normal = new Vector3(0, Mathf.Sign(normal.y), 0);

            Vector3 reflectedVelocity = Vector3.Reflect(incomingVelocity, normal);
            rb.velocity = reflectedVelocity.normalized * speed;
        }

        if (collision.gameObject.name == "Bar")
        {
            Vector3 vec = transform.position - collision.transform.position;
            //rb.velocity = Vector3.zero;
            //rb.AddForce(vec.normalized * speed, ForceMode.VelocityChange);
            rb.velocity = vec.normalized * speed;
        }
    }
}
