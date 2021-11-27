using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LevelManagement
{


    public class MainMenu : Menu<MainMenu> //becomes generic menu of type MainMenu
    {
        
        public void OnPlayPressed()
        {
            Game_Control game_Control = Object.FindObjectOfType<Game_Control>();
            if (game_Control != null)
            {
                game_Control.LoadNextLevel();
            }

            if (MenuManager.Instance != null && GameMenu.Instance != null)
            {
                MenuManager.Instance.OpenMenu(GameMenu.Instance); //open pause button 
            }
        }
        public void OnSettingsPressed() // invoking open menu function using MenuManger instance
        {
            
            if (MenuManager.Instance != null && SettingsMenu.Instance != null)//Making use of singleton concept here.
            {
                MenuManager.Instance.OpenMenu(SettingsMenu.Instance);
            }

        }

        public void OnScorePressed()
        {
            if (MenuManager.Instance != null && ScoreMenu.Instance != null) //Making use of singleton concept here.using score menu instance created
            {
                MenuManager.Instance.OpenMenu(ScoreMenu.Instance);
            }

        }

       public override void OnBackPressed() // using this already defined method from menu and can change how it works (abstract class concept)
        {
            Application.Quit();
        }
    }
}
