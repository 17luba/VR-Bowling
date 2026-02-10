using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using TMPro; // Ajoute cette ligne pour le texte

public class BowlingScoreManager : MonoBehaviour
{
    public List<BowlingPin> pins;
    public TextMeshProUGUI scoreDisplayText; // Référence vers ton texte
    public int score = 0;
    private bool isCalculating = false;

    public void StartCalculation()
    {
        if (!isCalculating) StartCoroutine(WaitAndCalculate());
    }

    IEnumerator WaitAndCalculate()
    {
        isCalculating = true;
        yield return new WaitForSeconds(3.0f);

        int pinsDownThisTurn = 0;
        foreach (BowlingPin pin in pins)
        {
            if (pin.HasFallen()) pinsDownThisTurn++;
        }

        score += pinsDownThisTurn;

        // MISE À JOUR DE L'AFFICHAGE
        if (scoreDisplayText != null)
        {
            scoreDisplayText.text = score.ToString() + " / 10";
        }

        isCalculating = false;
    }
}