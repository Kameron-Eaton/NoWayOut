/**** 
 * Created by: Kameron Eaton
 * Date Created: Feb 27, 2022
 * 
 * Last Edited by: NA
 * Last Edited: Feb 27, 2022
 * 
 * Description: Camera system that moves from node to node while allowing player control of camera
****/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class CameraRig : MonoBehaviour
{
    public Transform yAxis;
    public Transform xAxis;
    public float moveTime;

    public void AlignTo(Transform target)
    {
        Sequence seq = DOTween.Sequence();
        seq.Append(yAxis.DOMove(target.position, 0.75f)); //position camera at node
        seq.Join(yAxis.DORotate(new Vector3 (0f, target.rotation.eulerAngles.y, 0f), 0.75f)); //rotate camera to node
        seq.Join(xAxis.DOLocalRotate(new Vector3(target.rotation.eulerAngles.x, 0f, 0f), 0.75f)); //rotate camera based on how yAxis has rotated
    }//end AlignTo
}//end CameraRig
