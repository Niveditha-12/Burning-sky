using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using  LevelManagement;

public class Game_Control : MonoBehaviour
{
    public static Game_Control SharedInstance;
    public Text scoreText, healthText, enemyHealthText, gameOverText, highScoreText; // Note we declare two text elements here
    public int playerScore; 
    int playerHealth = 100;
    public int enemyHealth = 100;
    public EnemyControl enemy;
    public SpawnEnemies spawnEnemy;
    public GameObject NextStageButton;
    public int HighScore;
    public int PresentScore;
    public int Level;
    public AudioSource audioSource;



    private void Awake()
    {
        //PlayerPrefs.SetInt("HighScore", 0);
        HighScore = PlayerPrefs.GetInt("HighScore");
        SharedInstance = this;
        if(Level>1)
        {
            scoreText.text = "Score:" + PresentScore.ToString(); // if player has reached different level, continue with same score.
        }
        
    }
    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        Time.timeScale = 1;
    }

    void Update() // save the high score, if player scores more than previous score.
    {
        PlayerPrefs.SetInt("PresentScore", playerScore);
        if (playerScore > HighScore)
        {
            HighScore = playerScore;
            if (highScoreText != null)
            {
               
                highScoreText.text = "HIGH SCORE :" + HighScore.ToString();
            }

            PlayerPrefs.SetInt("HighScore", HighScore);
            
            //PlayerPrefs.Save();
        }
        PlayerPrefs.Save();
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
            enemyHealth += -8;
        }
        else if(enemy.tag==("Enemy-2"))
        {
            enemyHealth += -5;
        }
        else if (enemy.tag == ("Enemy-3"))
        {
            enemyHealth += -3;
        }
        
        playerScore += 10;
        if(enemyHealth >=0)
        {
            enemyHealthText.text = "Enemy Health : " + enemyHealth.ToString();
        }
        if (enemyHealth < 0)
        {
            enemyHealthText.text = "Enemy Health : " + 0;
            //Time.timeScale = 0;
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

    public void NextStage()
    {
        Time.timeScale = 1;
        spawnEnemy.SpawnEnemy();
        
    }
    public void LoadNextLevel()
    {

        SceneManager.LoadScene(1);
        Time.timeScale = 1;
        
    }
    
    public void LoadPreferences() // load this data when game starts.
    {

        HighScore = PlayerPrefs.GetInt("HighScore");
        if(highScoreText !=null)
        {
            
            highScoreText.text = "HIGH SCORE :" + HighScore.ToString();
        }
        
    }
}
