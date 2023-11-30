using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="EventManager", menuName = "Managers/Event Manager")]

public class EventManager : ScriptableObject
{

    public event Action onLivesReduced;
    public event Action onGameOver;
    public event Action<int> onMakeMoney;

    public void ReduceLives() 
    
    {
    
        onLivesReduced?.Invoke();
    
    
    
    }


    public void TriggerGameOver()
    {
        onGameOver?.Invoke();
    }

    public void MakeMoney(int incomingMoney)
    {
        onMakeMoney?.Invoke(incomingMoney);
    }



}
