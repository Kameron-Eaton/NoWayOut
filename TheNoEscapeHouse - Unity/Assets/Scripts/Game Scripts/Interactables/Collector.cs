/**** 
 * Created by: Kameron Eaton
 * Date Created: Feb 28, 2022
 * 
 * Last Edited by: NA
 * Last Edited: Feb 28, 2022
 * 
 * Description: Allows for interactable object to be collected and added to inventory
****/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collector : Interactable
{
    public Item myItem;
    public override void Interact()
    {
        GameManager.ins.itemHeld = myItem; //Adds item to inventory
        GameManager.ins.invDisplay.UpdateDisplay(); //Update inventory HUD display
    }
}
