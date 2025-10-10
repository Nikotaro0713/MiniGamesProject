using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HpManager : MonoBehaviour
{
    public static HpManager Instance;

    [SerializeField] private int maxHP = 100;
    [SerializeField] private int currentHP;

    public Slider hpSlider;

    public int GetHP
    {
        get { return currentHP; }
    }

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
    }
    public void TakeDamage(int amount)
    {
        currentHP -= amount;
        currentHP = Mathf.Clamp(currentHP, 0, maxHP);
        UpdateHpBar();
    }

    void UpdateHpBar()
    {
        if(hpSlider != null)
        {
            hpSlider.value = (float)currentHP / maxHP;
        }
    }
    
    void Update()
    {
        
    }
}
