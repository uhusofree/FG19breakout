using UnityEngine;
using UnityEngine.Assertions;

[RequireComponent(typeof(Rigidbody2D))]
public class Ball : MonoBehaviour
{
    public float speed = 1F;

    private Rigidbody2D body;


    private void Awake()
    {
        body = GetComponent<Rigidbody2D>();
        Assert.IsNotNull(body, "Failed to fgind rigidbody 2d compnent.");
    }

    private void FixedUpdate()
    {
        Vector3 velocity = body.velocity.normalized;
        velocity *= speed;
        body.velocity = velocity;
    }
}
