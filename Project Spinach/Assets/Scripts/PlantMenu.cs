using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Melvin Cruz
//controlls the plant UI 
public class PlantMenu : MonoBehaviour
{
    [SerializeField] private GameObject healthBarCanva;

    private static bool inMenu = false;

    public bool m_PlantMenuDisable;

    [SerializeField] private GameObject plantMenu;

    SpMenuScript pauseUI;

    // Start is called before the first frame update
    private void Start()
    {
        pauseUI = FindObjectOfType<SpMenuScript>();
    }

    //Press E to open the menu up
    private void Update()
    {
        if (m_PlantMenuDisable == false)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                if (inMenu == false)
                {
                    pauseUI.m_DisablePause = true;
                    plantMenu.SetActive(true);
                    healthBarCanva.SetActive(false);
                    inMenu = true;
                }
                else if (inMenu == true)
                {
                    pauseUI.m_DisablePause = false;
                    plantMenu.SetActive(false);
                    healthBarCanva.SetActive(true);
                    inMenu = false;
                }
            }
        }

        else if (m_PlantMenuDisable == true)
        {
            return;
        }
    }
}
