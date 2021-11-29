using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LevelManagement
{
    //creating generic singlton pattern for sub classes.
    public abstract class Menu<T> : Menu where T: Menu<T>
    {
        private static T instance;

        public static T Instance { get => instance; }

        protected virtual void Awake() //using protected here for the derived classes to access this. Virtual in case sub classs needs to overide.
        {
            if(instance != null) // destroy if any multpile instances are present.
            {
                Destroy(gameObject);
            }
            else
            {
                instance = (T)this; //casting to Menu<T>
            }

        }
        protected virtual void OnDestroy() 
        {
            instance = null;
        }

        public static void open()
        {
            if(MenuManager.Instance  != null && instance != null)
            {
                MenuManager.Instance.OpenMenu(Instance);
            }
                    

            
        }
    }
    [RequireComponent(typeof(Canvas))]
    public abstract class Menu : MonoBehaviour
    {

       
        public virtual void OnBackPressed() // All menu screens will have this in common
        {
            if (MenuManager.Instance !=null)
            {
                MenuManager.Instance.CloseMenu();
            }

        }
    } 
}
