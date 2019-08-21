using UnityEngine;
using UnityEngine.Assertions;
using System.Collections.Generic;

[RequireComponent(typeof(CircleCollider2D))]
public class Star : MonoBehaviour
{
    [SerializeField] private Sprite normalMouth = null;
    [SerializeField] private Sprite worriedMouth = null;

    public LayerMask reactToLayer;

    private CircleCollider2D awareness;
    private SpriteRenderer mouth;
    private LookAtTarget leftEye;
    private LookAtTarget rightEye;

    private List<GameObject> activeScaryObjects = new List<GameObject>();

    private void Awake()
    {
        awareness = GetComponent<CircleCollider2D>();

        Transform go = transform.Find("LeftEye/Pupil");
        Assert.IsNotNull(go, "failed to locate/Lefteye/Pupil\".");
        leftEye = go.GetComponent<LookAtTarget>();
        Assert.IsNotNull(leftEye, "Failed to locate look at mouse component");

        go = transform.Find("RightEye/Pupil");
        Assert.IsNotNull(go, "Failed to locate child\"LeftEye/Pupil\".");
        rightEye = go.GetComponent<LookAtTarget>();
        Assert.IsNotNull(rightEye, "Failed to locate look at mouse component");

        go = transform.Find("Mouth");
        Assert.IsNotNull(go, "Failed to locate child\"Mouth\".");
        mouth = go.GetComponent<SpriteRenderer>();
        Assert.IsNotNull(mouth, "Failed to locate SpriteRender on component on mouth");




    }
    private void Start()
    {
        GameMode.instance.OnStarsadded();
    }

    private void OnDestroy()
    {
        GameMode.instance.OnStarsremoved();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        activeScaryObjects.Add(collision.gameObject);
        UpdateTarget();
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        activeScaryObjects.Remove(collision.gameObject);
        UpdateTarget();
    }

    private void UpdateTarget()
    {
        if (activeScaryObjects.Count > 0)
        {
            Transform target = transform.GetClosestObject(ref activeScaryObjects);
            SetWorried(target);
        }

        else
        {
            SetCool();
        }
    }

    public void SetWorried(Transform target)
    {
        mouth.sprite = worriedMouth;
        leftEye.target = target;
        rightEye.target = target;

        
    }

    public void SetCool()
    {
        mouth.sprite = normalMouth;
        leftEye.target = null;
        rightEye.target = null;
        leftEye.transform.localPosition = Vector2.zero;
        rightEye.transform.localPosition = Vector2.zero;

    }


}
