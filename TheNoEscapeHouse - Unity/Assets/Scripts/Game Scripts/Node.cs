/**** 
 * Created by: Kameron Eaton
 * Date Created: Feb 27, 2022
 * 
 * Last Edited by: NA
 * Last Edited: Feb 28, 2022
 * 
 * Description: Abstract class. Functions as parent for 3 specific node movement cases
****/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public abstract class Node : MonoBehaviour
{
    public Transform cameraPos; //camera position
    public List<Node> visNode = new List<Node>(); // reachable nodes from current node
    public bool ignoreCameraRotation; //flag to ignore camera rotation

    [HideInInspector]
    public Collider col; //collider for detecting clicks

    // Start is called before the first frame update
    void Awake()
    {
        col = GetComponent<Collider>();
        col.enabled = false;
    }//end Awake

    void OnMouseDown()
    {
        Arrive();
    }//end OnMouseDown

    public virtual void Arrive()
    {
        if(GameManager.ins.currNode != null)
        {
            //leave existing current node
            GameManager.ins.currNode.Leave();
        }

        GameManager.ins.currNode = this;  //set currNode

        GameManager.ins.rig.AlignTo(cameraPos, ignoreCameraRotation); //move camera to node

        if (col != null)
        {
            col.enabled = false; //turn off own collider
        }//end if
        SetVisibleNodes(true); //turn on all visible nodes
    }//end Arrive

    public virtual void Leave()
    {
        SetVisibleNodes(false); //turn off all visible nodes
    }//end Leave

    public void SetVisibleNodes(bool set)
    {
        foreach (Node node in visNode)
        {
            if (node.col != null)
            {
                if (node.GetComponent<Prerequisite>() && node.GetComponent<Prerequisite>().nodeAccess)
                {
                    if (node.GetComponent<Prerequisite>().Complete)
                    {
                        node.col.enabled = set; //set all visible nodes to the passed boolean value if prerequisite is met
                    }//end if
                }//end if
                else
                {
                    node.col.enabled = set; //set all visible nodes to the passed boolean value
                }//end else 
            }//end if
        }//end foreach
    }//end SetVisibleNodes

}//end Node