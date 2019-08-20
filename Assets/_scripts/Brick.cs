using System.Collections.Generic;
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

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        Assert.IsNotNull(spriteRenderer, "failed to find sprite renderer component");
    }

    private void OnCollisionEnter2D(Collision2D collision)

    {
        if(causeCameraShake)
        {
            //Todo create camera shake
            GameCamera.instance.cameraShake.Shake();
        }

        if(!isBreakable)
        {
            return;
        }

        if (sprites.Count > 0)
        {
            sprites.RemoveAt(0);
            if (sprites.Count> 0)
            {
                spriteRenderer.sprite = sprites[0];
            }
            else
            {
                Destroy(this.gameObject);
            }
        }
    }
}
