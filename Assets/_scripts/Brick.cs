﻿using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

[RequireComponent(typeof(SpriteRenderer))]

public class Brick : MonoBehaviour
{
    [Tooltip("Should we call camera if the ball hits the brick")]
    public bool causeCameraShake = false;
    public bool isBreakable = true;

    [Tooltip("number of sprites = number of hitys the brick can take")]
    public List<Sprite> sprites;

    private SpriteRenderer spriteRenderer;
    public static int bricksDestroyed = 0;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        Assert.IsNotNull(spriteRenderer, "failed to find sprite renderer component");
    }

    private void OnCollisionEnter2D(Collision2D collision)

    {

        if (causeCameraShake)
        {
            
            GameCamera.instance.cameraShake.Shake();
        }

        if (!isBreakable)
        {
            return;
        }

        if (sprites.Count > 0)
        {
            sprites.RemoveAt(0);
            if (sprites.Count > 0)
            {
                spriteRenderer.sprite = sprites[0];
            }
            else
            {
                bricksDestroyed++;
                if (bricksDestroyed % GameMode.instance.spawnBallForEveryBrickDestroy == 0)
                {
                    Instantiate(GameMode.instance.ballprefab, transform.position, Quaternion.identity);
                }
                Destroy(this.gameObject);
            }
        }
    }
}
