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
        Camera.main.transform.position = cameraPos.position; //set camera position to node position
        Camera.main.transform.rotation = cameraPos.rotation; //set camera rotation to node rotation
    }//end OnMouseDown

}//end Node