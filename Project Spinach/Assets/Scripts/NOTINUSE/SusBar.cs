using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//Lyndsey Narvaez
//Currently not in use
public class SusBar : MonoBehaviour
{

    public Slider slider;
    public Gradient susGradient;
    public Image susFill;

    public void SetMaxSus(float sus)
    {
        slider.maxValue = sus;
        slider.value = sus;
        susFill.color = susGradient.Evaluate(1f);
    }

    public void SetSus(float sus)
    {
        slider.value = sus;
        susFill.color = susGradient.Evaluate(slider.normalizedValue);
    }
}
