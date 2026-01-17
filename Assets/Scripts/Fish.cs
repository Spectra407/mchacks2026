using UnityEngine;

public class Fish : MonoBehaviour, IItem
{
    public void Collect()
    {
        Destroy(gameObject);   
    }    // Start is called once before the first execution of Update after the MonoBehaviour is created
}
