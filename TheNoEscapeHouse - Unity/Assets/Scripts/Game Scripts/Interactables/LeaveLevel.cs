/**** 
 * Created by: Kameron Eaton
 * Date Created: Mar 2, 2022
 * 
 * Last Edited by: NA
 * Last Edited: March 3, 2022
 * 
 * Description: Leaves the level when being interacted with
****/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LeaveLevel : Interactable
{
    public FadeCam fade;
    public MouseControl cam;
    public override void Interact()

    {
        this.gameObject.GetComponent<Collider>().enabled = false;
        cam.enabled = false;
        StartCoroutine(Fade());
        
    }

    IEnumerator Fade()
    {
        fade.FadeToBlack();
        yield return new WaitForSeconds(3.5f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1); //Loads the game scene
    }
}
