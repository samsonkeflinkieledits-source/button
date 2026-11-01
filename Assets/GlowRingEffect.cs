using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GlowRingEffect : MonoBehaviour
{
    private RectTransform ringTransform;
    private CanvasGroup canvasGroup;

    public float expandSize = 2f;
    public float duration = 0.5f;

    void Awake()
    {
        ringTransform = GetComponent<RectTransform>();

        canvasGroup = GetComponent<CanvasGroup>();

        if (canvasGroup == null)
        {
            canvasGroup = gameObject.AddComponent<CanvasGroup>();
        }

        gameObject.SetActive(false);
    }

    public void PlayGlowRing()
    {
        StopAllCoroutines();
        gameObject.SetActive(true);

        StartCoroutine(ExpandRing());
    }

    IEnumerator ExpandRing()
    {
        float timer = 0f;

        ringTransform.localScale = Vector3.one;
        canvasGroup.alpha = 1f;

        while (timer < duration)
        {
            timer += Time.unscaledDeltaTime;

            float progress = Mathf.Clamp01(timer / duration);

            // Expand the ring
            ringTransform.localScale =
                Vector3.Lerp(
                    Vector3.one,
                    Vector3.one * expandSize,
                    progress
                );

            // Fade away
            canvasGroup.alpha = 1f - progress;

            yield return null;
        }

        gameObject.SetActive(false);
    }
}
