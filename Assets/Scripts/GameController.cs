using System;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;


public class GameController : MonoBehaviour
{
    int progressAmount;
    public Slider progressSlider;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        HealthSlider.value = 0;
        HealthAmount = 0;
        Fish.OnFishCollect += IncreaseHealthAmount;
        
    }

    void IncreaseHealthAmount(int amount)
    {
        HealthAmount += amount;
        HealthSlider.value = HealthAmount;

        if (HealthAmount <= 0)
        {
            Debug.Log("You Died lol!!");
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
