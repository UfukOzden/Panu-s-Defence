using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelSettingsManager : MonoBehaviour
{
    [SerializeField] GameSettingsSO gameSettings;
      [SerializeField] EventManager eventManager;
    private void Awake()
    {

        gameSettings.currentGameState = GameStates.inGame;

        Time.timeScale = 1f;
        
        
        
        
        
        if (SceneManager .GetActiveScene().name == "SampleScene") 
        {
            gameSettings.ResetLivesAndMoney();
        }
    }


    private void Update()
    {
        if(gameSettings.currentGameState == GameStates.inGame) 
        
        {
            if(Input.GetKeyDown(KeyCode.P)) 
            {
                eventManager.PauseGame();
               
            }
        
        }


        else if (gameSettings.currentGameState == GameStates.paused) 
        {
            if (Input.GetKeyDown(KeyCode.P))
            {
                eventManager.ResumeGame();

            }
        }
    }




}
