using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Victoria Garcia & Lyndsey Narvaez
//Keep track of AI speed and when it has powerups
[CreateAssetMenu(fileName = "New AI", menuName = "AI")]
public class MPPlayerAISO: ScriptableObject
{
    //variable to control the players speed
    [SerializeField] public float a_PlayerSpeed;

    //variable for identifying the currently active powerup
    [SerializeField] public string affectingPowerup;
}
