using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

namespace LevelManagement
{
    public class GameOverMenu : Menu<GameOverMenu>
    {

        public Text HighScore, Score;
        public void Start()
        {

            
        }
        private void Update()
        {
            HighScore.text = Game_Control.SharedInstance.HighScore.ToString();
            Score.text = Game_Control.SharedInstance.playerScore.ToString();
        }

        public void OnMainMenuPressed()
        {


            if (MenuManager.Instance != null && MainMenu.Instance != null)
            {
                //SceneManager.LoadScene(0);
                MenuManager.Instance.OpenMenu(MainMenu.Instance);
                Time.timeScale = 0;//open menu dereived from menu manager
            }



        }
        public void OnQuitPressed()
        {
            Application.Quit();


        }
    }
}