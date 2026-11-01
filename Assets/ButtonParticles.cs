using UnityEngine;

public class ButtonParticleEffect : MonoBehaviour
{
    public ParticleSystem particles;
    public RectTransform targetButton;
    public Camera mainCamera;

    public void PlayBurst()
    {
        // Find the button's screen position
        Vector2 screenPosition =
            RectTransformUtility.WorldToScreenPoint(
                null, targetButton.position
            );

        // Convert the screen position to world position
        float distance = -mainCamera.transform.position.z;

        Vector3 worldPosition = mainCamera.ScreenToWorldPoint(
            new Vector3(
                screenPosition.x,
                screenPosition.y,
                distance
            )
        );

        transform.position = new Vector3(
            worldPosition.x,
            worldPosition.y,
            0f
        );

        // Restart the particle burst
        particles.Stop(
            true,
            ParticleSystemStopBehavior.StopEmittingAndClear
        );

        particles.Play();
    }
}