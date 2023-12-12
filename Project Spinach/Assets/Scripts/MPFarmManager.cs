using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//Patrick Gudikunst
public class MPFarmManager : MonoBehaviour
{
    bool isPlanted = false;
    bool isFullyGrown = false;
    public SpriteRenderer plantSprite;

    public Sprite[] plantStages; //holds all the sprites that represent the different stages
    int plantAge = 0; //keeps track of which stage the plant is at

    [SerializeField] private int vegPoints;

    [SerializeField] private int fruHealth;

    [SerializeField] private float timeBtwnStages = 3f;
    [SerializeField] private float saltedTimeBtwnStages = 4.5f;
    [SerializeField] private float fertilizedTimeBtwnStages = 2f;

    [SerializeField] private float timeToSpoil = 6f;
    [SerializeField] private float saltedTimeToSpoil = 6f;

    [SerializeField] private float replantTime = 2f;
    [SerializeField] private float fertilizedReplantTime = 1f;

    float growTimer;
    float spoilTimer;

    public bool isFruits;

    // Start is called before the first frame update
    void Start()
    {
        Plant();
    }

    // Update is called once per frame
    void Update()
    {
        if (isFullyGrown)
        {
            spoilTimer -= Time.deltaTime;
            if (spoilTimer < 0)
            {
                spoilTimer = timeToSpoil;
                Harvest();
            }
            
        }
        if (isPlanted)
        {
            growTimer -= Time.deltaTime;
            if (growTimer < 0 && plantAge < plantStages.Length - 1)
            {
                growTimer = timeBtwnStages;
                plantAge++;
                UpdatePlant();
            }
        }
    }
    
    //Harvest any of the crops that the player touches
    public void Harvest(Collider2D player = null)
    {
        isPlanted = false;
        isFullyGrown = false;
        plantSprite.gameObject.SetActive(false);

        if (player != null)
        {
            Debug.Log("Harvesting...");
            if (isFruits) // harvesting from the fruit plot
            {
                Debug.Log("Fruits!");
                //player.gameObject.GetComponent<PlayerHealth>().UpdateHealth(fruHealth); //This is for scenes with Billy(Temp)
                player.gameObject.GetComponent<SpPlayerTest>().gainHealth(fruHealth); //This is for scenes with P1 and P2
            }
            else // harvesting from the veggie plot
            {
                Debug.Log("Veggies!");
                player.gameObject.GetComponent<SpPlayerTest>().gainMoney(vegPoints);
            }

            if (player.gameObject.GetComponent<PlayerControlU>().playerStats.affectingPowerup == "fertilizer")
            {
                Debug.Log("With fertilizer!");
                timeBtwnStages = fertilizedTimeBtwnStages;
                Invoke("Plant", fertilizedReplantTime);
            }
            else if (player.gameObject.GetComponent<PlayerControlU>().playerStats.affectingPowerup == "salt")
            {
                Debug.Log("With sssalt!");
                timeBtwnStages = saltedTimeBtwnStages;
                timeToSpoil = saltedTimeToSpoil;
                Invoke("Plant", replantTime);
            }
            else
            {
                Debug.Log("With no powerups...");
                Invoke("Plant", replantTime);
            }
        }
        else //the plants were not harvested after a certain amount of time (timeToSpoil)
        {
            Debug.Log("Spoiled...");
            Invoke("Plant", replantTime);
        }
    }

    //Should automatically be called after a Harvest, or after a Non-player Harvest
    void Plant() 
    {
        //Debug.Log("Planted");
        isPlanted = true;
        plantSprite.gameObject.SetActive(true);

        plantAge = 0;
        UpdatePlant();
        growTimer = timeBtwnStages;
        spoilTimer = timeToSpoil;
    }

    //Player walking over a planted plot should harvest from it
    private void OnTriggerEnter2D(Collider2D player)
    {   
        if (player.GetComponent<PlayerControlU>() != null || player.GetComponent<PlayerTwoBehavior>() != null) //the colliding gameObject is a player and entered collider!
        {
            Debug.Log("Player walked over a plot");
            if (plantAge == plantStages.Length - 1)
            {
                Harvest(player); //harvest
            }
        }
    }


    //Updates the plant from different stages
    void UpdatePlant()
    {
        plantSprite.sprite = plantStages[plantAge];
        if (plantAge == plantStages.Length - 1)
        {
            isFullyGrown = true;
        }
    }  
}
