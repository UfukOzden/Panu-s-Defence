using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "GameSettings", menuName = "Managers/Game Settings")]

public class GameSettingsSO : ScriptableObject
{


    [SerializeField] EventManager eventManager;

    public int lives = 3;
    public int money = 500;

    private void OnEnable()
    {
        eventManager.onLivesReduced += ReduceLives;
        eventManager.onMakeMoney += AddMoney;
    }


    private void OnDisable()
    {
        eventManager.onLivesReduced -= ReduceLives;
        eventManager.onMakeMoney -= AddMoney;
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

            lives = 0;

        }

    
    }






}



