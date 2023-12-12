using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//Patrick Gudikunst
public class TestingMPFarmManager : MonoBehaviour
{
    bool isPlanted = false;
    bool isFullyGrown = false;
    public SpriteRenderer plant;

    public Sprite [] plantStages; //holds all the sprites that represent the different stages
    int plantAge = 0; //keeps track of which stage the plant is at

    [SerializeField] private int vegPoints;

    [SerializeField] private int fruHealth;
        

    float timeBtwnStages = 2f;
    float timeToSpoil = 6f;
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
    
    //Allows for clicking the plot to cycle between being planted or harvested
    public void OnMouseDown()
    {
        Debug.Log("Clicked");
        if (plantAge == plantStages.Length) 
        {
            Harvest(); //harvest
        }
        else 
        {
            Plant(); //plant
        }
    }


    //Harvest any of the crops that the player touches
    void Harvest(Collider2D player = null)
    {
        isPlanted = false;
        isFullyGrown = false;
        plant.gameObject.SetActive(false);

        if (player != null)
        {
            Debug.Log("Harvesting...");
            if (isFruits) // harvesting from the fruit plot
            {
                Debug.Log("Fruits!");
                player.gameObject.GetComponent<PlayerHealth>().UpdateHealth(10f);
                //player.gameObject.GetComponent<SpPlayerTest>().gainHealth(fruHealth);
            }
            else // harvesting from the veggie plot
            {
                Debug.Log("Veggies!");
                //player.gameObject.GetComponent<SpPlayerTest>().gainMoney(vegPoints);
            }
        }
        else
        {
            Debug.Log("Spoiled");
        }

        Invoke("Plant", 2);
    }

    //TODO, should automatically be called after a Harvest, or after a Non-player Harvest
    void Plant() 
    {
        Debug.Log("Planted");
        isPlanted = true;

        plantAge = 0;
        UpdatePlant();
        growTimer = timeBtwnStages;
        spoilTimer = timeToSpoil;

        plant.gameObject.SetActive(true);
    }

    //Player walking over a planted plot should harvest from it
    private void OnTriggerEnter2D(Collider2D player)
    {   
        Debug.Log("Player1 walked over a plot");
        if (player.GetComponent<PlayerControlU>() != null)
        {
            //Player entered collider!
            if (plantAge == plantStages.Length - 1)
            {
                Harvest(player); //harvest
            }
        }
    }


    //Updates the plant from different stages
    void UpdatePlant()
    {
        plant.sprite = plantStages[plantAge];
        if (plantAge == plantStages.Length - 1)
        {
            isFullyGrown = true;
        }
    }
    
}
