using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Game_Control : MonoBehaviour
{
    public Text scoreText, healthText, gameOverText; // Note we declare two text elements here
    int playerScore = 0; 
    int playerHealth = 100;
    int enemyHealth = 100;
    public void AddScore()
    {
        playerScore++;
        scoreText.text = "Score:" + playerScore.ToString();
    }

    public void HealthScore()
    {
        playerHealth--;
        healthText.text = "Health : " + playerHealth.ToString();
        
    }

    public void EnemyHealth()
    {
        enemyHealth += -5;
        if(enemyHealth==0)
        {

        }
    }
    public void PlayerDied()
    {
        gameOverText.enabled = true; // Display the Game Over! Text
        Time.timeScale = 0; // This freezes the game
    }
}
