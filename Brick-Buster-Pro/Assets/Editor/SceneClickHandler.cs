using UnityEditor;
using UnityEngine;

public class SceneClickHandler : EditorWindow
{
    private static GameObject parentObject; 
    private static float gridCellSize = 0.5f;
    private static float gridGap = 0.1f;
    private GameObject[] prefabs; 
    private int selectedPrefabIndex = 0; 

    [MenuItem("Custom/Open Scene Click Placement Window")]
    private static void OpenWindow()
    {
        SceneClickHandler window = GetWindow<SceneClickHandler>("Scene Click Placement");
        window.minSize = new Vector2(250, 150);
        window.LoadPrefabs();
    }

    private void LoadPrefabs()
    {
        
        prefabs = Resources.LoadAll<GameObject>("Prefabs");
    }

    private void OnGUI()
    {
        EditorGUILayout.Space(10);
        EditorGUILayout.LabelField("Select a Prefab:");

        
        selectedPrefabIndex = EditorGUILayout.Popup(selectedPrefabIndex, GetPrefabNames());

        EditorGUILayout.Space(10);
        EditorGUILayout.LabelField("Set Parent Object:");

        
        parentObject = (GameObject)EditorGUILayout.ObjectField(parentObject, typeof(GameObject), true);

        EditorGUILayout.Space(20);
        if (GUILayout.Button("Enable Scene Click Placement"))
        {
            SceneView.onSceneGUIDelegate += OnSceneClick;
            Debug.Log("Scene click placement enabled. Click on the Scene view to instantiate the object.");
        }

        if (GUILayout.Button("Disable Scene Click Placement"))
        {
            SceneView.onSceneGUIDelegate -= OnSceneClick;
            Debug.Log("Scene click placement disabled.");
        }
    }

    private void OnSceneClick(SceneView sceneView)
    {
        if (Event.current.type == EventType.MouseDown && Event.current.button == 0)
        {
            if (prefabs != null && prefabs.Length > selectedPrefabIndex)
            {
                GameObject prefab = prefabs[selectedPrefabIndex];

                if (prefab != null)
                {
                    Ray ray = HandleUtility.GUIPointToWorldRay(Event.current.mousePosition);
                    float zPlane = 0f;
                    Vector3 mousePosition = ray.GetPoint((ray.origin.z - zPlane) / ray.direction.z);

                    
                    float snappedX = Mathf.Floor((mousePosition.x - gridGap) / gridCellSize) * gridCellSize + gridGap;
                    float snappedY = Mathf.Floor((mousePosition.y - gridGap) / gridCellSize) * gridCellSize + gridGap;
                    mousePosition = new Vector3(snappedX, snappedY, 0f);

                    GameObject newObject = Instantiate(prefab, mousePosition, Quaternion.identity);

                    if (parentObject != null)
                    {
                        newObject.transform.SetParent(parentObject.transform);
                    }

                    
                    Selection.activeObject = newObject;

                    Event.current.Use();
                }
                else
                {
                    Debug.LogError("Selected prefab is null. Make sure the prefab is assigned correctly.");
                }
            }
        }
    }

    private string[] GetPrefabNames()
    {
        if (prefabs == null)
        {
         
           
            prefabs = Resources.LoadAll<GameObject>("Prefabs");
        }

        string[] names = new string[prefabs.Length];
        for (int i = 0; i < prefabs.Length; i++)
        {
            names[i] = prefabs[i].name;
        }

        return names;
    }
}
