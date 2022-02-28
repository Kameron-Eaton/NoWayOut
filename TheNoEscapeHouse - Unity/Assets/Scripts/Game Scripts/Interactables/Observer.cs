/**** 
 * Created by: Kameron Eaton
 * Date Created: Feb 28, 2022
 * 
 * Last Edited by: NA
 * Last Edited: Feb 28, 2022
 * 
 * Description: Allows for interactable objects to be observed, rotated, and inspected
****/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Observer : Interactable
{
    public override void Interact()
    {
        GameObject item = Instantiate(gameObject); //Duplicated prop
        item.transform.SetParent(GameManager.ins.obsCamera.rig); //set observer rig as duplicate's parent
        item.transform.localPosition = Vector3.zero; //Move duplicated prop to camera position
        item.transform.GetChild(0).localPosition = Vector3.zero; //allows for rotation around centered anchor
        GameManager.ins.obsCamera.model = item.transform;
        GameManager.ins.obsCamera.gameObject.SetActive(true); //set observer camera active
    }
}
