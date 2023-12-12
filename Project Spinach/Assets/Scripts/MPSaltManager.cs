using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//Patrick Gudikunst
public class MPSaltManager : MonoBehaviour
{
    public GameObject P1;
    public GameObject P2;

    public MPPlayerSO player1Stats;
    public MPPlayerSO player2Stats;
    
    public SpriteRenderer saltSprite;
    [SerializeField] private float timeSaltDuration = 5f;
    float salt1Timer;
    float salt2Timer;
    //bool salt1PowerupActive = false;
    //bool salt2PowerupActive = false;
    bool saltAvailable = true;

    void Update()
    {
        if (player1Stats.affectingPowerup == "salt" || player2Stats.affectingPowerup == "salt")
        {
            if (P1.GetComponent<SpPlayerTest>().P1PowerupActive)
            {
                salt1Timer -= Time.deltaTime;
                if (salt1Timer < 0)
                {
                    Debug.Log("Salt Powerup for Player 1 wears off");
                    salt1Timer = timeSaltDuration;
                    Salt1PowerupWearOff();
                }
            }
            if (P2.GetComponent<SpPlayerTest>().P2PowerupActive)
            {
                salt2Timer -= Time.deltaTime;
                if (salt2Timer < 0)
                {
                    Debug.Log("Salt Powerup for Player 2 wears off");
                    salt2Timer = timeSaltDuration;
                    Salt2PowerupWearOff();
                }
            }
        }
    }

    //Player walking over a powerup should give the player the powerup
    private void OnTriggerEnter2D(Collider2D player)
    {
        if (player.GetComponent<PlayerControlU>() != null && saltAvailable)
        {
            Debug.Log("Salt picked up!");
            GiveSaltPowerup(player);

            saltSprite.gameObject.SetActive(false);
            saltAvailable = false;
        }
    }

    public void GiveSaltPowerup(Collider2D player = null)
    {
        if (player.gameObject.tag == "Player1" && P1.GetComponent<SpPlayerTest>().P1PowerupActive == false)
        {
            P1.GetComponent<SpPlayerTest>().P1PowerupActive = true;
            salt1Timer = timeSaltDuration;
            player1Stats.affectingPowerup = "salt";
            //salt1PowerupActive = true;
        }
        if (player.gameObject.tag == "Player2" && P2.GetComponent<SpPlayerTest>().P2PowerupActive == false)
        {
            P2.GetComponent<SpPlayerTest>().P2PowerupActive = true;
            salt2Timer = timeSaltDuration;
            player2Stats.affectingPowerup = "salt";
            //salt2PowerupActive = true;
        }
    }

    public void Salt1PowerupWearOff()
    {
        P1.GetComponent<SpPlayerTest>().P1PowerupActive = false;
        player1Stats.affectingPowerup = null;
        //salt1PowerupActive = false;
    }

    public void Salt2PowerupWearOff()
    {
        P2.GetComponent<SpPlayerTest>().P2PowerupActive = false;
        player2Stats.affectingPowerup = null;
        //salt2PowerupActive = false;
    }
}
