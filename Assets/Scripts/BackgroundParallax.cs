using UnityEngine;

public class InfiniteParallax : MonoBehaviour
{
    public Camera cam;
    public float parallaxEffect; // 1 = Sky (Static), 0.5 = Mountains, 0 = Foreground

    private float length;
    private float startPosition;

    void Start()
    {
        startPosition = transform.position.x;
        // Get the width of the sprite
        length = GetComponent<SpriteRenderer>().bounds.size.x;
    }

    // Changed to LateUpdate to prevent "Jitter" as the camera moves
    void LateUpdate()
    {
        // 1. Distance the camera has moved relative to the map
        float dist = (cam.transform.position.x * parallaxEffect);

        // 2. Distance "remaining" before we need to loop
        float temp = (cam.transform.position.x * (1 - parallaxEffect));

        // 3. Move the background
        transform.position = new Vector3(startPosition + dist, transform.position.y, transform.position.z);

        // 4. THE OPTIMIZATION: The "Leapfrog" Logic
        // Instead of shifting by 'length' (which stacks them), we shift by 'length * 3'
        // This jumps THIS panel over the other two to the front of the line.
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