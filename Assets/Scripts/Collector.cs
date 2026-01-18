using System.ComponentModel;
using UnityEngine;

public class Collector : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //UnityEngine.Debug.Log("collsion. happened");
        IItem item = collision.GetComponent<IItem>();
        if(item != null)
        {
            item.Collect();
        }
    }

}
