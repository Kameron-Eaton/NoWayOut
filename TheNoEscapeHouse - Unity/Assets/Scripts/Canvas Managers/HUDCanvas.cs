/**** 
 * Created by: Kameron Eaton
 * Date Created: Feb 28, 2022
 * 
 * Last Edited by: NA
 * Last Edited: Feb 28, 2022
 * 
 * Description: Updates HUD inventory canvas
****/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUDCanvas : MonoBehaviour
{
    Text display;

    void Start()
    {
        display = GetComponent<Text>();
        UpdateDisplay();
    }

    public void UpdateDisplay()
    {
        string displayName = "none";
        if(GameManager.ins.itemHeld.itemName != "")
        {
            displayName = GameManager.ins.itemHeld.itemName;
        }//end if
        display.text = "Item Held: " + displayName;
    }
}