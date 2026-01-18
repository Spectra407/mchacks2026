using UnityEngine;
using System.Collections;

public class DamageAnimation : MonoBehaviour

{
    public float DamageWaitTime = 0.3f;
    public GameController controller;
    public SpriteRenderer targetRenderer;
    Color32 redColor = new Color32(255, 0, 0, 255);
    float nextDamageTime;

    public IEnumerator FlashDamage()
    {
        if (controller == null)
        {
            controller = FindFirstObjectByType<GameController>();
        }
        if (controller == null)
        {
            yield break;
        }
        if (targetRenderer == null)
        {
            targetRenderer = GetComponentInChildren<SpriteRenderer>();
        }
        if (targetRenderer == null)
        {
            yield break;
        }
        nextDamageTime = controller.NextDamageTime();
    
        while(Time.time < nextDamageTime)
        {
            targetRenderer.enabled = true;
            yield return new WaitForSeconds(DamageWaitTime);
            targetRenderer.enabled = false;
            yield return new WaitForSeconds(DamageWaitTime);
        }
        targetRenderer.enabled = true;
    }

    public void DeathColor()
    {
        var sprite = GetComponentInChildren<SpriteRenderer>();
        if (sprite != null)
        {
            sprite.color = redColor;
            return;
        }

        var rend = GetComponentInChildren<Renderer>();
        if (rend != null)
        {
            rend.material.color = redColor;
        }
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if (controller == null)
        {
            controller = FindFirstObjectByType<GameController>();
        }
        if (targetRenderer == null)
        {
            targetRenderer = GetComponentInChildren<SpriteRenderer>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
