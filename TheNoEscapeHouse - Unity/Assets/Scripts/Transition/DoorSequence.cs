/**** 
 * Created by: Kameron Eaton
 * Date Created: Mar 3, 2022
 * 
 * Last Edited by: NA
 * Last Edited: March 3, 2022
 * 
 * Description: Plays the door sequence animation cutscene
****/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DoorSequence : MonoBehaviour
{
    public GameObject cam;
    public GameObject door;
    public AudioSource doorOpen;
    public AudioSource doorClose;

    void Start()
    {
        StartCoroutine(Sequence());
    }

    IEnumerator Sequence()
    {
        yield return new WaitForSeconds(3.5f);
        doorOpen.Play();
        door.GetComponent<Animation>().Play("Open");
        yield return new WaitForSeconds(1.25f);
        cam.GetComponent<Animation>().Play("Move02");
        yield return new WaitForSeconds(1.5f);
        doorClose.Play();
        yield return new WaitForSeconds(1.0f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1); //Loads the game scene
    }
}
