using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LevelManagement
{
    public class ScoreMenu : Menu<ScoreMenu> //using generic menu
    {
        
        public override void OnBackPressed()
        {
            //add sound here 
            base.OnBackPressed();
        }
    }

}
