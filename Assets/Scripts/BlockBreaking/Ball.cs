using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    public bool isDead = false;

    void Start()
    {
        GetComponent<Rigidbody>().AddForce(new Vector3(100, -100, 0));
    }

    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Block"))
        {
            Destroy(collision.gameObject);
        }

        if(collision.gameObject.name == "Wall_Bottom")
        {
            isDead = true;
        }
    }
}
