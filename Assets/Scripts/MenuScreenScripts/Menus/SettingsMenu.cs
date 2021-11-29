using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


namespace LevelManagement
{
    public class SettingsMenu : Menu<SettingsMenu> 
    {
        
        public Slider volumeSlider;
        private MenuManager menuManager;
        

        protected override void Awake() // search for player prefs and sets the saved data.
        {
            
            base.Awake();
            LoadPreferences();


        }
        
        public override void OnBackPressed()
        {
             
            base.OnBackPressed();
            PlayerPrefs.Save(); //save all the data changed.
        }

        public void OnVoulmeSlide(float volume) //passing values from slider as volume.
        {
            
            PlayerPrefs.SetFloat("BGMVolume", volume);// save the data in key-value using playerprefs
            volumeSlider.value = PlayerPrefs.GetFloat("BGMVolume");
            
            MenuManager.Instance.SetVolume(volumeSlider.value);
        }

        public void LoadPreferences() // load this data when game starts.
        {
            
            volumeSlider.value = PlayerPrefs.GetFloat("BGMVolume");
        }
    }

}
