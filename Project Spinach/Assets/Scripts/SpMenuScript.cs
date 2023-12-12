using UnityEngine;

//Melvin Cruz and assisted by Victoria
//used for the menu of the game click esc to enter the menu
public class SpMenuScript : MonoBehaviour
{
    [SerializeField] private bool multiplayerGame;

    private bool gameIsPaused = false;

    public bool m_DisablePause;

    [SerializeField] private GameObject [] menuUIs;

    [SerializeField] private GameObject PauseUI;

    PlantMenu menuStore;

    private void Start()
    {
        menuStore = FindObjectOfType<PlantMenu>();
    }

    //checks if the menu is even allowed to be on the screen and if a request has been made
    private void Update()
    {
        if (m_DisablePause == false)
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                if (gameIsPaused == false)
                {
                    OnClickPause();
                }
                else if (gameIsPaused == true)
                {
                    return;
                }
            }
        }
        else if (m_DisablePause == true)
            return;
    }

    
    //Used for the quit button
    public void OnClickQuitGame()
    {
        Application.Quit();
    }

    //Used for the menu button
    public void OnClickMenu()
    {
        Time.timeScale = 1f;
        SpGameStateManager.ToTitle();
    }

    //resumes the game
    public void OnClickResume()
    {
        PauseUI.SetActive(false);
        Time.timeScale = 1f;
        gameIsPaused = false;
        foreach (GameObject i in menuUIs)
        {
            i.SetActive(true);
        }
        if (multiplayerGame != true)
        {
            menuStore.m_PlantMenuDisable = false;
        }
        else
            return;
    }

    //pauses the game
    public void OnClickPause()
    {
        
        foreach (GameObject i in menuUIs)
        {
            i.SetActive(false);
        }
        PauseUI.SetActive(true);
        gameIsPaused = true;
        Time.timeScale = 0f;
        if (multiplayerGame != true)
        {
            menuStore.m_PlantMenuDisable = true;
        }
        else
            return;
    }


    //used for the play new game buttion
    public void OnClickPlayGame()
    {
        Time.timeScale = 1f;
        if(gameIsPaused == true)
        {
            gameIsPaused = false;
        }
        SpGameStateManager.NewGame();
    }

    public void OnClickMultiplayer()
    {
        Time.timeScale = 1f;
        if (gameIsPaused == true)
        {
            gameIsPaused = false;
        }
        SpGameStateManager.MultiplayerGame();
    }

    public void OnClickAIMultiplayer()
    {
        Time.timeScale = 1f;
        if (gameIsPaused == true)
        {
            gameIsPaused = false;
        }
        SpGameStateManager.AiMulitplayerGame();
    }
}
