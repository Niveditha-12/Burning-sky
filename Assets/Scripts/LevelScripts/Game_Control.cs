using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using LevelManagement;

public class Game_Control : MonoBehaviour
{
    public static Game_Control SharedInstance;
    public Text scoreText, healthText, enemyHealthText, gameOverText, highScoreText, levelText; // Note we declare two text elements here
    public int playerScore;
    public int playerHealth = 100;
    public int enemyHealth = 100;
    public EnemyControl enemy;
    public SpawnEnemies spawnEnemy;
    public GameObject NextStageButton;
    public int HighScore, PresentScore, Level;
    public AudioSource audioSource;



    private void Awake()
    {
        if(scoreText!=null)
        {
            int level = MenuManager.Instance.LevelNum + 1;
            levelText.text = "LEVEL : " +level;
            scoreText.text = "Score:" + MenuManager.Instance.playerScore.ToString();
            healthText.text = "HEALTH : " + MenuManager.Instance.healthScore.ToString() ;
        }
      
        //PlayerPrefs.SetInt("HighScore", 0);
        HighScore = PlayerPrefs.GetInt("HighScore"); //get value from prefs to display recent high score.
        SharedInstance = this;
      

    }
    private void Start()
    {
        if(MenuManager.Instance.LevelNum==0)
        {
            playerHealth = 100;
        }
        else
        {
            playerHealth = MenuManager.Instance.healthScore;
        }
        playerScore = MenuManager.Instance.playerScore;
       
        audioSource = GetComponent<AudioSource>();
        Time.timeScale = 1;
    }

    void Update() // save the high score, if player scores more than previous score.
    {
        PlayerPrefs.SetInt("PresentScore", playerScore);
        PlayerPrefs.SetInt("HealthScore", playerHealth);
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
        if (playerHealth == 0)
        {
            PlayerDied();
        }
    }

    public void EnemyHealth()
    {
        enemy = FindObjectOfType<EnemyControl>();//to call destroy function on enemy.
        if (enemy.tag == ("Enemy-1"))
        {
            enemyHealth += -15;
        }
        else if (enemy.tag == ("Enemy-2"))
        {
            enemyHealth += -8;
        }
        else if (enemy.tag == ("Enemy-3"))
        {
            enemyHealth += -5;
        }

        playerScore += 10;
        if (enemyHealth >= 0)
        {
            enemyHealthText.text = "Enemy Health : " + enemyHealth.ToString();
        }
        if (enemyHealth < 0)
        {
            enemyHealthText.text = "Enemy Health : " + 0;
            if (Level == 4)
            {
                PlayerDied();
            }
        }

        scoreText.text = "Score :" + playerScore.ToString();
        if (enemyHealth <= 0)
        {
            if(enemy.tag== "Enemy-3")
            {
                Time.timeScale = 0;
                if (MenuManager.Instance != null && Winscreen.Instance != null)
                {
                    MenuManager.Instance.OpenMenu(Winscreen.Instance);
                }

            }
            
            enemy.DestroEnemy();
            spawnEnemy.manageList();
            //remove enemy1 from list and spawn bigger enemy.

        }
    }
    public void PlayerDied()
    {

        //gameOverText.enabled = true; // Display the Game Over! Text
        Time.timeScale = 0; // This freezes the game
        Time.timeScale = 0;
        if (MenuManager.Instance != null && GameOverMenu.Instance != null)
        {
            MenuManager.Instance.OpenMenu(GameOverMenu.Instance);
        }
    }

    public void NextStage()
    {
        if(MenuManager.Instance.LevelNum <=4)
        {

            Time.timeScale = 1;
            int levelNum = SceneManager.GetActiveScene().buildIndex + 1;
            SceneManager.LoadScene(levelNum);
            GameMenu.open();

        }
        else
        {
            Time.timeScale = 0;
            if (MenuManager.Instance != null && GameOverMenu.Instance != null)
            {
                MenuManager.Instance.OpenMenu(GameOverMenu.Instance);
            }
        }

    }
    public void LoadNextLevel()
    {

        SceneManager.LoadScene(1);
        Time.timeScale = 1;

    }

    public void LoadPreferences() // load this data when game starts.
    {

        HighScore = PlayerPrefs.GetInt("HighScore");
        if (highScoreText != null)
        {

            highScoreText.text = "HIGH SCORE :" + HighScore.ToString();
        }

    }
    
}
