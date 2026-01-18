using UnityEngine;
using System;

public class Fish : MonoBehaviour, IItem
{
    public static event Action<int> OnFishCollect;
    public int worth = 5;
    private bool collected;

    public void Collect()
    {
        if (collected)
        {
            return;
        }

        collected = true;
        OnFishCollect.Invoke(worth);
        Destroy(gameObject);   
    }    // Start is called once before the first execution of Update after the MonoBehaviour is created
}
