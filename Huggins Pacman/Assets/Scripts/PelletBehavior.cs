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
using TMPro;
//using System.Runtime.CompilerServices;

public class PelletBehavior : MonoBehaviour
{
    // TMPro Collection for Display
    [Header ("TMPro Collection")]
    [SerializeField] private TextMeshProUGUI remaining_Pellet_Count;
    [SerializeField] private TextMeshProUGUI collected_Pellet_Count;

    // counting the amount of pellets collected and seeing it for testing purposes
    [Header ("Pellet Count Information")]
    [SerializeField] public int num_Pellets_Collected = 0;
    [SerializeField] public GameObject[] pellets_in_maze;     // referencing the amount of pellets in the map
    [SerializeField] private int num_Pellets_Left;     // seeing the amount of pellets left on the map

    // Audio
    [Header("SFX")]
    [SerializeField] AudioSource collectionSFX;

    // Start is called before the first frame update
    void Start()
    {
        //collecting the amount of pellets populated in the scene
        pellets_in_maze = GameObject.FindGameObjectsWithTag("Pellet");

        //setting the length of the array to the amount of pellets populated in the scene
        num_Pellets_Left = pellets_in_maze.Length;
    }

    // Update is called once per frame
    void Update()
    {
        TextBoxHandles();
    }

    // handles the changing of the UI info read to player
    void TextBoxHandles()
    {
        //reading the amount of pellets remaining
        remaining_Pellet_Count.text = num_Pellets_Left.ToString();

        //reading the amount of pellets collected
        collected_Pellet_Count.text = num_Pellets_Collected.ToString();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Pellet"))
        {
            Destroy(other.gameObject); //destorying the pellet in the scene
            collectionSFX.Play(); // playing the collection audio
            num_Pellets_Collected++; //increasing collection count
            num_Pellets_Left = pellets_in_maze.Length - num_Pellets_Collected; //changing the remaining count display
        }
    }


}