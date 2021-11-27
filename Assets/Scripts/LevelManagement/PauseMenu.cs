using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
namespace LevelManagement
{
    public class PauseMenu : Menu<PauseMenu>
    {
        public void OnResumePressed()
        {
            Time.timeScale = 1;
            base.OnBackPressed();
        }
        public void OnRestartPressed()
        {
            Time.timeScale = 1;
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            base.OnBackPressed();
        }

        public void OnMainMenuPressed()
        {
            Time.timeScale = 1;
            //SceneManager.LoadScene(0);//load main menu
            if(MenuManager.Instance != null && MainMenu.Instance != null)
            {
                MenuManager.Instance.OpenMenu(MainMenu.Instance); //open menu dereived from menu manager
            }
            
        }
        public void OnQuitPressed()
        {
            Application.Quit();
        }
    }
}

