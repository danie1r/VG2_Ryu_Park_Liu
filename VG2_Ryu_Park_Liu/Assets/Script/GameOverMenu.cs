using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverMenu : MonoBehaviour
{
    public void LoadGame(){
        SceneManager.LoadScene(1);
    }

    public void LoadStart(){
        SceneManager.LoadScene(0);
    }
}
