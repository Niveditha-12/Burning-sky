﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LevelManagement
{
    public class GameMenu : Menu<GameMenu>
    {
        private Game_Control game_Control;

        public void OnPausePressed()
        {

            Time.timeScale = 0;
            if(MenuManager.Instance != null && PauseMenu.Instance != null)
            {
                MenuManager.Instance.OpenMenu(PauseMenu.Instance);
            }

    }
    }

}