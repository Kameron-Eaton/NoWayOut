/**** 
 * Created by: Kameron Eaton
 * Date Created: Feb 27, 2022
 * 
 * Last Edited by: NA
 * Last Edited: March 3, 2022
 * 
 * Description: Allows for interaction by viewing an image. Type of interactable
 ****/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ImageViewer : Interactable
{
    public Sprite picture;
    public AudioSource sound;

    public override void Interact()
    {
        GameManager.ins.ivCanvas.Activate(picture);
        if (sound != null)
            sound.Play();
    }//end Interact
}//end ImageViewer
