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
    public DamageAnimation damageAnimation;
    bool Health = true;
    public float healthDrainPerSecond = 1f;
    public float minDamageCooldown = 2f;
    public float maxDamageCooldown = 3f;
    public float nextDamageTime = 0f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        HealthSlider.value = 100f;
        HealthAmount = 100f;
        Fish.OnFishCollect += IncreaseHealthAmount;

        if (damageAnimation == null)
        {
            damageAnimation = FindFirstObjectByType<DamageAnimation>();
        }
        
    }

    void IncreaseHealthAmount(float amount)
    {
        HealthAmount = Math.Min(HealthAmount + amount, 100f);
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
            if (damageAnimation != null)
            {
                damageAnimation.DeathColor();
            }
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
    }

    public void EnemyDamage(float amount)
    {
         if (Time.time < nextDamageTime)
            {
                return;
            }

        HealthAmount -=amount;
        UnityEngine.Debug.Log("You have been hit");
        nextDamageTime = Time.time + UnityEngine.Random.Range(minDamageCooldown, maxDamageCooldown);
        if (damageAnimation != null)
        {
            StartCoroutine(damageAnimation.FlashDamage());
        }
    }

    public float NextDamageTime()
    {
        return nextDamageTime;
    }
    // Update is called once per frame

    void Update()
    {
        DecreaseHealthAmount();
    }
}
