using System.Collections;
using System.Collections.Generic;
using StarterAssets;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using DinoGame;

public class PauseMenu : MonoBehaviour
{
    public static PauseMenu instance;

    public GameObject mainMenu;
    //public GameObject settingsMenu;
    //public Slider volumeSlider;

    void Awake()
    {
        instance = this;
        Hide();
    }

    public void Show()
    {
        ShowMainMenu();
        gameObject.SetActive(true);
        Time.timeScale = 0;
        PlayerController.instance.isPaused = true;


        //GetComponent<StarterAssetsInputs>().SetCursorState(false); 
        //GetComponent<StarterAssetsInputs>().cursorInputForLook = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    public void Hide()
    {
        gameObject.SetActive(false);
        Time.timeScale = 1;
        print("Resume working");

        if(PlayerController.instance != null)
        {
            PlayerController.instance.isPaused = false;
        }

        //GetComponent<StarterAssetsInputs>().SetCursorState(true);
        //GetComponent<StarterAssetsInputs>().cursorInputForLook = true;
        Cursor.lockState = CursorLockMode.None;

    }

    void SwitchMenu(GameObject someMenu)
    {
        mainMenu.SetActive(false);
        //settingsMenu.SetActive(false);

        someMenu.SetActive(true);
    }

    public void ShowMainMenu()
    {
        SwitchMenu(mainMenu);
    }

    //public void ShowSettingsMenu()
    //{
    //    SwitchMenu(settingsMenu);
    //}

    //public void PlayGame()
    //{
    //    SceneManager.LoadScene(1);
    //}

    public void Restart()
    {
        SceneManager.LoadScene(0);
        print("Restart working");
    }
}
