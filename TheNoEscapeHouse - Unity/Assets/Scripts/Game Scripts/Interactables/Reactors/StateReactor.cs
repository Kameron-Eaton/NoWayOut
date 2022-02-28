/**** 
 * Created by: Kameron Eaton
 * Date Created: Feb 28, 2022
 * 
 * Last Edited by: NA
 * Last Edited: Feb 28, 2022
 * 
 * Description: Reacts to a change in an items state
****/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class StateReactor : MonoBehaviour
{
    public interSwitch intSwitch;

    protected virtual void Awake()
    {
        intSwitch.Change += React;
    }//end Awake

    public virtual void React()
    {
        Debug.Log(name + "'s state is " + intSwitch.state);
    }//end React
}//end StateReactor
