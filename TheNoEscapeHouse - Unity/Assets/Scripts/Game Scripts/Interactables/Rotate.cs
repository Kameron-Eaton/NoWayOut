/**** 
 * Created by: Kameron Eaton
 * Date Created: Mar 2, 2022
 * 
 * Last Edited by: NA
 * Last Edited: March 2, 2022
 * 
 * Description: Rotates a rotatable item when interacted with
****/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : Interactable
{
    public enum Directions {North, South, East, West};
    public Animator ANI;
    public Directions myDirection;
    public RotatePuzzle rot;

    public void Start()
    {
        myDirection = Directions.East;
    }
    public override void Interact()
    {
        switch (myDirection)
        {
            case Directions.East:
                RotateNorth();
                rot.Check();
                break;
            case Directions.North:
                RotateWest();
                rot.Check();
                break;
            case Directions.West:
                RotateSouth();
                rot.Check();
                break;
            case Directions.South:
                RotateEast();
                rot.Check();
                break;
        }
    }

    public void RotateNorth()
    {
        ANI.SetBool("North", true);
        ANI.SetBool("East", false);
        myDirection = Directions.North;
    }

    public void RotateWest()
    {
        ANI.SetBool("West", true);
        ANI.SetBool("North", false);
        myDirection = Directions.West;
    }

    public void RotateSouth()
    {
        ANI.SetBool("South", true);
        ANI.SetBool("West", false);
        myDirection = Directions.South;
    }

    public void RotateEast()
    {
        ANI.SetBool("East", true);
        ANI.SetBool("South", false);
        myDirection = Directions.East;
    }
}
