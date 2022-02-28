/**** 
 * Created by: Kameron Eaton
 * Date Created: Feb 27, 2022
 * 
 * Last Edited by: NA
 * Last Edited: Feb 27, 2022
 * 
 * Description: Allows for interaction with different props in the game. Abstract parent class
 ****/ 
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Prop))]
public abstract class Interactable : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        this.enabled = false;
    }

    public virtual void Interact()
    {
        Debug.Log("Interacting with " + name);
    }
}
