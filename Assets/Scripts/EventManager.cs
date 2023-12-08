using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "EventManager", menuName = "Managers/Event Manager")]

public class EventManager : ScriptableObject
{

    public event Action onLivesReduced;
    public event Action onGameOver;
    public event Action<int> onMakeMoney;

    public event Action onPauseGame;
    public event Action onResumeGame;

    public event Action onVictory;

    public void PauseGame()
    {
        onPauseGame?.Invoke();
    }

    
       public void ResumeGame()
    {
        onResumeGame?.Invoke();
    }

    
   

    public void ReduceLives() 
    
    {
    
        onLivesReduced?.Invoke();
    
    
    
    }


    public void TriggerGameOver()
    {
        onVictory?.Invoke();
    }

  

    public void MakeMoney(int incomingMoney)
    {
        onMakeMoney?.Invoke(incomingMoney);
    }

    internal void Triggervictory()
    {
        throw new NotImplementedException();
    }
}
