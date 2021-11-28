using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
namespace LevelManagement
{
    public class PauseMenu : Menu<PauseMenu>
    {
        private Game_Control game_Control;
        public void OnResumePressed()
        {
            Time.timeScale = 1;
            base.OnBackPressed();
        }

        public void Start()
        {
            game_Control = FindObjectOfType<Game_Control>();
        }
        public void OnRestartPressed()
        {
            Time.timeScale = 1;
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            base.OnBackPressed();
            game_Control.SaveScore();
        }

        public void OnMainMenuPressed()
        {
            game_Control.SaveScore();
            
            
            print("MainMenu");
            
            if (MenuManager.Instance != null && MainMenu.Instance != null)
            {
                MenuManager.Instance.OpenMenu(MainMenu.Instance);
                Time.timeScale = 0;//open menu dereived from menu manager
            }
            
            

        }
        public void OnQuitPressed()
        {
            Application.Quit();
            game_Control.SaveScore();
            
        }
    }
}

