using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelTransition : MonoBehaviour
{
    [Header("References")]
    public Animator canvasAnimator;          // Drag your FlagImage Animator here
    public string triggerName = "NextLevel"; // Trigger parameter in Animator

    [Header("Settings")]
    public float delayBeforeAnimation = 1f;  // Wait 1 second after collision
    public float animationLength = 3f;       // Animation length in seconds

    private bool triggered = false;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (!triggered && other.CompareTag("Player"))
        {
            triggered = true;
            Debug.Log("Player touched the flag!");
            StartCoroutine(PlayAnimationAndLoadNextLevel());
        }
    }

    private IEnumerator PlayAnimationAndLoadNextLevel()
    {
        // 1️⃣ Wait before starting the animation
        yield return new WaitForSeconds(delayBeforeAnimation);

        // 2️⃣ Trigger the animation on the Canvas
        if (canvasAnimator != null)
        {
            canvasAnimator.SetTrigger(triggerName);
        }
        else
        {
            Debug.LogWarning("Canvas Animator is not assigned!");
        }

        // 3️⃣ Wait for the animation to finish
        yield return new WaitForSeconds(animationLength);

        // 4️⃣ Load the next scene
        int nextIndex = SceneManager.GetActiveScene().buildIndex + 1;

        if (nextIndex < SceneManager.sceneCountInBuildSettings)
        {
            SceneManager.LoadScene(nextIndex);
        }
        else
        {
            Debug.LogWarning("Next scene index is out of Build Settings!");
        }
    }
}

