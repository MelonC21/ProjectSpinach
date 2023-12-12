using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Melvin Cruz
//Scriptable object for the fruit family
[CreateAssetMenu(fileName = "New Fruit", menuName = "Fruit")]
public class FruitSO : ScriptableObject
{
    public string fruitName;
    public float fruitHealth;
    public int fruitCost;
    public Sprite fruitIcon;
}
