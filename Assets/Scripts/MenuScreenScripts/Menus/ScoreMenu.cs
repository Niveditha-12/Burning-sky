using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace LevelManagement
{
    public class ScoreMenu : Menu<ScoreMenu> //using generic menu
    {
        
        private Game_Control game_control;
        public Text scoreText;

        protected override void Awake() // search for player prefs and sets the saved data.
        {

            base.Awake();
            

        }

        private void Start()
        {
            game_control = Object.FindObjectOfType<Game_Control>();
            LoadPreferences();

        }
        public override void OnBackPressed()
        {

            base.OnBackPressed();

        }

        public void LoadPreferences() // load this data when game starts.
        {
            print(game_control.HighScore);
            scoreText.text = game_control.HighScore.ToString();
               
        }
    }

}
