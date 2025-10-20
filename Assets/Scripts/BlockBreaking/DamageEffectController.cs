using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DamageEffectController : MonoBehaviour
{
    public Image damageImage;  // Inspectorで割り当て
    public float flashDuration = 0.5f;

    private Coroutine currentRoutine;

    private void Awake()
    {
        if (damageImage != null)
        {
            damageImage.enabled = false;
        }
    }

    // ダメージエフェクトを表示
    public void ShowDamageEffect()
    {
        if (currentRoutine != null)
        {
            StopCoroutine(currentRoutine);
        }

        currentRoutine = StartCoroutine(FlashEffect());
    }

    private IEnumerator FlashEffect()
    {
        Color color = damageImage.color;
        color.a = 1f;
        damageImage.color = color;
        damageImage.enabled = true;

        float timer = 0f;
        while (timer < flashDuration)
        {
            timer += Time.deltaTime;
            color.a = Mathf.Lerp(1f, 0f, timer / flashDuration);
            damageImage.color = color;
            yield return null;
        }

        damageImage.enabled = false;
    }
}
