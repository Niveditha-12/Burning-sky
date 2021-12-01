using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace LevelManagement
{
    public class LevelLoader : MonoBehaviour
    {
        public static void LoadLevel (int level)
        {
            if(level ==0)
            {
                MainMenu.open();
            }
            SceneManager.LoadScene(level);
            
        }

        public static void reloadLevel()
        {
            LoadLevel(SceneManager.GetActiveScene().buildIndex);
        }

        public static void LoadNextLevel()
        {
           int levelNum = SceneManager.GetActiveScene().buildIndex +1
            % SceneManager.sceneCountInBuildSettings;
            LoadLevel(levelNum);
        }

        public static void LoadMainMenu()
        {
            SceneManager.LoadScene(0);
        }
    }

}