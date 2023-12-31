using UnityEngine;

//Melvin Cruz
//Manages the plots used in the game
public class PlotManager : MonoBehaviour
{
    bool isPlanted = false;
    SpriteRenderer plant;
    BoxCollider2D plantCollider;


    int plantStage = 0;
    float timer;

    public Color availableColor = Color.green;
    public Color unavailableColor = Color.red;

    SpriteRenderer plot;

    PlantObjectSO selectedPlant;

    FarmManager fm;
    
    //Sets up the plot and plant
    // Start is called before the first frame update
    void Start()
    {
        plant = transform.GetChild(0).GetComponent<SpriteRenderer>();
        plantCollider = transform.GetChild(0).GetComponent<BoxCollider2D>();
        fm = transform.parent.GetComponent<FarmManager>();
        plot = GetComponent<SpriteRenderer>();
    }

    //Updates the plant to grow over intervals of time
    // Update is called once per frame
    void Update()
    {
        if (isPlanted)
        {
            timer -= Time.deltaTime;
            if (timer < 0 && plantStage < selectedPlant.plantStages.Length - 1)
            {
                timer = selectedPlant.timeBtwStg;
                plantStage++;
                UpdatePlant();
            }
        }
    }

    //When clicked on a proper tile the plant will grow or be harvested
    private void OnMouseDown()
    {
        if (isPlanted)
        {
            if (plantStage == selectedPlant.plantStages.Length - 1 && !fm.isPlanting)
            {
                Harvest();
            }
        }
        else if(fm.isPlanting && fm.selectPlant.plant.buyPrice <= fm.moneyFarm)
        {
            Plant(fm.selectPlant.plant);
        }
    }

    //While hovering the tile will show if a plant can be placed or ready to harvest
    private void OnMouseOver()
    {
        if(fm.isPlanting)
        {
            if(isPlanted || fm.selectPlant.plant.buyPrice > fm.moneyFarm)
            {
                plot.color = unavailableColor;
            }
            else
            {
                plot.color = availableColor;
            }
        }
    }

    //When you exit the plot the color will turn white meaning that it's not selected anymore
    private void OnMouseExit()
    {
        plot.color = Color.white;
    }

    //Harvest the plant and sells the plant immediately
    void Harvest()
    {
        isPlanted = false;
        plant.gameObject.SetActive(false);
        fm.Transaction(selectedPlant.sellPrice);
    }

    //plants the selected plant in the soil and deducts the cost of the plant
    void Plant(PlantObjectSO newPlant)
    {
        selectedPlant = newPlant;
        isPlanted = true;
        fm.Transaction(-selectedPlant.buyPrice);
        plantStage = 0;
        UpdatePlant();
        timer = selectedPlant.timeBtwStg;
        plant.gameObject.SetActive(true);
    }

    void UpdatePlant()
    {
        plant.sprite = selectedPlant.plantStages[plantStage];
        plantCollider.size = plant.sprite.bounds.size - plant.sprite.bounds.size;
        plantCollider.offset = new Vector2(0, plant.bounds.size.y);
    }
}
