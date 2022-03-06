/**** 
 * Created by: Kameron Eaton
 * Date Created: March 5, 2022
 * 
 * Last Edited by: NA
 * Last Edited: March 5, 2022
 * 
 * Description: Manages the final orb puzzle of the game
****/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class FinalPuzzle : Interactable
{
    public GameObject red;
    public GameObject blue;
    public GameObject green;
    public GameObject black;

    public FadeCam fade;
    public MouseControl cam;
    public TextMeshProUGUI text;

    public override void Interact()
    {
        if(red.activeInHierarchy && blue.activeInHierarchy && green.activeInHierarchy && black.activeInHierarchy)
        {
            this.gameObject.GetComponent<Collider>().enabled = false;
            cam.enabled = false;
            StartCoroutine(Fade());
        }
        else
        {
            text.text = "The door is locked by some mechanism";
            text.enabled = true;
            StartCoroutine(DisableText());
        }
        
    }

    IEnumerator DisableText()
    {
        yield return new WaitForSeconds(2.0f);
        text.enabled = false;
    }

    IEnumerator Fade()
    {
        fade.FadeToBlack();
        yield return new WaitForSeconds(3.5f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1); //Loads the game scene
    }
}
