using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class PlayerLook
{
    // Objects
    GameObject cameraBaseH;
    GameObject cameraBaseV;

    public float horizontalSensitivity = 75.0f;
    public float verticalSensitivity = 75.0f;

    public float verticalMax = 80f;
    public float verticalMin = -30f;

    public void Init(GameObject cameraBaseH, GameObject cameraBaseV)
    {
        this.cameraBaseH = cameraBaseH;
        this.cameraBaseV = cameraBaseV;
    }

    public void LookRotation()
    {
        Quaternion horizontalCameraRotation = this.cameraBaseH.transform.localRotation;
        Quaternion verticalCameraRotation = this.cameraBaseV.transform.localRotation;

        float horizontalRot = Input.GetAxis("LookH") * horizontalSensitivity * Time.deltaTime;
        float verticalRot = Input.GetAxis("LookV") * verticalSensitivity * Time.deltaTime;

        horizontalCameraRotation *= Quaternion.Euler(0.0f, horizontalRot, 0.0f);
        verticalCameraRotation *= Quaternion.Euler(-verticalRot, 0.0f, 0.0f);
        verticalCameraRotation.z = 0;

        this.cameraBaseH.transform.localRotation = horizontalCameraRotation;
        this.cameraBaseV.transform.localRotation = ClampVertical(verticalCameraRotation);
    }

    Quaternion ClampVertical(Quaternion q)
    {
        q.x /= q.w;
        q.y /= q.w;
        q.z /= q.w;
        q.w = 1.0f;

        float angleX = 2.0f * Mathf.Rad2Deg * Mathf.Atan(q.x);

        angleX = Mathf.Clamp(angleX, verticalMin, verticalMax);

        q.x = Mathf.Tan(0.5f * Mathf.Deg2Rad * angleX);

        return q;
    }
}
