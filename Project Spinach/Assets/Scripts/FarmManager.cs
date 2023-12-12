using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//Melvin Cruz
//Manages the the farming aspect of the game
public class FarmManager : MonoBehaviour
{
    public PlantItem selectPlant;
    public bool isPlanting = false;

    SpPlayerTest playTest;
    
    public int moneyFarm;
    
    public Color buyColor = Color.green;
    public Color cancelColor = Color.red;

    // Start is called before the first frame update
    void Start()
    {
        playTest = FindObjectOfType<SpPlayerTest>();
    }

    //Checks for plant the has been selected
    public void SelectPlant(PlantItem newPlant)
    {
        if(selectPlant == newPlant)
        {
            selectPlant.btnImage.color = buyColor;
            selectPlant.btnText.text = "Buy";
            selectPlant = null;
            isPlanting = false;
        }
        else
        {
            if(selectPlant != null)
            {
                selectPlant.btnImage.color = buyColor;
                selectPlant.btnText.text = "Buy";
            }
            selectPlant = newPlant;
            selectPlant.btnImage.color = cancelColor;
            selectPlant.btnText.text = "Cancel";
            isPlanting = true;
        }
    }

    //Decreases the value of the cash you have when you buy something from the store
    public void Transaction(int value)
    {
        playTest.gainMoney(value);
    }
}
