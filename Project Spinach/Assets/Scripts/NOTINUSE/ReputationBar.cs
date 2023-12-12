using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//Victoria Garcia
//Used for reputation not used yet
public class ReputationBar : MonoBehaviour
{

    public Slider repSlider;
    public Gradient repGradient;
    public Image repFill;

    //Sets the max reputation
    public void SetMaxReputation(float reputation)
    {
        repSlider.maxValue = reputation;
        repSlider.value = reputation;

        repFill.color = repGradient.Evaluate(1f);
    }

    //changes the reputation after calling the function
    public void SetReputation(float reputation)
    {
        repSlider.value = reputation;

        repFill.color = repGradient.Evaluate(repSlider.normalizedValue);
    }
}
