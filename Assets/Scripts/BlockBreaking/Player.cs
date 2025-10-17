using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] HpManager playerHpManager;
    [SerializeField] int damage = 10;

    public int GetPlayerHp
    {
        get { return playerHpManager.GetHP; }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ball"))
        {
            Destroy(collision.gameObject);
            playerHpManager.TakeDamage(damage);
        }
    }
}
