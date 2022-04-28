/**** 
 * Created by: Bob Baloney
 * Date Created: April 20, 2022
 * 
 * Last Edited by: Betzaida Ortiz Rivas
 * Last Edited: 4/28/2022
 * 
 * Description: Paddle controler on Horizontal Axis
****/

/*** Using Namespaces ***/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour
{
    public float speed = 10; //speed of paddle


    // Update is called once per frame
    void Update()
    {
        Input.GetAxis("Horizontal" + transform.position.x * speed + Time.deltaTime); //finish this
    }//end Update()
}
