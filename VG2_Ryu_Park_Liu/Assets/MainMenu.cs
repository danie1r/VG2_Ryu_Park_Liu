using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public GameObject instructions;

    void Awake(){
        instructions.SetActive(false);
    }
    public void loadGame()
    {
        SceneManager.LoadScene(1);
    }

    public void LoadInstructions(){
        instructions.SetActive(true);
    }

    public void LoadHome(){
        instructions.SetActive(false);
    }
}
