using UnityEngine;
using System.Collections;

public class CameraShake : MonoBehaviour
{
    public float shakeDuration = 0.5f;
    public float shakeIntensity = 40f;

    private RectTransform shakeTarget;
    private Vector2 originalPosition;

    void Awake()
    {
        shakeTarget = GetComponent<RectTransform>();
        originalPosition = shakeTarget.anchoredPosition;
    }

    public void ShakeScreen()
    {
        StopAllCoroutines();
        StartCoroutine(Shake());
    }

    IEnumerator Shake()
    {
        float timer = 0f;

        while (timer < shakeDuration)
        {
            Vector2 randomOffset =
                Random.insideUnitCircle * shakeIntensity;

            shakeTarget.anchoredPosition =
                originalPosition + randomOffset;

            timer += Time.unscaledDeltaTime;

            yield return null;
        }

        shakeTarget.anchoredPosition = originalPosition;
    }

}
