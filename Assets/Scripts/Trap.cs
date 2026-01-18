using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

public class Trap : MonoBehaviour
{
    public double damage = 1;

    // Trap.cs
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            GameController controller = FindFirstObjectByType<GameController>();
            if (controller != null)
            {
                controller.Kill();
            }
        }
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
