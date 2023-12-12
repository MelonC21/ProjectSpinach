using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//Patrick Gudikunst
public class MPPowerupManager : MonoBehaviour
{
    public GameObject sugarPowerup;
    public GameObject fertilizerPowerup;
    public GameObject saltPowerup;

    public void AllPowerupsWearOff(Collider2D player = null)
    {
        Debug.Log("All powerups wear off at the end of the game");
        sugarPowerup.GetComponent<MPSugarManager>().Sugar1PowerupWearOff();
        sugarPowerup.GetComponent<MPSugarManager>().Sugar2PowerupWearOff();

        fertilizerPowerup.GetComponent<MPFertilizerManager>().Fertilizer1PowerupWearOff();
        fertilizerPowerup.GetComponent<MPFertilizerManager>().Fertilizer2PowerupWearOff();

        saltPowerup.GetComponent<MPSaltManager>().Salt1PowerupWearOff();
        saltPowerup.GetComponent<MPSaltManager>().Salt2PowerupWearOff();
    }
}
