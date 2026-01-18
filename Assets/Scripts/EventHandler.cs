using UnityEngine;

public class EventHandler : MonoBehaviour
{
    public void OnFlagAnimationComplete()
    {
        Debug.Log("Animation finished!");
        // Load next level, freeze player, fade out, etc.
    }

}
