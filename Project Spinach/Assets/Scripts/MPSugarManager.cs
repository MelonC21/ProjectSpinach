using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//Patrick Gudikunst
public class MPSugarManager : MonoBehaviour
{
    public GameObject P1;
    public GameObject P2;

    public MPPlayerSO player1Stats;
    public MPPlayerSO player2Stats;
    
    public SpriteRenderer sugarSprite;
    [SerializeField] private float sugarSpeedBoostMultiplier = 1.5f;
    [SerializeField] private float timeSugarDuration = 5f;
    float sugar1Timer;
    float sugar2Timer;
    //bool sugar1PowerupActive = false;
    //bool sugar2PowerupActive = false;
    bool sugarAvailable = true;

    void Update()
    {
        if (player1Stats.affectingPowerup == "sugar" || player2Stats.affectingPowerup == "sugar")
        {
            if (P1.GetComponent<SpPlayerTest>().P1PowerupActive)
            {
                sugar1Timer -= Time.deltaTime;
                if (sugar1Timer < 0)
                {
                    Debug.Log("Sugar Powerup for Player 1 wears off");
                    sugar1Timer = timeSugarDuration;
                    Sugar1PowerupWearOff();
                }
            }
            if (P2.GetComponent<SpPlayerTest>().P2PowerupActive)
            {
                sugar2Timer -= Time.deltaTime;
                if (sugar2Timer < 0)
                {
                    Debug.Log("Sugar Powerup for Player 2 wears off");
                    sugar2Timer = timeSugarDuration;
                    Sugar2PowerupWearOff();
                }
            }
        }
    }

    //Player walking over a powerup should give the player the powerup
    private void OnTriggerEnter2D(Collider2D player)
    {
        if (player.GetComponent<PlayerControlU>() != null && sugarAvailable)
        {
            Debug.Log("Sugar picked up!");
            GiveSugarPowerup(player);

            sugarSprite.gameObject.SetActive(false);
            sugarAvailable = false;
        }
    }

    public void GiveSugarPowerup(Collider2D player)
    {
        if (player.gameObject.tag == "Player1" && P1.GetComponent<SpPlayerTest>().P1PowerupActive == false)
        {
            P1.GetComponent<SpPlayerTest>().P1PowerupActive = true;
            player1Stats.m_PlayerSpeed *= sugarSpeedBoostMultiplier;
            player1Stats.affectingPowerup = "sugar";
            sugar1Timer = timeSugarDuration;
            //sugar1PowerupActive = true;
        }
        if (player.gameObject.tag == "Player2" && P2.GetComponent<SpPlayerTest>().P2PowerupActive == false)
        {
            P2.GetComponent<SpPlayerTest>().P2PowerupActive = true;
            player2Stats.m_PlayerSpeed *= sugarSpeedBoostMultiplier;
            player2Stats.affectingPowerup = "sugar";
            sugar2Timer = timeSugarDuration;
            //sugar2PowerupActive = true;
        }
    }

    public void Sugar1PowerupWearOff()
    {
        player1Stats.m_PlayerSpeed = 1;
        P1.GetComponent<SpPlayerTest>().P1PowerupActive = false;
        player1Stats.affectingPowerup = null;
        //sugar1PowerupActive = false;
    }

    public void Sugar2PowerupWearOff()
    {
        player2Stats.m_PlayerSpeed = 1;
        P2.GetComponent<SpPlayerTest>().P2PowerupActive = false;
        player2Stats.affectingPowerup = null;
        //sugar2PowerupActive = false;
    }
}
