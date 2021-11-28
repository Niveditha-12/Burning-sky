using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace LevelManagement
{
    public class Winscreen : Menu<Winscreen>
    {
        private Game_Control game_Control;
        public void OnNextLevelPressed()
        {
            base.OnBackPressed();
            game_Control.NextStage();
            
        }
         public void OnRestartPressed()
        {
            base.OnBackPressed();
        }
        public void OnMainMenuPressed()
        {
            MainMenu.open();
        }

       public void ScreenOpen()
        {
            Winscreen.open();
        }

    }
}

