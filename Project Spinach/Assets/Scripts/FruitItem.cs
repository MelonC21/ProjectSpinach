using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//Melvin Cruz
//Used for the fruit family of objects
public class FruitItem : MonoBehaviour
{
    public FruitSO fruit;
    public Text nameTxt;
    public Text priceTxt;
    public Text healthTxt;
    public Image icon;

    public Image btnImage;
    public Text btnText;

    FarmManager fm;

    // Start is called before the first frame update
    void Start()
    {
        fm = FindObjectOfType<FarmManager>();
        FruitInitializeUI();
    }

    //Sets up the UI for the fruit int the menu
    void FruitInitializeUI()
    {
        nameTxt.text = fruit.fruitName;
        priceTxt.text = "Cost: $" + fruit.fruitCost;
        healthTxt.text = "HP+: " + fruit.fruitHealth;
        icon.sprite = fruit.fruitIcon;

    }

    //Buys fruit and deducts the cost from you money and supposed to add health
    //Addition of health is not working 
    public void BuyFruit()
    {
        fm.Transaction(-fruit.fruitCost);
        Debug.Log("bought " + fruit.fruitCost);
        SpPlayerTest.p_instance.gainHealth(fruit.fruitHealth);
        
    }
}
