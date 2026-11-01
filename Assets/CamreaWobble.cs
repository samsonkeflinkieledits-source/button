using UnityEngine;
using System.Collections;

public class CameraWobble : MonoBehaviour
{
    public float shakeDuration = 0.25f;
    public float shakeIntensity = 0.12f;

    private Vector3 originalPosition;

    void Awake()
    {
        originalPosition = transform.localPosition;
    }

    public void ShakeCamera()
    {
        StopAllCoroutines();
        StartCoroutine(Wobble());
    }

    IEnumerator Wobble()
    {
        float timer = 0f;

        while (timer < shakeDuration)
        {
            float strength = 1f - (timer / shakeDuration);

            Vector2 randomOffset =
                Random.insideUnitCircle * shakeIntensity * strength;

            transform.localPosition = originalPosition +
                new Vector3(randomOffset.x, randomOffset.y, 0f);

            timer += Time.unscaledDeltaTime;

            yield return null;
        }

        transform.localPosition = originalPosition;
    }
}
