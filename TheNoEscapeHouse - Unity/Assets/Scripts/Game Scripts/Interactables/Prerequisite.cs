/**** 
 * Created by: Kameron Eaton
 * Date Created: Feb 28, 2022
 * 
 * Last Edited by: NA
 * Last Edited: Feb 28, 2022
 * 
 * Description: Used when an object requires some prerequisite to be interacted with
****/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Prerequisite : MonoBehaviour
{
    public bool requireItem; //require item if true
    public bool prereqMet = false;
    
    public interSwitch watch; //require switch active
    public bool nodeAccess;
    public bool hasDialogue;
    public string dialog = "";
    public TextMeshProUGUI text;
    public float timer = 2f;

    public bool Complete
    {
        get
        {
            if (!requireItem) 
            {
                return watch.state;
            }
            else
            {
                if (prereqMet)
                    return true;
                if (GameManager.ins.itemHeld.itemName == checkCollector.myItem.itemName)
                {
                    prereqMet = true;
                    checkCollector.myItem.itemUsed = true;
                    GameManager.ins.itemHeld.itemName = "";
                    GameManager.ins.invDisplay.UpdateDisplay();
                    return true;
                }
                if (hasDialogue)
                {
                    text.GetComponent<TextMeshProUGUI>().enabled = true;
                    text.text = dialog.ToString();
                    StartCoroutine(DisableDialogue());
                }

                return false;
            }

        }
    }

    IEnumerator DisableDialogue()
    {
        yield return new WaitForSeconds(timer);
        text.GetComponent<TextMeshProUGUI>().enabled = false;
    }

    public Collector checkCollector;

}
