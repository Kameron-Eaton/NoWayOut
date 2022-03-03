/**** 
 * Created by: Kameron Eaton
 * Date Created: Mar 2, 2022
 * 
 * Last Edited by: NA
 * Last Edited: March 2, 2022
 * 
 * Description: Leaves the level when being interacted with
****/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LeaveLevel : Interactable
{
    public override void Interact()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1); //Loads the game scene
    }
}
