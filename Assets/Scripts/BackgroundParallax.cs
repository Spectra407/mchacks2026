using UnityEngine;

public class InfiniteParallax : MonoBehaviour
{
    [Header("Settings")] // This creates a bold title in the Inspector
    public Camera cam;
    public float parallaxEffect;
    public bool lockY = false; // This should appear now

    private float length;
    private float startPosition;
    private float startY;

    void Start()
    {
        startPosition = transform.position.x;
        startY = transform.position.y;
        length = GetComponent<SpriteRenderer>().bounds.size.x;

        // Auto-assign camera if you forgot to drag it in
        if (cam == null)
        {
            cam = Camera.main;
        }
    }

    void LateUpdate()
    {
        // 1. Calculate Distances
        float dist = (cam.transform.position.x * parallaxEffect);
        float temp = (cam.transform.position.x * (1 - parallaxEffect));

        // 2. Vertical Locking Logic
        // If lockY is ON, we use the Camera's Y. If OFF, we use the starting Y.
        float newY = lockY ? cam.transform.position.y : startY;

        // 3. Move the Background
        transform.position = new Vector3(startPosition + dist, newY, transform.position.z);

        // 4. Leapfrog Logic
        float totalWidth = length * 3;

        if (temp > startPosition + length)
        {
            startPosition += totalWidth;
        }
        else if (temp < startPosition - length)
        {
            startPosition -= totalWidth;
        }
    }
}