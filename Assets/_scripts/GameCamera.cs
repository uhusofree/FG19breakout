using UnityEngine;

public class GameCamera : MonoBehaviour
{
    static public GameCamera instance;
    [System.NonSerialized] public CameraShake cameraShake;
    private void Awake()
    {
        if (!instance)
        {
            instance = this;
            cameraShake = GetComponent<CameraShake>();
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
