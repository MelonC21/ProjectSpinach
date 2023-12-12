using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Melvin Cruz
//Plant scriptable object
[CreateAssetMenu(fileName = "New Plant", menuName = "Plant")]
public class PlantObjectSO : ScriptableObject
{

    public string plantName;
    public Sprite[] plantStages;
    public float timeBtwStg;
    public int buyPrice;
    public int sellPrice;
    public Sprite icon;

}
