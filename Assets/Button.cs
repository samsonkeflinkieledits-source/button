using UnityEngine;
using System.Collections;
public class ArcadeButtonJuice : MonoBehaviour
{

    public RectTransform buttonTransform;
    public Vector3 originalScale;
   

    void Start()
    {
        buttonTransform = GetComponent<RectTransform>();
        originalScale = buttonTransform.localScale;
    }

    public void PlaySquash()
    {
        StopAllCoroutines();
        StartCoroutine(SquashAnimation());
    }

    IEnumerator SquashAnimation()
    {
        // Compress the button
        buttonTransform.localScale = new Vector3(
            originalScale.x * 1.15f,
            originalScale.y * 0.75f,
            originalScale.z
        );

        // Spring back with a small overshoot
        yield return new WaitForSecondsRealtime(0.08f);

        buttonTransform.localScale = originalScale * 1.1f;

        yield return new WaitForSecondsRealtime(0.08f);

        // Return to normal size
        buttonTransform.localScale = originalScale;
    }
}
