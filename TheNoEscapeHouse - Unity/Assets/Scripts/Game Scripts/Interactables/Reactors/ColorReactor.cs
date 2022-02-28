/**** 
 * Created by: Kameron Eaton
 * Date Created: Feb 28, 2022
 * 
 * Last Edited by: NA
 * Last Edited: Feb 28, 2022
 * 
 * Description: Reacts to a change in an items state by changing its color
****/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(MeshRenderer))]
public class ColorReactor : StateReactor
{
    public Color active;
    public Color inactive;
    MeshRenderer mesh;

    protected override void Awake()
    {
        mesh = GetComponentInChildren<MeshRenderer>();
        base.Awake();
        React();
    }//end Awake

    public override void React()
    {
        if (intSwitch.state)
        {
            mesh.material.color = active;
        }//end if

        else
        {
            mesh.material.color = inactive;
        }//end else
    }//end React
}//end ColorReactor
