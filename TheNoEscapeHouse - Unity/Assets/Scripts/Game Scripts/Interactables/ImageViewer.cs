/**** 
 * Created by: Kameron Eaton
 * Date Created: Feb 27, 2022
 * 
 * Last Edited by: NA
 * Last Edited: Feb 27, 2022
 * 
 * Description: Allows for interaction by viewing an image. Type of interactable
 ****/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ImageViewer : Interactable
{
    public Sprite picture;

    public override void Interact()
    {
        GameManager.ins.ivCanvas.Activate(picture);
    }//end Interact
}//end ImageViewer
