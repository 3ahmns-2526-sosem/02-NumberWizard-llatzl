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

        // Aktualisierung der UI
        UpdateGuessUI();
    }
    public void OnHigherPressed()
    {
        // Da die gesuchte Zahl höher ist, wird das Minimum angehoben
        min = guess + 1;

        // Neuen Guess berechnen und UI updaten
        CalculateNextGuess();
    }
    void CalculateNextGuess()
    {
        // Schutzschritt: Verhindert, dass min über max hinausschießt
        if (min > max)
        {
            min = max;
        }

        // Berechnung des neuen Mittelwerts
        guess = (min + max) / 2;

        // UI aktualisieren
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