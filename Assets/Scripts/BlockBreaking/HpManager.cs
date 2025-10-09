using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HpManager : MonoBehaviour
{
    public static HpManager Instance;

    public int maxHP = 100;
    public int currentHP;

    public Slider hpSlider;

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
        if(currentHP < 0)
        {
            Time.timeScale = 0;
        }
    }
}
