using UnityEngine;
[RequireComponent(typeof(SpriteRenderer))]

public class PluseColor : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;
        public Gradient gradient;
    public float speedMultiplier = 1f;


    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        spriteRenderer.color = gradient.Evaluate(Mathf.PingPong(Time.time * speedMultiplier, 1f));
    }
}
