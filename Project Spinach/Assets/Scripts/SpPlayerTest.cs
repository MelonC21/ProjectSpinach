using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//Victoria Garcia & Melvin Cruz & Lyndsey Narvaez
public class SpPlayerTest : MonoBehaviour
{
    public static SpPlayerTest p_instance;

    [SerializeField] private float winCondition;

    [SerializeField] private float maxHealth;

    public bool P1PowerupActive = false;
    public bool P2PowerupActive = false;
    public GameObject powerupManager;

    //Meant to determine if the player is a multiplayer character
    [SerializeField] private bool multiplayerPlayer;

    public float currentHealth;

    public HealthBar healthBar;

    private float healthTickStart;

    [SerializeField] private float timeHPTick;

    [SerializeField] public float HPLoss;

    [SerializeField] public Text moneyText;

    [SerializeField] public int money;

    [SerializeField] private GameObject[] disableHud;

    [SerializeField] private GameObject[] endingScreenLoss;

    [SerializeField] private GameObject[] endingScreenWin;


    // Start is called before the first frame update
    void Start()
    {
        if (multiplayerPlayer)
        {
            powerupManager.GetComponent<MPPowerupManager>().AllPowerupsWearOff();
        }

        moneyText.text = "$" + money;

        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);

        p_instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        healthTickStart -= Time.deltaTime;
        if (healthTickStart < 0)
        {
            healthTickStart = timeHPTick;
            LoseHealth(HPLoss);
        }
        if (multiplayerPlayer != true)
        {
            if (currentHealth <= 0)
            {
                SpGameStateManager.ToLossScreen();
            }

            if (money >= winCondition)
            {
                SpGameStateManager.ToWinScreen();
            }
        }

        else if (multiplayerPlayer)
        {
            if (currentHealth <= 0)
            {
                foreach (GameObject i in disableHud)
                {
                    i.SetActive(false);
                }
                foreach (GameObject i in endingScreenLoss)
                {
                    i.SetActive(true);
                }
                Time.timeScale = 0f;
                powerupManager.GetComponent<MPPowerupManager>().AllPowerupsWearOff();
            }

            if (money >= winCondition)
            {
                foreach(GameObject i in disableHud)
                {
                    i.SetActive(false);
                }
                foreach(GameObject i in endingScreenWin)
                {
                    i.SetActive(true);
                }
                Time.timeScale = 0f;
                powerupManager.GetComponent<MPPowerupManager>().AllPowerupsWearOff();
            }
        }
    }

    //Hurts the player
    public void LoseHealth(float hurt)
    {
        currentHealth -= hurt;
        healthBar.SetHealth(currentHealth);
    }

    //Adds to the players health
    public void gainHealth(float addHP)
    {
        if (currentHealth < maxHealth)
        {
            currentHealth += addHP;
            healthBar.SetHealth(currentHealth);
        }
    }

    //Adds money to the players count
    public void gainMoney(int addMoney)
    {
        money += addMoney;
        moneyText.text = "$" + money;
    }
}
