using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Melvin Cruz
//PLEASE DO NOT BREATHE ON THIS WRONG
//simple player controls that controlls the players movement and animations
public class PlayerControlU : MonoBehaviour
{
    //reference call to the scriptable object for the player
    public MPPlayerSO playerStats;
    //boolean to see if the controls pretain to the menu
    [SerializeField] private bool m_MovementDisabled;

    //variable for the animator of the player
    private Animator m_PlayerAnim;

    //variable for the player spriterenderer
    private SpriteRenderer m_PlayerRen;
    // Start is called before the first frame update


    void Start()
    {
        m_PlayerAnim = GetComponent<Animator>();
        if (m_PlayerAnim != null)
        {
            m_PlayerAnim.SetBool("RunBool", false);
        }
        m_PlayerRen = GetComponent<SpriteRenderer>();
    }

    void FixedUpdate()
    {
        if (m_MovementDisabled == false)
        {
            if (Input.GetKey(playerStats.m_MoveUp))
            {
                transform.position += new Vector3(0, 0.1f, 0) * playerStats.m_PlayerSpeed;
            }
            if (Input.GetKey(playerStats.m_MoveLeft))
            {
                transform.position += new Vector3(-0.1f, 0, 0) * playerStats.m_PlayerSpeed;
                if (m_PlayerRen != null)
                {
                    // Faces the character to the left
                    m_PlayerRen.flipX = true;
                }
            }
            if (Input.GetKey(playerStats.m_MoveDown))
            {
                transform.position += new Vector3(0, -0.1f, 0) * playerStats.m_PlayerSpeed;
            }
            if (Input.GetKey(playerStats.m_MoveRight))
            {
                transform.position += new Vector3(0.1f, 0, 0) * playerStats.m_PlayerSpeed;
                if (m_PlayerRen != null)
                {
                    // Leaves the character facing right
                    m_PlayerRen.flipX = false;
                }
            }
            if (Input.GetKey(playerStats.m_MoveUp) || Input.GetKey(playerStats.m_MoveLeft) || Input.GetKey(playerStats.m_MoveDown) || Input.GetKey(playerStats.m_MoveRight))
            {
                m_PlayerAnim.SetBool("RunBool", true);
            }
            else
            {
                m_PlayerAnim.SetBool("RunBool", false);
            }
        }
        else if (m_MovementDisabled == true)
        {
            m_PlayerAnim.SetBool("RunBool", false);
        }
    }
}
