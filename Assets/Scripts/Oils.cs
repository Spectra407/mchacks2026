using System.Data.SqlTypes;
using System.Security;
using UnityEngine;
using System.Threading;
using System.Diagnostics;

public class Oils : MonoBehaviour
{
    public float damage = 1f;
    public float MoveSpeed = 1f;
    public float minDamageCooldown = 2f;
    public float maxDamageCooldown = 3f;
    public Transform PointA;
    public Transform PointB;
    private UnityEngine.Vector3 nextPosition;

    private void OnTriggerEnter2D(Collider2D collision)
    
    {
        if (collision.CompareTag("Player"))
        {
            GameController controller = FindFirstObjectByType<GameController>();
            if (controller != null)
            {
                controller.EnemyDamage(damage);

            }
        }
    }
     void Start()
    {
        nextPosition = PointB.position;

    }

    void Update()
    {
        transform.position = UnityEngine.Vector3.MoveTowards(transform.position,nextPosition,MoveSpeed * Time.deltaTime);

        if(transform.position == nextPosition)
        {
            nextPosition = (nextPosition == PointA.position) ? PointB.position : PointA.position;
        }
    }
}