using System.Collections.Generic;
using UnityEngine;

public static class TransformExtensions
{
    public static Transform GetClosestObject(this Transform transform, ref List<GameObject> scaryObjects)
    {
        if(scaryObjects.Count<= 0)
        {
            return null;
        }

        Transform closestObject = null;
        float currentClosestDistance = float.MaxValue; // Mathf.Infinity
        foreach (GameObject item in scaryObjects)
        {
            Debug.Log(item.name);
            float distance = Vector2.Distance(transform.position, item.transform.position);
            if(distance < currentClosestDistance)
            {
                currentClosestDistance = distance;
                closestObject = item.transform;

            }
        }
        return closestObject;
    }
}
