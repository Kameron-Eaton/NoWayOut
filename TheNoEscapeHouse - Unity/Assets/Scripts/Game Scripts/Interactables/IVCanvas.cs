/**** 
 * Created by: Kameron Eaton
 * Date Created: Feb 27, 2022
 * 
 * Last Edited by: NA
 * Last Edited: Feb 27, 2022
 * 
 * Description: Canvas for the image viewer interactable
 ****/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class IVCanvas : MonoBehaviour
{
    public Image imageHolder;

    public void Activate(Sprite pic)
    {
        gameObject.SetActive(true);
        imageHolder.sprite = pic;
    }//end Activate
}//end IVCanvas
