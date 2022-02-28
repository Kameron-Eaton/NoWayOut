/**** 
 * Created by: Kameron Eaton
 * Date Created: Feb 27, 2022
 * 
 * Last Edited by: NA
 * Last Edited: Feb 27, 2022
 * 
 * Description: Abstract class. Functions as parent for 3 specific node movement cases
****/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Node : MonoBehaviour
{
    public Transform cameraPos; //camera position
    public List<Node> visNode = new List<Node>(); // reachable nodes from current node

    [HideInInspector]
    public Collider col; //collider for detecting clicks

    // Start is called before the first frame update
    void Start()
    {
        col = GetComponent<Collider>();
    }//end Start

    void OnMouseDown()
    {
        Arrive();
    }//end OnMouseDown

    void Arrive()
    {
        if(GameManager.ins.currNode != null)
        {
            //leave existing current node
            GameManager.ins.currNode.Leave();
        }

        GameManager.ins.currNode = this;  //set currNode

        Camera.main.transform.position = cameraPos.position; //set camera position to node position
        Camera.main.transform.rotation = cameraPos.rotation; //set camera rotation to node rotation

        if (col != null)
        {
            col.enabled = false; //turn off own collider
        }//end if
        foreach (Node node in visNode)
        {
            if (node.col != null)
            {
                node.col.enabled = true; //turn on all visible node colliders
            }//end if
        }//end foreach
    }//end Arrive

    public void Leave()
    {
        foreach (Node node in visNode)
        {
            if (node.col != null)
            {
                node.col.enabled = false; //turn off all visible node colliders
            }//end if
        }//end foreach
    }//end Leave

}//end Node