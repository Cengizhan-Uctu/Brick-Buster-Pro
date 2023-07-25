using UnityEditor;
using UnityEngine;

public class ObjectPlacement : Editor
{

    private static GameObject parentObject; 
    private static float gridCellSize = 0.6f; 
    private static float gridGap = 0.2f; 

    [MenuItem("Custom/Set Parent Object")]
    private static void SetParentObject()
    {
        parentObject = Selection.activeGameObject;
        Debug.Log("Parent Object set to: " + parentObject.name);
    }

    [MenuItem("Custom/Enable Scene Click Placement")]
    private static void EnableSceneClickPlacement()
    {
        SceneView.onSceneGUIDelegate += OnSceneClick;
        Debug.Log("Scene click placement enabled. Click on the Scene view to instantiate the object.");
    }

    [MenuItem("Custom/Disable Scene Click Placement")]
    private static void DisableSceneClickPlacement()
    {
        SceneView.onSceneGUIDelegate -= OnSceneClick;
        Debug.Log("Scene click placement disabled.");
    }

    private static void OnSceneClick(SceneView sceneView)
    {
        if (Event.current.type == EventType.MouseDown && Event.current.button == 0)
        {
            GameObject prefab = Resources.Load<GameObject>("block");

            if (prefab != null)
            {
                Ray ray = HandleUtility.GUIPointToWorldRay(Event.current.mousePosition);
                float zPlane = 0f;
                Vector3 mousePosition = ray.GetPoint((ray.origin.z - zPlane) / ray.direction.z);

                // Snap to grid
                float snappedX = Mathf.Round((mousePosition.x - gridGap) / gridCellSize) * gridCellSize + gridGap;
                float snappedY = Mathf.Round((mousePosition.y - gridGap) / gridCellSize) * gridCellSize + gridGap;
                mousePosition = new Vector3(snappedX, snappedY, 0f);

                GameObject newObject = Instantiate(prefab, mousePosition, Quaternion.identity);

                if (parentObject != null)
                {
                    newObject.transform.SetParent(parentObject.transform);
                }

                newObject.name = "NewObject";
                Selection.activeObject = newObject;

                Event.current.Use();
            }
            else
            {
                Debug.LogError("YourPrefabName prefab not found. Make sure the prefab is in the 'Resources' folder.");
            }
        }
    }
}
