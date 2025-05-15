using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShake : MonoBehaviour
{
    public static CameraShake Instance;
    public float shakeTime;
    public float shakeIntensity;
    private Vector3 originalPos;
    // Start is called before the first frame update

    private void Awake()
    {
        Instance = this;
        originalPos = transform.localPosition;
    }
    public void PlayShake()
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