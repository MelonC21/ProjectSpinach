using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//Melvin Cruz
//Used for the plant family of objects
public class PlantItem : MonoBehaviour
{
    public PlantObjectSO plant;
    public Text nameTxt;
    public Text priceTxt;
    public Text sellTxt;
    public Image icon;

    public Image btnImage;
    public Text btnText;

    FarmManager fm;

    // Start is called before the first frame update
    void Start()
    {
        fm = FindObjectOfType<FarmManager>();
        InitializeUI();
        
    }

    //calls on farm manager to see what plant to buy
    public void BuyPlant()
    {
        fm.SelectPlant(this);
    }

    //sets up UI for buying the plant
    void InitializeUI()
    {
        nameTxt.text = plant.plantName;
        priceTxt.text = "Cost: $" + plant.buyPrice;
        sellTxt.text = "Sell: $" + plant.sellPrice;
        icon.sprite = plant.icon;
    }
}
