using System;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using System.Diagnostics;


public class GameController : MonoBehaviour
{
    float HealthAmount;
    public Slider HealthSlider;
    bool Health = true;
    public float healthDrainPerSecond = 1f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        HealthSlider.value = 100;
        HealthAmount = 100;
        Fish.OnFishCollect += IncreaseHealthAmount;
        
    }

    void IncreaseHealthAmount(int amount)
    {
        HealthAmount = Mathf.Min(HealthAmount + amount, 100f);
        HealthSlider.value = HealthAmount;

        if (HealthAmount >= 100f)
        {
            HealthSlider.value = 100f;           
            UnityEngine.Debug.Log("Next Level");
        }
    }


    void DecreaseHealthAmount()
    {
        if (HealthAmount <= 0f && Health)
        {
            HealthAmount = 0f;
            UnityEngine.Debug.Log("You Died lol!!!");
            Health = false;
        }
        else
        {
            HealthAmount -= Time.deltaTime * healthDrainPerSecond;
            HealthSlider.value = HealthAmount;
        }
    }
    // GameController.cs
    public void Kill()
    {
        HealthAmount = 0f;
        HealthSlider.value = 0f;
        UnityEngine.Debug.Log("You Died lol!!!");
        Health = false;
    }

    // Update is called once per frame
    void Update()
    {
        DecreaseHealthAmount();
    }
}
