//////////////////////////////////////////////
//Assignment/Lab/Project: 3D Pacman
//Name: Rachel Huggins
//Section: SGD285.4171
//Instructor: Aurore Locklear
//Date: 01/21/2024
/////////////////////////////////////////////

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotator : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        //rotates the pellet prefab
        transform.Rotate(new Vector3(15, 30, 45) * Time.deltaTime); 
    }
}
