using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Lyndsey Narvaez

public class CrowBehavior : MonoBehaviour
{
    public float speed = 3f;
    private Transform target;

    //Enemy moves to the plot when in target
    //Stops chasing the player when not in the target
    private void Update()
    {
        if (target != null)
        {
            float step = speed * Time.deltaTime;
            transform.position = Vector2.MoveTowards(transform.position, target.position, step);
        }
    }
    
    // use pat function to "remove" the plot that was planted
    // harvest()


    //Checks if the player is in the radius
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player1" || other.gameObject.tag == "Player2")
        {
            target = other.transform;

            Debug.Log(target);
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
