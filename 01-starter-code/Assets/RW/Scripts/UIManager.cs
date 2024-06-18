using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance;

    public TextMeshProUGUI scoreText;  // Reference to the TextMeshPro text element for displaying score
    public TextMeshProUGUI livesText;  // Reference to the TextMeshPro text element for displaying lives
    private GameManager gameManager;   // Reference to the GameManager

    public void Awake()
    {
        Instance = this;
    }
    void Start()
    {
        // Find the GameManager instance in the scene
        gameManager = GameManager.Instance;

        // Initialize UI with initial values
        UpdateScoreUI();
        UpdateLivesUI();
    }

    // Update the displayed score
    public void UpdateScoreUI()
    {
        scoreText.text = "Score: " + gameManager.sheepSaved.ToString();  // Update score text based on GameManager data
    }

    // Update the displayed lives
    public void UpdateLivesUI()
    {
        livesText.text = "Lives: " + (gameManager.sheepDroppedBeforeGameOver - gameManager.sheepDropped).ToString();  // Calculate remaining lives and update text
    }
}

