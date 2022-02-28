/**** 
 * Created by: Kameron Eaton
 * Date Created: Feb 27, 2022
 * 
 * Last Edited by: NA
 * Last Edited: Feb 27, 2022
 * 
 * Description: Allows player to somewhat control camera rotation to look around. Implements a large portion of the Unity Asset MouseLook.cs
****/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CameraRig))]
public class MouseControl : MonoBehaviour
{
    public float XSensitivity = 2f;
    public float YSensitivity = 2f;
    public bool clampVerticalRotation = true;
    public float MinimumX = -90F;
    public float MaximumX = 90F;
    public bool smooth;
    public float smoothTime = 5f;

    private Quaternion y_Axis;
    private Quaternion x_Axis;
    private CameraRig rig;

    void Start()
    {
        rig = GetComponent<CameraRig>();
    }

    void Update()
    {
        if (Input.GetMouseButton(0) && (Input.GetAxis("Mouse X") != 0 || Input.GetAxis("Mouse Y") != 0)){
            if (GameManager.ins.ivCanvas.gameObject.activeInHierarchy || GameManager.ins.obsCamera.gameObject.activeInHierarchy)
                return; //don't move camera if image viewer is active
            y_Axis = rig.yAxis.localRotation;
            x_Axis = rig.xAxis.localRotation;
            
            LookRotation();
        }
    }

    public void LookRotation()
    {
        float yRot = Input.GetAxis("Mouse X") * XSensitivity;
        float xRot = Input.GetAxis("Mouse Y") * YSensitivity;

        y_Axis *= Quaternion.Euler(0f, yRot, 0f);
        x_Axis *= Quaternion.Euler(-xRot, 0f, 0f);

        if(clampVerticalRotation)
        {
            x_Axis = ClampRotationAroundXAxis(x_Axis);
        }//end if

        if (smooth)
        {
            rig.yAxis.localRotation = Quaternion.Slerp(rig.yAxis.localRotation, y_Axis, smoothTime * Time.deltaTime);
            rig.xAxis.localRotation = Quaternion.Slerp(rig.xAxis.localRotation, x_Axis, smoothTime * Time.deltaTime);
        }
        else
        {
            rig.yAxis.localRotation = y_Axis;
            rig.xAxis.localRotation = x_Axis;
        }
    }

    Quaternion ClampRotationAroundXAxis(Quaternion q)
    {
        q.x /= q.w;
        q.y /= q.w;
        q.z /= q.w;
        q.w = 1.0f;

        float angleX = 2.0f * Mathf.Rad2Deg * Mathf.Atan(q.x);

        angleX = Mathf.Clamp(angleX, MinimumX, MaximumX);

        q.x = Mathf.Tan(0.5f * Mathf.Deg2Rad * angleX);
        return q;
    }
}
