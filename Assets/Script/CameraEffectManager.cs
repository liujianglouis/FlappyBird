using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraEffectManager : MonoBehaviour
{
    public CameraShake cameraShake;
    public CameraFlashPanel cameraFlashPanel;

    public void PlayCameraEffect()
    {
        cameraShake.PlayShake();
        cameraFlashPanel.PlayFlash();
    }
}
