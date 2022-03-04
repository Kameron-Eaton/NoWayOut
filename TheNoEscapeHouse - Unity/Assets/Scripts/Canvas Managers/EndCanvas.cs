/**** 
 * Created by: Akram Taghavi-Burrs
 * Date Created: Feb 23, 2022
 * 
 * Last Edited by: Kameron Eaton
 * Last Edited: March 3, 2022
 * 
 * Description: Updates end canvas refencing game manger
****/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; //libraries for UI components
using UnityEngine.SceneManagement;

public class EndCanvas : MonoBehaviour
{
    public void GameRestart()
    {
        SceneManager.LoadScene("start_scene"); // Restarts the game

    }

    public void GameExit()
    {
        Application.Quit(); //Quits the game

    }

}
