using UnityEditor;
using UnityEngine;

[CreateAssetMenu(fileName = "PrefabBrush", menuName = "Brushes/PrefabBrush")]
[CustomGridBrush(false, true, false, "PrefabBrush")]
public class PrefabBrush : GridBrushBase
{
    public GameObject prefab;
    public int zPosition = 0;

    private GameObject previousBrushTarget;
    private Vector3Int previousPosition;

    public override void Paint(GridLayout gridLayout, GameObject brushTarget, Vector3Int position)
    {
        // check to see if tile is already placed here
        Transform itInCell = GetObjectInCell(gridLayout, brushTarget.transform, new Vector3Int(position.x, position.y, position.z));
        if(itInCell)
        { return; }
        if (position == previousPosition)
        { return; }

            previousPosition = position;
        if(brushTarget)
        { previousBrushTarget = brushTarget; }
        brushTarget = previousBrushTarget;

        // do not allow pallettes

        if(brushTarget.layer == 31)
        { return; }

        GameObject instance = (GameObject)PrefabUtility.InstantiatePrefab(prefab);
        // (gameobject) is the same "as gameobject

        if (instance)
        {
            Undo.MoveGameObjectToScene(instance, brushTarget.scene, "Paint PreFab");
            Undo.RegisterCreatedObjectUndo(instance, "Paint prefab");

            instance.transform.SetParent(brushTarget.transform);
            instance.transform.position = gridLayout.LocalToWorld(gridLayout.CellToLocalInterpolated(new Vector3(position.x, position.y, position.z) + (Vector3.one * 0.5f)));
        }
    }

    public override void Erase(GridLayout gridLayout, GameObject brushTarget, Vector3Int position)
    {
        if(brushTarget)
        {
            previousBrushTarget = brushTarget;
        }
        brushTarget = previousBrushTarget;

        if (brushTarget.layer == 31)
        {
            return;
        }
        Transform erased = GetObjectInCell(gridLayout, brushTarget.transform, new Vector3Int(position.x, position.y, position.z));
            if (erased)
        {
            Undo.DestroyObjectImmediate(erased.gameObject);
        }
    }
    private static Transform GetObjectInCell(GridLayout gridLayout, Transform parent, Vector3Int position)
    {
        int childCount = parent.childCount;
        Vector3 min = gridLayout.LocalToWorld(gridLayout.CellToLocalInterpolated(position));
        Vector3 max = gridLayout.LocalToWorld(gridLayout.CellToLocalInterpolated(position + Vector3Int.one));
        Bounds bounds = new Bounds((max + min)* 0.5f, max + min); // bounds of a tile

        //checks childs object position against bounds of a tile
        for (int i = 0; i < childCount; i++)
        {
            Transform child = parent.GetChild(i);
            if (bounds.Contains(child.position))
            {
                return child;
            }

            
        }

        return null;
    }
}
