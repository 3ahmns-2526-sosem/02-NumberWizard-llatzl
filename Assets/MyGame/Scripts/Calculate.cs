using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [Header("Zahlenbereich")]
    [SerializeField] private int min = 1;
    [SerializeField] private int max = 100;

    [Header("UI Elemente")]
    [SerializeField] private TMP_Text guessText;
    [SerializeField] private Button higherButton;
    [SerializeField] private Button lowerButton;
    [SerializeField] private Button correctButton;

    private int guess;

    void Start()
    {
        CalculateNextGuess();
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
        
        
        SetButtonsInteractable(false);
    }

    void CalculateNextGuess()
    {
        
        if (min > max)
        {
            min = max;
        }

        
        guess = (min + max) / 2;

        UpdateGuessUI();
    }

    
    void UpdateGuessUI()
    {
        if (guessText != null)
        {
            if (min == max)
            {
                guessText.text = $"Es muss die {guess} sein, richtig?";
            }
            else
            {
                guessText.text =  guess.ToString();
            }
        }
    }

        void SetButtonsInteractable(bool state)
    {
        if (higherButton != null) higherButton.interactable = state;
        if (lowerButton != null) lowerButton.interactable = state;
        if (correctButton != null) correctButton.interactable = state;
    }
}