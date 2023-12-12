using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Coded by Melvin
[CreateAssetMenu(fileName = "New Player", menuName = "PlayerXX")]
public class MPPlayerSO : ScriptableObject
{
    //variable to control the players speed
    [SerializeField] public float m_PlayerSpeed;

    //variable for left move
    [SerializeField] public KeyCode m_MoveLeft;

    //variable for right move
    [SerializeField] public KeyCode m_MoveRight;

    //variable for down move
    [SerializeField] public KeyCode m_MoveDown;

    //variable for up move
    [SerializeField] public KeyCode m_MoveUp;

    //variable for identifying the currently active powerup
    [SerializeField] public string affectingPowerup;
}
