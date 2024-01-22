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
using UnityEngine.SceneManagement;

public class ButtonManager : MonoBehaviour
{
    // to toggle ghosts on to start game
    [Header("Ghosts")]
    [SerializeField] private GameObject pinkGhost;
    [SerializeField] private GameObject redGhost;
    [SerializeField] private GameObject orangeGhost;
    [SerializeField] private GameObject mintGhost;

    public void StartGame()
    {
        pinkGhost.SetActive(true);
        redGhost.SetActive(true);
        orangeGhost.SetActive(true);
        mintGhost.SetActive(true);
    }
    // reloads scene on restart press
    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void OnApplicationQuit()
    {
        Application.Quit();
    }
}
