/**** 
 * Created by: Kameron Eaton
 * Date Created: Feb 28, 2022
 * 
 * Last Edited by: NA
 * Last Edited: Feb 28, 2022
 * 
 * Description: Allows for the interaction with keypad objects
****/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeypadInter : Interactable
{
    public override void Interact()
    {
        GameManager.ins.keyCanvas.gameObject.SetActive(true);
    }
}
