using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "GameSettings", menuName = "Managers/Game Settings")]

public class GameSettingsSO : ScriptableObject
{


    [SerializeField] EventManager eventManager;

    public int lives = 3;
    public int money = 500;

    private int defaultLives = 3;
    private int defaultMoney = 500;


    public GameStates currentGameState;
    private GameStates previousGameState;
    

    private void OnEnable()
    {
        eventManager.onLivesReduced += ReduceLives;
        eventManager.onMakeMoney += AddMoney;
        eventManager.onPauseGame += PauseGame;
        eventManager.onResumeGame += ResumeGame;
        eventManager.onVictory += victory;
    }

    

    private void OnDisable()
    {
        eventManager.onLivesReduced -= ReduceLives;
        eventManager.onMakeMoney -= AddMoney;
        eventManager.onPauseGame -= PauseGame;
        eventManager.onResumeGame -= ResumeGame;
        eventManager.onVictory -= victory;
    }

    private void AddMoney(int incomingMoney)
    {
        money += incomingMoney;
    }


    public void ReduceLives() 
    {
        lives -= 1;

        if(lives <= 0) 
        
        {

            eventManager.TriggerGameOver();
            currentGameState = GameStates.gameOver;
            Time.timeScale = 0f;
            lives = 0;

        }

    
      




    }


    public void ResetLivesAndMoney()
    {
        lives = defaultLives;
        money = defaultMoney;
    }

    private void PauseGame()
    {
        previousGameState = currentGameState; //The state before pause
        currentGameState = GameStates.paused;
    }
    
    private void ResumeGame ()  
    {
        currentGameState = previousGameState; //restore
    }

    private void victory()
    {
        currentGameState = GameStates.victory;
    }


}



