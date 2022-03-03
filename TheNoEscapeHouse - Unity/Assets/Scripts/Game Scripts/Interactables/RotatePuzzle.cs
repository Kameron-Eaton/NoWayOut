/**** 
 * Created by: Kameron Eaton
 * Date Created: Mar 2, 2022
 * 
 * Last Edited by: NA
 * Last Edited: March 2, 2022
 * 
 * Description: Reacts based on direction of rotated items
****/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatePuzzle : MonoBehaviour
{
    public GameObject blue;
    public GameObject red;
    public GameObject green;
    public GameObject spawnItem;
    public string dirBlue;
    public string dirRed;
    public string dirGreen;
    public AnimateReactor ANI;

    public void Check()
    {
        if (dirBlue.Equals(blue.GetComponent<Rotate>().myDirection.ToString()) && dirRed.Equals(red.GetComponent<Rotate>().myDirection.ToString()) && dirGreen.Equals(green.GetComponent<Rotate>().myDirection.ToString()))
        {
            ANI.complete = true;
            ANI.React("Flipped");
            Debug.Log("Same");
           
        }
    }
}
