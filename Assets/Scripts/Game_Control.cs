using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Game_Control : MonoBehaviour
{
    public static Game_Control SharedInstance;
    public Text scoreText, healthText, enemyHealthText, gameOverText; // Note we declare two text elements here
    int playerScore = 0; 
    int playerHealth = 100;
    public int enemyHealth = 100;
    public EnemyControl enemy;
    public SpawnEnemies spawnEnemy;

    private void Awake()
    {
        SharedInstance = this;
    }
    private void Start()
    {
        //FindEnemy();
    }

    public void FindEnemy()
    {
        enemy = FindObjectOfType<EnemyControl>();
    }
    public void AddScore()
    {
        playerScore++;
        scoreText.text = "Score:" + playerScore.ToString();
    }

    public void HealthScore()
    {
        playerHealth--;
        healthText.text = "Health : " + playerHealth.ToString();
        if(playerHealth==0)
        {
            PlayerDied();
        }
    }

    public void EnemyHealth()
    {
        enemy = FindObjectOfType<EnemyControl>();//to call destroy function on enemy.
        if(enemy.tag==("Enemy-1"))
        {
            enemyHealth += -30;
        }
        else if(enemy.tag==("Enemy-2"))
        {
            enemyHealth += -20;
        }
        else if (enemy.tag == ("Enemy-3"))
        {
            enemyHealth += -15;
        }
        
        playerScore += 25;
        if(enemyHealth >=0)
        {
            enemyHealthText.text = "Enemy Health : " + enemyHealth.ToString();
        }
        if (enemyHealth < 0)
        {
            enemyHealthText.text = "Enemy Health : " + 0;
        }

            scoreText.text = "Score :" + playerScore.ToString();
        if (enemyHealth<=0)
        {
            enemy.DestroEnemy();
            spawnEnemy.manageList(); //remove enemy1 from list and spawn bigger enemy.
        }
    }
    public void PlayerDied()
    {
        gameOverText.enabled = true; // Display the Game Over! Text
        Time.timeScale = 0; // This freezes the game
    }
    public void LoadNextLevel()
    {
        

        int nextSceneIndex = (SceneManager.GetActiveScene().buildIndex + 1)
            % SceneManager.sceneCountInBuildSettings;
        if (nextSceneIndex >= 0 && nextSceneIndex < SceneManager.sceneCountInBuildSettings)
        {
            SceneManager.LoadScene(nextSceneIndex);
        }
    }

}
