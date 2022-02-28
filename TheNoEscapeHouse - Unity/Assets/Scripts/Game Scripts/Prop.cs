/**** 
 * Created by: Kameron Eaton
 * Date Created: Feb 27, 2022
 * 
 * Last Edited by: NA
 * Last Edited: Feb 27, 2022
 * 
 * Description: Node case: Prop. Extends Node
****/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Prop : Node
{
    public Location loc; //location prop is in
    Interactable inter;

    void Start()
    {
        inter = GetComponent<Interactable>();
    }

    public override void Arrive()
    {
        if(inter != null && inter.enabled)
        {
            inter.Interact();
            return;
        }//end if

        base.Arrive();


        if(inter != null)
        {
            col.enabled = true;
            inter.enabled = true; //make object interactable
        }//end if
    }//end Arrive

    public override void Leave()
    {
        base.Leave();

        if(inter != null)
        {
            inter.enabled = false; 
        }
    }
}//end Prop
