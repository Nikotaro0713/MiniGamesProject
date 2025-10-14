using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossCore : MonoBehaviour
{
    [SerializeField] private HpManager hpManager;
    [SerializeField] private int damage = 10;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(hpManager.GetHP < 0)
        {
            Time.timeScale = 0;

        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ball"))
        {
            Destroy(collision.gameObject);
            hpManager.TakeDamage(damage);
        }
    }
}
