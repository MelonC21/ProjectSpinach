using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Victoria Garcia & Lyndsey Narvaez
public class PlayerTwoBehavior : MonoBehaviour
{
    private float haveCrop;

    //serialized field to determine AI speed
    [SerializeField] private float playerSpeed;

    //variables to allow AI to move from one plot to another
    [SerializeField] private Transform[] Targets;
    private int NextTarIndex;
    private Transform NextTarget;
   
    //references to other scripts
    public MPPlayerAISO aiStats;
    //public SpPlayerTest playertest;

    //begins the list of targets
    void Start()
    {
        NextTarget = Targets[0];
    }


    //Player Two grabs crops
    private void OnCollisionStay2D(Collision2D other)
    {
        //|| other.gameObject.tag == "Fruit"
        if (other.gameObject.tag == "Vegetable" || other.gameObject.tag == "Fruit")
        {
            if (playerSpeed <= haveCrop)
            {
                //other.gameObject.GetComponent<MPFarmManager>().Harvest();
                //agent.SetDestination(NextTarget.position);
                haveCrop = 0f;

            }
            else
            {
                haveCrop += Time.deltaTime;
            }
        }
        
    }

    //Player Two goes from one plot to another
    private void MoveGameObject()
    {
        if (transform.position == NextTarget.position)
        {
            //GetComponent<MPFarmManager>().Harvest();
            NextTarIndex++;

            if (NextTarIndex >= Targets.Length)
            {
                NextTarIndex = 0;  
            }

            NextTarget = Targets[NextTarIndex];
        }
        else
        {
            transform.position = Vector3.MoveTowards(transform.position, NextTarget.position, playerSpeed * Time.deltaTime);
        }
    }

    //Player Two goes to harvest crops
    void Update()
    {
        MoveGameObject();
    }
}
