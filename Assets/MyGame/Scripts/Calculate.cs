using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [Header("Zahlenbereich (Standardwerte)")]
    [SerializeField] private int startMin = 1;
    [SerializeField] private int startMax = 100;

    [Header("UI Elemente")]
    [SerializeField] private TMP_Text guessText;
    [SerializeField] private Button higherButton;
    [SerializeField] private Button lowerButton;
    [SerializeField] private Button correctButton;
    [SerializeField] private Button restartButton; // Neuer Slot für den Restart-Button

    // Aktuelle Spielwerte im laufenden Match
    private int min;
    private int max;
    private int guess;

    private void Start()
    {
        
        RestartGame();
    }
    
    public void OnHigherPressed()
    {
        min = guess + 1;
        CalculateNextGuess();
    }

    public void OnLowerPressed()
    {
        max = guess - 1;
        CalculateNextGuess();
    }

    public void OnCorrectPressed()
    {
        if (guessText != null)
        {
            guessText.text = $"I guessed your number! It was {guess}!";
        }
    
        SetGameButtonsInteractable(false);
        SetRestartButtonActive(true);
    }

    public void OnRestartPressed()
    {
        RestartGame();
    }

    private void RestartGame()
    {
        min = startMin;
        max = startMax;
        SetGameButtonsInteractable(true);
        SetRestartButtonActive(false);
        CalculateNextGuess();
    }
    private void CalculateNextGuess()
    {
        if (min > max)
        {
            min = max;
        }

        guess = (min + max) / 2;
        UpdateGuessUI();
    }
    private void UpdateGuessUI()
    {
        if (guessText != null)
        {
            if (min == max)
            {
                guessText.text = $"Es muss die {guess} sein, richtig?";
            }
            else
            {
                guessText.text = guess.ToString();
            }
        }
    }

    private void SetGameButtonsInteractable(bool state)
    {
        if (higherButton != null) higherButton.interactable = state;
        if (lowerButton != null) lowerButton.interactable = state;
        if (correctButton != null) correctButton.interactable = state;
    }

    private void SetRestartButtonActive(bool active)
    {
        if (restartButton != null)
        {
            restartButton.interactable = active;
            restartButton.gameObject.SetActive(active);
        }
    }
}