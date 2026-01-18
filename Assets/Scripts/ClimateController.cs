using UnityEngine;
using UnityEngine.Rendering.Universal; // Required for Light2D

public class ClimateController : MonoBehaviour
{
    [Header("Debug Tools")]
    // Check this to control the weather manually with the slider
    public bool useDebugSlider = true;
    [Range(0f, 1f)] public float testDoomSlider;

    [Header("Layer References")]
    public SpriteRenderer skyRenderer;       // Layer 0: The Gradient Background
    public SpriteRenderer[] cloudRenderers;  // Layer 1: The Cloud Panels
    public ParticleSystem stormSystem;       // Layer 4: The Snow/Rain
    public Light2D globalLight;              // The Global Light source

    [Header("Sky Settings")]
    public Color healthySkyColor = new Color(0.5f, 0.7f, 1f); // Light Blue
    public Color doomedSkyColor = new Color(0.05f, 0.05f, 0.1f); // Deep Navy/Black

    [Header("Storm Settings")]
    public float minStormEmission = 10f;
    public float maxStormEmission = 500f;

    // Wind Settings: Negative X means blowing Left (against the player)
    public float maxWindSpeed = -25f;

    void Update()
    {
        // Only run this if we are debugging. 
        // Otherwise, your Game Loop should call UpdateClimate() directly.
        if (useDebugSlider)
        {
            UpdateClimate(testDoomSlider);
        }
    }

    // 0.0f = Start of game (Healthy)
    // 1.0f = End of game (Doomed)
    public void UpdateClimate(float doomProgress)
    {
        // 1. Darken the Sky (Layer 0)
        if (skyRenderer != null)
        {
            skyRenderer.color = Color.Lerp(healthySkyColor, doomedSkyColor, doomProgress);
        }

        // 2. Dissolve the Clouds (Layer 1)
        if (cloudRenderers != null)
        {
            float cloudAlpha = Mathf.Lerp(1.0f, 0.0f, doomProgress);
            foreach (var cloud in cloudRenderers)
            {
                if (cloud != null)
                {
                    Color c = cloud.color;
                    c.a = cloudAlpha;
                    cloud.color = c;
                }
            }
        }

        // 3. Worsen the Storm (Layer 4) - Emission + Wind
        if (stormSystem != null)
        {
            // A. Emission (Amount of Snow)
            var emission = stormSystem.emission;
            emission.rateOverTime = Mathf.Lerp(minStormEmission, maxStormEmission, doomProgress);

            // B. Simulation Speed (How fast time moves for the snow)
            var main = stormSystem.main;
            main.simulationSpeed = Mathf.Lerp(1.0f, 3.0f, doomProgress);

            // C. Velocity Over Lifetime (Wind Force)
            var velocity = stormSystem.velocityOverLifetime;
            velocity.enabled = true; // Ensure the module is on

            // Interpolate X from 0 (Straight Down) to maxWindSpeed (Horizontal)
            velocity.x = new ParticleSystem.MinMaxCurve(Mathf.Lerp(0f, maxWindSpeed, doomProgress));
            velocity.y = new ParticleSystem.MinMaxCurve(Mathf.Lerp(0f, -5f, doomProgress)); // Add downward pressure

            // D. Noise (Turbulence/Chaos)
            var noise = stormSystem.noise;
            noise.enabled = true;
            // Strength goes from 0 (Calm) to 3 (Violent Jitter)
            noise.strength = Mathf.Lerp(0f, 3f, doomProgress);
        }

        // 4. Dim Global Light
        if (globalLight != null)
        {
            // Dim intensity from 1.0 down to 0.2
            globalLight.intensity = Mathf.Lerp(1.0f, 0.2f, doomProgress);

            // Shift tint from White to Cold Blue/Purple
            globalLight.color = Color.Lerp(Color.white, new Color(0.6f, 0.6f, 0.9f), doomProgress);
        }
    }
}