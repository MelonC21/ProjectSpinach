using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//Melvin Cruz and by Victoria
//Sets up the game state manager
public class SpGameStateManager : MonoBehaviour
{
    [SerializeField] private string m_GameLevelName;

    [SerializeField] private string m_LossSceneName;

    [SerializeField] private string m_WinSceneName;

    [SerializeField] private string m_GameTitle;

    [SerializeField] private string m_MPSceneName;

    [SerializeField] private string m_AiMpSceneName;

    public static SpGameStateManager _instanceGSM;
    
    //creates a singleton of the manager
    private void Awake()
    {
        if (_instanceGSM == null)
        {
            _instanceGSM = this;
            DontDestroyOnLoad(_instanceGSM);
        }
        else
        {
            Destroy(this);
        }
    }

    //When a new game is needed
    public static void NewGame()
    {
        SceneManager.LoadScene(_instanceGSM.m_GameLevelName);
    }

    //Goes to the title scene
    public static void ToTitle()
    {
        SceneManager.LoadScene(_instanceGSM.m_GameTitle);
    }


    //Goes to the loss scene
    public static void ToLossScreen()
    {
        SceneManager.LoadScene(_instanceGSM.m_LossSceneName);
    }

    //Goes to the win scene
    public static void ToWinScreen()
    {
        SceneManager.LoadScene(_instanceGSM.m_WinSceneName);
    }

    public static void MultiplayerGame()
    {
        SceneManager.LoadScene(_instanceGSM.m_MPSceneName);
    }

    public static void AiMulitplayerGame()
    {
        SceneManager.LoadScene(_instanceGSM.m_AiMpSceneName);
    }
}
