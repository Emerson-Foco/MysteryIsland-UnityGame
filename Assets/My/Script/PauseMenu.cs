using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    //Variaveis:
    public Transform pauseMenu;
    public Transform lost;
    public bool update;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(update == false)
        {
            Time.timeScale = 1;
            update = true;
        }


        if (lost.gameObject.activeSelf)
        {

        }
        else
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                if (pauseMenu.gameObject.activeSelf)
                {
                    pauseMenu.gameObject.SetActive(false);
                    Time.timeScale = 1;
                    Cursor.lockState = CursorLockMode.Locked;
                    Cursor.visible = false;
                }
                else
                {
                    pauseMenu.gameObject.SetActive(true);
                    Time.timeScale = 0;
                    Cursor.lockState = CursorLockMode.None;
                    Cursor.visible = true;
                }
            }   
        }
    }

    //Para o botão CONTINUE
    public void Continue()
    {
        pauseMenu.gameObject.SetActive(false);
        Time.timeScale = 1;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    //Para o botão EXIT
    public void Exit()
    {
        Application.Quit();    
    }

    //Novo Jogo (reiniciar partida)
    public void NewGame()
    {
        SceneManager.LoadScene(1);
    }

    public void Menu()
    {
        SceneManager.LoadScene(0);
    }

}
