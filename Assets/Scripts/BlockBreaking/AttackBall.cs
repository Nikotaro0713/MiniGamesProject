using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackBall : MonoBehaviour
{
    public GameObject explosionPrefab;
    public float speed = 3.0f;
    Rigidbody rb;

    private float lastReflectTime = 0f;
    private float reflectCooldown = 0.05f; // 50�~���b�Ԃ͔��˖���

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
            // �v���C���[��HP�����炷
            HpManager.Instance.TakeDamage(10);
        }

        if(collision.gameObject.name == "Wall_Top")
        {
            Destroy(this.gameObject);
            // �G�l�~�[��HP�����炷�������L�q
        }

        if (collision.gameObject.CompareTag("Wall"))
        {
            if (Time.time - lastReflectTime < reflectCooldown)
                return; // ���˂�������h��

            lastReflectTime = Time.time;

            Vector3 incomingVelocity = rb.velocity;
            Vector3 normal = collision.contacts[0].normal;

            // �厲�����Ɋۂ߂�iX�� or Y���j
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
