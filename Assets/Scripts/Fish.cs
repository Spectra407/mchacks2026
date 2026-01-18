using UnityEngine;
using System;

public class Fish : MonoBehaviour, IItem
{
    public static event Action<float> OnFishCollect;
    public float worth = 5;
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
    }    
}
