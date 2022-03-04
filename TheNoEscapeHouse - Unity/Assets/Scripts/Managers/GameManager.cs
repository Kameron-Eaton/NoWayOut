/**** 
 * Created by: Akram Taghavi-Burrs
 * Date Created: Feb 23, 2022
 * 
 * Last Edited by: Kameron Eaton
 * Last Edited: Feb 28, 2022
 * 
 * Description: Basic GameManager Template
****/

/** Import Libraries **/
using System; //C# library for system properties
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; //libraries for accessing scenes


public class GameManager : MonoBehaviour
{
    /*** VARIABLES ***/

    #region GameManager Singleton
    static private GameManager gm; //refence GameManager
    static public GameManager GM { get { return gm; } } //public access to read only gm 

    //Check to make sure only one gm of the GameManager is in the scene
    void CheckGameManagerIsInScene()
    {
    
        //Check if instnace is null
        if (gm == null)
        {
           gm = this; //set gm to this gm of the game object
            Debug.Log(gm);
        }
        else //else if gm is not null a Game Manager must already exsist
        {
            Destroy(this.gameObject); //In this case you need to delete this gm
        }
        //Do not delete the GameManager when scenes load
        Debug.Log(gm);
    }//end CheckGameManagerIsInScene()
    #endregion

    [Header("GENERAL SETTINGS")]
    public string gameTitle = "Untitled Game";  //name of the game
    public string gameCredits = "Made by Me"; //game creator(s)
    public string copyrightDate = "Copyright " + thisDay; //date cretaed

    [Header("GAME SETTINGS")]

    [Tooltip("Will the high score be recoreded")]
    public bool recordHighScore = false; //is the High Score recorded

    [SerializeField] //Access to private variables in editor
    private int defaultHighScore = 1000;
    static public int highScore = 1000; // the default High Score
    public int HighScore { get { return highScore; } set { highScore = value; } }//access to private variable highScore [get/set methods]

    [Space(10)]
    
    //static vairables can not be updated in the inspector, however private serialized fileds can be
    [SerializeField] //Access to private variables in editor
    private int numberOfLives; //set number of lives in the inspector
    static public int lives; // number of lives for player 
    public int Lives { get { return lives; } set { lives = value; } }//access to private variable died [get/set methods]

    static public int score;  //score value
    public int Score { get { return score; } set { score = value; } }//access to private variable died [get/set methods]

    [SerializeField] //Access to private variables in editor
    [Tooltip("Check to test player lost the level")]
    private bool levelLost = false;//we have lost the level (ie. player died)
    public bool LevelLost { get { return levelLost; } set { levelLost = value; } } //access to private variable lostLevel [get/set methods]

    [Space(10)]
    public string defaultEndMessage = "Game Over";//the end screen message, depends on winning outcome
    public string looseMessage = "You Loose"; //Message if player looses
    public string winMessage = "You Win"; //Message if player wins
    [HideInInspector] public string endMsg ;//the end screen message, depends on winning outcome

    [Header("SCENE SETTINGS")]
    [Tooltip("Name of the start scene")]
    public string startScene;
    
    [Tooltip("Name of the game over scene")]
    public string gameOverScene;
    
    [Tooltip("Count and name of each Game Level (scene)")]
    public string[] gameLevels; //names of levels
    [HideInInspector]
    public int gameLevelsCount; //what level we are on
    private int loadLevel; //what level from the array to load
     
    public static string currentSceneName; //the current scene name;

    [Header("FOR TESTING")]
    public bool nextLevel = false; //test for next level

    //Game State Varaiables
    [HideInInspector] public enum gameStates { Idle, Playing, Death, GameOver, BeatLevel };//enum of game states
    [HideInInspector] public gameStates gameState = gameStates.Idle;//current game state

    //Timer Varaibles
    private float currentTime; //sets current time for timer
    private bool gameStarted = false; //test if games has started

    //Win/Loose conditon
    [SerializeField] //to test in inspector
    private bool playerWon = false;
 
   //reference to system time
   private static string thisDay = System.DateTime.Now.ToString("yyyy"); //today's date as string

    public static GameManager ins;

    [HideInInspector]
    public Node currNode;
    public Item itemHeld;

    public CameraRig rig;

    public Node startingNode;

    public IVCanvas ivCanvas;

    public ObsCamera obsCamera;

    public HUDCanvas invDisplay;

    public Keypad keyCanvas;

    /*** MEHTODS ***/
   
   //Awake is called when the game loads (before Start).  Awake only once during the lifetime of the script instance.
    void Awake()
    {
        ins = this; //Define singleton
        ivCanvas.gameObject.SetActive(false);

        //runs the method to check for the GameManager
        CheckGameManagerIsInScene();

        //store the current scene
        currentSceneName = UnityEngine.SceneManagement.SceneManager.GetActiveScene().name;

        obsCamera.gameObject.SetActive(false); //set observer camera false

    }//end Awake()

    void Start()
    {
        startingNode.Arrive();
        
    }//end Start


    // Update is called once per frame
    private void Update()
    {
        //if ESC is pressed , exit game
        if (Input.GetKey("escape")) { ExitGame(); }
        
        //Check for next level
        if (nextLevel) { NextLevel(); }

        //if we are playing the game
        if (gameState == gameStates.Playing)
        {
            //if we have died and have no more lives, go to game over
            if (levelLost && (lives == 0)) { GameOver(); }

        }//end if (gameState == gameStates.Playing)

        if(Input.GetMouseButtonDown(1) && currNode.GetComponent<Prop>() != null)
        {
            if (ivCanvas.gameObject.activeInHierarchy)
            {
                ivCanvas.Close();
                return; //close image viewer and return if image viewer is open
            }//end if
            if (obsCamera.gameObject.activeInHierarchy)
            {
                obsCamera.Close(); 
                return; //close observation camera and return if camera is open
            }//end if
            currNode.GetComponent<Prop>().loc.Arrive();
        }//end if

    }//end Update


    //LOAD THE GAME FOR THE FIRST TIME OR RESTART
   public void StartGame()
    {
        //SET ALL GAME LEVEL VARIABLES FOR START OF GAME

        gameLevelsCount = 1; //set the count for the game levels
        loadLevel = gameLevelsCount - 1; //the level from the array
        SceneManager.LoadScene(gameLevels[loadLevel]); //load first game level

        gameState = gameStates.Playing; //set the game state to playing

        lives = numberOfLives; //set the number of lives
        score = 0; //set starting score
    }//end StartGame()



    //EXIT THE GAME
    public void ExitGame()
    {
        Application.Quit();
        Debug.Log("Exited Game");
    }//end ExitGame()


    //GO TO THE GAME OVER SCENE
    public void GameOver()
    {
        gameState = gameStates.GameOver; //set the game state to gameOver

       if(playerWon) { endMsg = winMessage; } else { endMsg = looseMessage; } //set the end message

        SceneManager.LoadScene(gameOverScene); //load the game over scene
        Debug.Log("Gameover");
    }
    
    
    //GO TO THE NEXT LEVEL
        void NextLevel()
    {
        nextLevel = false; //reset the next level

        //as long as our level count is not more than the amount of levels
        if (gameLevelsCount < gameLevels.Length)
        {
            gameLevelsCount++; //add to level count for next level
            loadLevel = gameLevelsCount - 1; //find the next level in the array
            SceneManager.LoadScene(gameLevels[loadLevel]); //load next level

        }else{ //if we have run out of levels go to game over
            GameOver();
        } //end if (gameLevelsCount <=  gameLevels.Length)

    }//end NextLevel()
}
