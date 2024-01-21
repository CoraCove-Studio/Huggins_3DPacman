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

public class PlayerController : MonoBehaviour
{
    //components needed to be reference for later assignment
    private Rigidbody rb;

    //accessible variables in the editor
    [SerializeField] // <---- allows for variables to be private and can be accessed in the inspector
    private float speed = 3.0f;

    private void Start()
    {
        //componenets from game object needed to be assigned
        rb = GetComponent<Rigidbody>();
    }
    //called before any physics calculations
    private void FixedUpdate()
    {
        //grabbing input from keyboard for player 
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        //creating a Vector3 to change the transform of player multiplied by the speedy
        Vector3 movement = new Vector3 (moveHorizontal, 0.0f, moveVertical);

        // checking if there is any input
        if (movement != Vector3.zero)
        {
            //execution of using Vector3 and speed
            rb.AddForce(movement * speed);
        }
        else
        {
            rb.velocity = Vector3.zero;
        }
    }
}
