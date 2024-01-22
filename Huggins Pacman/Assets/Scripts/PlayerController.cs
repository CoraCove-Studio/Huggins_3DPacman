//////////////////////////////////////////////
//Assignment/Lab/Project: 3D Pacman
//Name: Rachel Huggins
//Section: SGD285.4171
//Instructor: Aurore Locklear
//Date: 01/21/2024
/////////////////////////////////////////////

using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //components needed to be reference for later assignment
    private Rigidbody rb;
    private int life_Amount = 3;
    private PelletBehavior pelletBehavior;

    [Header("Lives")] // references the players lives
    [SerializeField] public List<GameObject> lives;

    //accessible variables in the editor
    [Header ("Velocity")]
    [SerializeField] // <---- allows for variables to be private and can be accessed in the inspector
    private float speed = 3.0f;

    //sfx
    [Header("Sounds")]
    [SerializeField] AudioSource deathSFX;
    [SerializeField] AudioSource loseSFX;
    [SerializeField] AudioSource winSFX;

    //win and lose panels
    [Header("Player Panels")]
    [SerializeField] GameObject losePanel;
    [SerializeField] GameObject winPanel;

    [Header("Restart Position")]
    [SerializeField] Transform restartPosition;

    //grabbing ghost's reference to reset points
    [Header("Ghosts")]
    [SerializeField] private GhostBehavior pinkGhost;
    [SerializeField] private GhostBehavior redGhost;
    [SerializeField] private GhostBehavior orangeGhost;
    [SerializeField] private GhostBehavior mintGhost;

    private void Start()
    {
        //componenets from game object needed to be assigned
        rb = GetComponent<Rigidbody>();
        pelletBehavior = GetComponent<PelletBehavior>();
    }

    private void Update()
    {
        OnDeath();
        OnWin();
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

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Ghost"))
        {
            lives[life_Amount - 1].SetActive(false);
            deathSFX.Play();
            life_Amount -= 1;
            ResetPosition();

            // Call ResetOnPlayerDeath for each ghost
            pinkGhost.ResetOnPlayerDeath();
            redGhost.ResetOnPlayerDeath();
            orangeGhost.ResetOnPlayerDeath();
            mintGhost.ResetOnPlayerDeath();
        }
    }

    private void OnDeath()
    {
        if (life_Amount == 0)
        {
            losePanel.SetActive(true);
            loseSFX.Play();
        }
        else
        {
            return;
        }
    }

    private void OnWin()
    {
        if (pelletBehavior.num_Pellets_Collected == pelletBehavior.pellets_in_maze.Length)
        {
            winPanel.SetActive(true);
            winSFX.Play();
        }
        else
        {
            return;
        }
    }

    private void ResetPosition()
    {
        transform.position = restartPosition.position;
    }
}
