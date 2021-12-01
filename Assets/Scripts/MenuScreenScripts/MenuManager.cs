using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace LevelManagement
{
    public class MenuManager : MonoBehaviour
    {
        public MainMenu mainMenuPrefab;
        public SettingsMenu settingsScreenPrefab;
        public ScoreMenu ScorePrefab;
        public GameMenu gameMenuPrefab;
        public PauseMenu pauseMenuPrefab;
        public Winscreen winScreenPrefab;
        public GameOverMenu gameOverMenuPrefab;
        AudioSource MyAudioSource;
        public int playerScore, healthScore=100;
        public int LevelNum;

        Slider slider;
        [SerializeField]
        private Transform menuParent; //To group menus under one parent

        private Stack<Menu> MenuStack = new Stack<Menu>(); // Have a empty stack to keep track of things for back button
        private static MenuManager instance;

        public static MenuManager Instance { get => instance; } // encapsulation gives us public means of accessing private instance
        

        private void Awake()
        {
            if(instance != null)
            {
                Destroy(gameObject);
            }
            else
            {
                instance = this;
            }
             //this component
            InitializeMenus();
            DontDestroyOnLoad(gameObject);
            MyAudioSource = GetComponent<AudioSource>();
            MyAudioSource.volume = SettingsMenu.Instance.volumeSlider.value;
        }

        private void OnDestroy()
        {
           if(instance == this)
            {
                instance = null;
            }
        }

        public void SetVolume(float volume)
        {
            if(MyAudioSource != null)
            {
                MyAudioSource.volume = volume;
            }
            
        }
        private void InitializeMenus() // To instantiate prefabs when level loads
        {
            if (menuParent == null) //creating parent with name - Menus and getting its transform
            {
                GameObject menuParentObject = new GameObject("Menus");
                menuParent = menuParentObject.transform;
            }
            DontDestroyOnLoad(menuParent.gameObject);

            Menu[] menuPrefabs = { mainMenuPrefab, settingsScreenPrefab, ScorePrefab, gameMenuPrefab, pauseMenuPrefab, winScreenPrefab,gameOverMenuPrefab };
            foreach (Menu prefab in menuPrefabs)
            {
                if (prefab != null) // if prefab is not null, then instantiate and store in local variable as child of menuParent
                {
                    Menu menuInstance = Instantiate(prefab, menuParent);
                    if (prefab != mainMenuPrefab) // set only main menu as actice initially
                    {
                        menuInstance.gameObject.SetActive(false);
                    }
                    else // making sure Main Menu is bottom of the stack
                    {
                        OpenMenu(menuInstance);
                    }
                }
            }

        }

        // when menu is opened, set inactive all other menu in the stack and make this active
        public void OpenMenu(Menu menuInstance) //passing the instantiated menu from hierarchy and not prefab
        {
            if(menuInstance == null) 
            {
                Debug.LogWarning("Invalid Mneu");
                    return;
            }
            if (MenuStack.Count > 0)
            {
                foreach( Menu menu in MenuStack)
                {
                    menu.gameObject.SetActive(false); //Initially make all menu instances inactive
                }
            }
            menuInstance.gameObject.SetActive(true); // enable the top menu
            MenuStack.Push(menuInstance); //add the present to the stack.
        }

        public void CloseMenu() // close whatever is on top of stack.
        {
            if(MenuStack.Count == 0)
            {
                Debug.LogWarning("No menu in stack"); 
                return;
            }

            Menu topMenu = MenuStack.Pop();// remove the present 
            topMenu.gameObject.SetActive(false); //once it is popped, make that inactive
            if(MenuStack.Count > 0) //if there are menus still present
            {
                Menu nextMenu = MenuStack.Peek(); //refering the next top menu
                nextMenu.gameObject.SetActive(true);//setting it active.
            }
        }

        public void Update()
        {
            playerScore = Game_Control.SharedInstance.playerScore;
            healthScore = Game_Control.SharedInstance.playerHealth;
        }
    } 
}
