/**** 
 * Created by: Kameron Eaton
 * Date Created: Feb 28, 2022
 * 
 * Last Edited by: NA
 * Last Edited: Feb 29, 2022
 * 
 * Description: Component for interactive switches and similar game objects
****/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class interSwitch : Interactable
{
    public bool state;
    public bool animate;
    public Animator ANI;

    public delegate void OnStateChange();
    public event OnStateChange Change;

    public override void Interact()
    {
        if (state == true)
            return;
        ANI.SetBool("Flipped", true);
        state = !state;
        if (Change != null)
            Change();
    }
}
