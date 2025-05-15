using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CameraFlashPanel : MonoBehaviour
{
    public static CameraFlashPanel Instance;
    public Image flashPanel;
    public float flashTime;
    // Start is called before the first frame update
    public void PlayFlash()
    {
        StartCoroutine(FlashRoutine());
    }

    private void Awake()
    {
        Instance = this;
    }

    private IEnumerator FlashRoutine()
    {
        Color currentColor = flashPanel.color;
        currentColor.a = 1f;
        flashPanel.color = currentColor;

        float flashTimeCounter = 0f;

        while (flashTimeCounter < flashTime)
        {
            float alpha = Mathf.Lerp(1f, 0f, flashTimeCounter / flashTime);
            currentColor.a = alpha;
            flashPanel.color = currentColor;

            flashTimeCounter += Time.deltaTime;
            yield return null;
        }

        currentColor.a = 0f;
        flashPanel.color = currentColor;
    }
}
