using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//Patrick Gudikunst
public class MPFertilizerManager : MonoBehaviour
{
    public GameObject P1;
    public GameObject P2;

    public MPPlayerSO player1Stats;
    public MPPlayerSO player2Stats;
    
    public SpriteRenderer fertilizerSprite;
    [SerializeField] private float timeFertilizerDuration = 5f;
    float fertilizer1Timer;
    float fertilizer2Timer;
    //bool fertilizer1PowerupActive = false;
    //bool fertilizer2PowerupActive = false;
    bool fertilizerAvailable = true;

    void Update()
    {
        if (player1Stats.affectingPowerup == "fertilizer" || player2Stats.affectingPowerup == "fertilizer")
        {
            if (P1.GetComponent<SpPlayerTest>().P1PowerupActive)
            {
                fertilizer1Timer -= Time.deltaTime;
                if (fertilizer1Timer < 0)
                {
                    Debug.Log("Fertilizer Powerup for Player 1 wears off");
                    fertilizer1Timer = timeFertilizerDuration;
                    Fertilizer1PowerupWearOff();
                }
            }
            if (P2.GetComponent<SpPlayerTest>().P2PowerupActive)
            {
                fertilizer2Timer -= Time.deltaTime;
                if (fertilizer2Timer < 0)
                {
                    Debug.Log("Fertilizer Powerup for Player 2 wears off");
                    fertilizer2Timer = timeFertilizerDuration;
                    Fertilizer2PowerupWearOff();
                }
            }
        }
    }

    //Player walking over a powerup should give the player the powerup
    private void OnTriggerEnter2D(Collider2D player)
    {
        if (player.GetComponent<PlayerControlU>() != null && fertilizerAvailable)
        {
            Debug.Log("Fertilizer picked up!");
            GiveFertilizerPowerup(player);

            fertilizerSprite.gameObject.SetActive(false);
            fertilizerAvailable = false;
        }
    }

    public void GiveFertilizerPowerup(Collider2D player = null)
    {
        if (player.gameObject.tag == "Player1" && P1.GetComponent<SpPlayerTest>().P1PowerupActive == false)
        {
            P1.GetComponent<SpPlayerTest>().P1PowerupActive = true;
            fertilizer1Timer = timeFertilizerDuration;
            player1Stats.affectingPowerup = "fertilizer";
            //fertilizer1PowerupActive = true;
        }
        if (player.gameObject.tag == "Player2" && P2.GetComponent<SpPlayerTest>().P2PowerupActive == false)
        {
            P2.GetComponent<SpPlayerTest>().P2PowerupActive = true;
            fertilizer2Timer = timeFertilizerDuration;
            player2Stats.affectingPowerup = "fertilizer";
            //fertilizer2PowerupActive = true;
        }
    }

    public void Fertilizer1PowerupWearOff()
    {
        P1.GetComponent<SpPlayerTest>().P1PowerupActive = false;
        player1Stats.affectingPowerup = null;
        //fertilizer1PowerupActive = false;
    }

    public void Fertilizer2PowerupWearOff()
    {
        P2.GetComponent<SpPlayerTest>().P2PowerupActive = false;
        player2Stats.affectingPowerup = null;
        //fertilizer2PowerupActive = false;
    }
}
