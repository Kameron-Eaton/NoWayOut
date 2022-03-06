/**** 
 * Created by: Kameron Eaton
 * Date Created: Feb 28, 2022
 * 
 * Last Edited by: NA
 * Last Edited: Feb 28, 2022
 * 
 * Description: Controls camera for observer interactable objects
****/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObsCamera : MonoBehaviour
{
    [HideInInspector]
    public Transform model;

    public Transform rig;

    public float max;

    public float sensitivity = 3.0f;

    Quaternion modelRot;
    Quaternion rigRot;

    Vector3 startScale = Vector3.zero;

    private void Start()
    {
        startScale = model.localScale;
        max = model.localScale.x * 5.0f;
    }

    void Update()
    {
        if(Input.GetAxis("Mouse ScrollWheel") != 0f)
        {
            if (model.localScale.x > max || model.localScale.x < 0.1f)
                model.localScale = startScale;
            Vector3 lTemp = model.localScale;
            lTemp.x += Input.GetAxis("Mouse ScrollWheel");
            lTemp.y += Input.GetAxis("Mouse ScrollWheel");
            lTemp.z += Input.GetAxis("Mouse ScrollWheel");
            model.localScale = lTemp;
        }
        if (Input.GetMouseButton(0) && (Input.GetAxis("Mouse X") != 0 || Input.GetAxis("Mouse Y") != 0))
        {
            if(model == null)
                return;

            modelRot = model.rotation;
            rigRot = rig.rotation;

            ObjectRotation();
        } //end if
    }//end Update

    public void ObjectRotation()
    {
        float yRot = Input.GetAxis("Mouse X") * sensitivity;
        float xRot = Input.GetAxis("Mouse Y") * sensitivity;

        modelRot *= Quaternion.Euler(0f, -yRot, 0f);
        rigRot *= Quaternion.Euler(xRot, 0f, 0f);

        rigRot = ClampRotationAroundXAxis(rigRot);
      
        model.rotation = modelRot;
        rig.rotation = rigRot;
    }//end ObjectRotation

    Quaternion ClampRotationAroundXAxis(Quaternion q)
    {
        q.x /= q.w;
        q.y /= q.w;
        q.z /= q.w;
        q.w = 1.0f;

        float angleX = 2.0f * Mathf.Rad2Deg * Mathf.Atan(q.x);

        angleX = Mathf.Clamp(angleX, -80, 80);

        q.x = Mathf.Tan(0.5f * Mathf.Deg2Rad * angleX);
        return q;
    }//end ClampRotationAroundXAxis

    public void Close()
    {
        Destroy(model.gameObject);
        rig.rotation = Quaternion.identity;
        gameObject.SetActive(false);
       
    }
}
