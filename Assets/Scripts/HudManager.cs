using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class HudManager : MonoBehaviour
{

    [SerializeField] TMP_Text livesTextObject;
    [SerializeField] TMP_Text moneyTextObject;
    [SerializeField] GameObject gameOverScreen;
    [SerializeField] GameObject pauseScreen;
    [SerializeField] GameObject victoryScreen;

    [SerializeField] EventManager eventManager;
    [SerializeField] GameSettingsSO gameSettings;


    private void OnEnable()
    {
        eventManager.onLivesReduced += UpdateLivesText;
        eventManager.onGameOver += displayGameOverScreen;
        eventManager.onMakeMoney += UpdateMoneyText;

        eventManager.onPauseGame += DisplayPauseScreen;
        eventManager.onResumeGame += HidePauseScreen;


        eventManager.onVictory += DisplayVictoryScreen;
    }

    private void OnDisable()
    {
        eventManager.onLivesReduced -= UpdateLivesText;
        eventManager.onGameOver -= displayGameOverScreen;
        eventManager.onMakeMoney -= UpdateMoneyText;

        eventManager.onPauseGame -= DisplayPauseScreen;
        eventManager.onResumeGame -= HidePauseScreen;

        eventManager.onVictory -= DisplayVictoryScreen;

    }

    


    private void Awake()
    {
        UpdateLivesText();

        UpdateMoneyText();
    }

    



    private void UpdateLivesText()
    {
        livesTextObject.text = $"Lives: {gameSettings.lives}";
    }



    private void UpdateMoneyText(int someValue = -1)
    {
        moneyTextObject.text = $"$: {gameSettings.money}";
    }


   private void displayGameOverScreen () 
    {
        gameOverScreen.SetActive(true);
    }

    private void DisplayPauseScreen()
    { pauseScreen.SetActive(true); }

    private void HidePauseScreen() 
    {
        pauseScreen.SetActive(false);
    }

    private void DisplayVictoryScreen()
    {
        victoryScreen.SetActive(true);
    }

}
