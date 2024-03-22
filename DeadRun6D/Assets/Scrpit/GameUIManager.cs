using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.SceneManagement;







public class GameUIManager : MonoBehaviour
{
    public GameObject UI_Pause;
    public GameObject UI_GameOver;




    private enum GameUI_State
    {
        GamePlay, GamePause, GameOver
    }

    GameUI_State currentState;

    // Start is called before the first frame update
    void Start()
    {
        SwitchUIState(GameUI_State.GamePlay);

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            TogglePauseUI();
        }
        if (PlayerCon.instance.isDead)
        {
            SwitchUIState(GameUI_State.GameOver);
        }
     


    }

    private void SwitchUIState(GameUI_State state)
    {
        UI_Pause.SetActive(false);
   
        UI_GameOver.SetActive(false);

        Time.timeScale = 1;

        switch (state)
        {
            case GameUI_State.GamePlay:
                break;
            case GameUI_State.GamePause:
                Time.timeScale = 0;
                UI_Pause.SetActive(true);
                break;
            case GameUI_State.GameOver:
                UI_GameOver.SetActive(true);
                break;
       
        }

        currentState = state;
    }



    public void TogglePauseUI()
    {
        if (currentState == GameUI_State.GamePlay)
        {
            SwitchUIState(GameUI_State.GamePause);
        }
        else if (currentState == GameUI_State.GamePause)
        {
            SwitchUIState(GameUI_State.GamePlay);
        }

    }

    public void Button_MainMenu()
    {
        SceneManager.LoadScene("MainMenu");

    }


    public void Button_Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void Button_Resume()
    {
        SwitchUIState(GameUI_State.GamePlay);
    }


   


}
