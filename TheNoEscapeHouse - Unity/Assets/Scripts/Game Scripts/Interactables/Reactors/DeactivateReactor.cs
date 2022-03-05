/**** 
 * Created by: Kameron Eaton
 * Date Created: March 5, 2022
 * 
 * Last Edited by: NA
 * Last Edited: March 5, 2022
 * 
 * Description: Deactivates a game object when the state of the switch is active
****/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeactivateReactor : StateReactor
{
    protected override void Awake()
    {
        base.Awake();
        React();
    }//end Awake

    public override void React()
    {
        if (intSwitch.state)
        {
            this.gameObject.SetActive(false);
        }//end if
    }//end React
}
