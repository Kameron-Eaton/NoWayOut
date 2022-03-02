/**** 
 * Created by: Kameron Eaton
 * Date Created: Feb 28, 2022
 * 
 * Last Edited by: NA
 * Last Edited: March 2, 2022
 * 
 * Description: Reacts by playing an animation
****/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimateReactor : MonoBehaviour
{
    public Animator ANI;
    public GameObject animateOB;
    public bool complete;

    public void React(string name)
    {
        if (complete)
        {
            ANI.SetBool(name, true);
        }
    }
   
}
