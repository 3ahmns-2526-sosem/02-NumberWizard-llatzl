using UnityEngine;
using TMPro; // Nötig, wenn du TextMeshPro für die UI verwendest

public class GameManager : MonoBehaviour
{
    [Header("Zahlenbereich")]
    [SerializeField] private int min = 1;
    [SerializeField] private int max = 100;

    [Header("UI Elemente")]
    [SerializeField] private TMP_Text guessText; 

    private int guess;

    void Start()
    {
        CalculateFirstGuess();
        CalculateNextGuess();
    }

    void CalculateFirstGuess()
    {
        
        guess = (min + max) / 2;

        
        UpdateGuessUI();
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
            guessText.text = guess.ToString();
        }
    }
}