using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LevelManagement
{
    public class Winscreen : Menu<Winscreen>
    {
        public void OnNextLevelPressed()
        {
            base.OnBackPressed();

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

