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

public class Prerequisite : MonoBehaviour
{
    public bool requireItem; //require item if true

    public interSwitch watch; //require switch active
    public bool nodeAccess;

    public bool Complete
    {
        get
        {
            if (!requireItem)
                return watch.state;
            else
            {
                return GameManager.ins.itemHeld.itemName == checkCollector.myItem.itemName;
            }
        }
    }

    public Collector checkCollector;

}
