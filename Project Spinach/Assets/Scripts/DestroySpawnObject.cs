using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//Created by Victoria
public class DestroySpawnObject : MonoBehaviour
{
    [SerializeField] private float destroyTimeTick;

    private float timerCountdown;
    // Start is called before the first frame update
    void Start()
    {
        timerCountdown = destroyTimeTick;
    }

    // Update is called once per frame
    void Update()
    {
        timerCountdown -= Time.deltaTime;
        if(timerCountdown < 0)
        {
            Destroy(gameObject);
        }
    }
}
