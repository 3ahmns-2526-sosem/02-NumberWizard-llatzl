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

    void Start()
    {
        // Initialisiert das allererste Spiel
        RestartGame();
    }

    // Wird aufgerufen, wenn der "Higher"-Button geklickt wird
    public void OnHigherPressed()
    {
        min = guess + 1;
        CalculateNextGuess();
    }

    // Wird aufgerufen, wenn der "Lower"-Button geklickt wird
    public void OnLowerPressed()
    {
        max = guess - 1;
        CalculateNextGuess();
    }

    // Wird aufgerufen, wenn der "Correct"-Button geklickt wird
    public void OnCorrectPressed()
    {
        if (guessText != null)
        {
            guessText.text = $"I guessed your number! It was {guess}!";
        }
        
        // Spiel vorbei: Rate-Buttons deaktivieren, Restart-Button aktivieren
        SetGameButtonsInteractable(false);
        SetRestartButtonActive(true);
    }

    // Wird aufgerufen, wenn der "Restart"-Button geklickt wird
    public void OnRestartPressed()
    {
        RestartGame();
    }

    // Setzt das Spiel komplett auf die Anfangswerte zurück
    void RestartGame()
    {
        // Werte zurücksetzen auf die im Inspector definierten Startwerte
        min = startMin;
        max = startMax;

        // UI-Buttons wieder für ein neues Spiel vorbereiten
        SetGameButtonsInteractable(true);
        SetRestartButtonActive(false);

        // Ersten Guess für die neue Runde berechnen und anzeigen
        CalculateNextGuess();
    }

    // Zentrale Methode für die binäre Suche
    void CalculateNextGuess()
    {
        if (min > max)
        {
            min = max;
        }

        guess = (min + max) / 2;
        UpdateGuessUI();
    }

    // Aktualisiert den Text auf der Benutzeroberfläche
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
                guessText.text = "Ist es... " + guess + "?";
            }
        }
    }

    // Hilfsmethode zum Aktivieren/Deaktivieren der Gameplay-Buttons
    void SetGameButtonsInteractable(bool state)
    {
        if (higherButton != null) higherButton.interactable = state;
        if (lowerButton != null) lowerButton.interactable = state;
        if (correctButton != null) correctButton.interactable = state;
    }

    // Hilfsmethode zum Ein-/Ausblenden des Restart-Buttons
    void SetRestartButtonActive(bool active)
    {
        if (restartButton != null)
        {
            // Macht den Button klickbar/unklickbar
            restartButton.interactable = active;
            
            // Optional: Blendet das ganze GameObject ein/aus, damit es optisch verschwindet
            restartButton.gameObject.SetActive(active);
        }
    }
}