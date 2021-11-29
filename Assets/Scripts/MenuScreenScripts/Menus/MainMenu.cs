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
            game_Control.LoadPreferences();
            
            GameMenu.open();
        }
        public void OnSettingsPressed() // invoking open menu function using MenuManger instance
        {
          
            SettingsMenu.open();

        }

        public void OnScorePressed()
        {
            ScoreMenu.open();

        }

       public override void OnBackPressed() // using this already defined method from menu and can change how it works (abstract class concept)
        {
            
            Application.Quit();
        }
    }
}
