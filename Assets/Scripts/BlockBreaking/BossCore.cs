using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossCore : MonoBehaviour
{
    [SerializeField] private HpManager hpManager;
    [SerializeField] private int damage = 10;
    [SerializeField] private GameObject explosionPrefab;
    [SerializeField] private AudioClip damageSE;
    AudioSource audioSource;

    public int GetBossHp
    {
        get { return hpManager.GetHP; }
    }

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
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
            GameObject explosion = Instantiate(explosionPrefab, collision.transform.position, Quaternion.identity);
            explosion.transform.localScale = new Vector3(0.6f, 0.6f, 0.6f);
            audioSource.PlayOneShot(damageSE);
        }
    }
}
