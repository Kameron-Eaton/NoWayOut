/**** 
 * Created by: Kameron Eaton
 * Date Created: Feb 28, 2022
 * 
 * Last Edited by: NA
 * Last Edited: Feb 28, 2022
 * 
 * Description: Allows for the use of keypads on the canvas
****/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class Keypad : MonoBehaviour
{
    public GameObject keypadOB;

    public TextMeshProUGUI textOB;
    public string answer = "12345";

    public GameObject animateOB;
    public Animator ANI;

    public bool animate;

    
    // Start is called before the first frame update
    void Start()
    {
        keypadOB.SetActive(false);
        textOB.text = "";
    }

    public void Number(int number)
    {
        textOB.text += number.ToString();
    }

    public void Execute()
    {
        if(textOB.text == answer)
        {
            textOB.text = "Right";
        }
        else
        {
            textOB.text = "Wrong";
        }
    }

    public void Clear()
    {
        textOB.text = "";
    }

    public void Exit()
    {
        keypadOB.SetActive(false);
        GameManager.ins.currNode.SetVisibleNodes(true);
        GameManager.ins.currNode.col.enabled = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (textOB.text == "Right" && animate)
            ANI.SetBool("open", true);
    }
}
