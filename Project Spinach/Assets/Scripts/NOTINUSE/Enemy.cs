using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Lyndsey Narvaez
//Enemy AI that chases the player when they enter a the enemy's radius
public class Enemy : MonoBehaviour
{
    public float speed = 3f;
    [SerializeField] private float attackDamage = 10f;
    [SerializeField] private float attackSpeed = 1f;
    private float canAttack;

    private Transform target;

    //Enemy chases the player once they enter the target
    //Stops chasing the player when not in the target
    private void Update()
    {
        if(target != null)
        {
            float step = speed * Time.deltaTime;
            transform.position = Vector2.MoveTowards(transform.position, target.position, step);
        }
    }

    //Enemy attacks the player and deals damage to them
    private void OnCollisionStay2D(Collision2D other)
    {
        if (other.gameObject.tag == "Player1" || other.gameObject.tag == "Player2")
        {
            if(attackSpeed <= canAttack)
            {
                other.gameObject.GetComponent<PlayerHealth>().UpdateHealth(-attackDamage);
                canAttack = 0f;

                //example of an increase in health
                //other.gameObject.GetComponent<PlayerHealth>().UpdateHealth(100f);
            }
            else
            {
                canAttack += Time.deltaTime;
            }
        }
    }

    //Checks if the player is in the radius
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player1" || other.gameObject.tag == "Player2")
        {
            target = other.transform;

            //Debug.Log(target);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {

        if (other.gameObject.tag == "Player1" || other.gameObject.tag == "Player2")
        {
            target = null;
        }
    }

}
