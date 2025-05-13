using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraEffects : MonoBehaviour
{
    public static CameraEffects Instance;

    private Vector3 originalPos;

    public float shakeTime;
    public float shakeIntensity;
    private void Awake()
    {
        Instance = this;
        originalPos = transform.localPosition;
    }

    public void Shake()
    {
        StartCoroutine(ShakeRoutine(shakeTime, shakeIntensity));
    }

    private IEnumerator ShakeRoutine(float shakeTime, float intensity)
    {
        float shakeTimeCounter = 0f;

        while (shakeTimeCounter < shakeTime)
        {
            float offsetX = Random.Range(-1f, 1f) * intensity;
            float offsetY = Random.Range(-1f, 1f) * intensity;

            transform.localPosition = originalPos + new Vector3(offsetX, offsetY, 0);

            shakeTimeCounter += Time.deltaTime;
            yield return null;
        }

        transform.localPosition = originalPos;
    }
}
