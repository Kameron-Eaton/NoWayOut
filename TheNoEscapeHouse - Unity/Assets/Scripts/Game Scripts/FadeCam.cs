/**** 
 * Created by: Kameron Eaton
 * Date Created: Mar 3, 2022
 * 
 * Last Edited by: NA
 * Last Edited: March 3, 2022
 * 
 * Description: Fades Camera when leaving level 
****/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeCam : MonoBehaviour
{
    float time = 3.0f;
    public Image blackScreen;

    private void Start()
    {
        blackScreen.color = Color.black;
        blackScreen.canvasRenderer.SetAlpha(1.0f);
        blackScreen.CrossFadeAlpha(0.0f, time, false);
        StartCoroutine (enumerator());
    }
    public void FadeToBlack()
    {
        blackScreen.enabled = true;
        blackScreen.color = Color.black;
        blackScreen.canvasRenderer.SetAlpha(0.0f);
        blackScreen.CrossFadeAlpha(1.0f, time, false);
    }

    IEnumerator enumerator()
    {
        yield return new WaitForSeconds(3.5f);
        blackScreen.enabled = false;
    }

}
