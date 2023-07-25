using UnityEditor;
using UnityEngine;

public class SceneClickHandler : EditorWindow
{
    private static GameObject parentObject; // Nesnelerin eklenece�i �st GameObject
    private static float gridCellSize = 0.5f; // Izgara h�cre boyutu
    private static float gridGap = 0.1f; // Izgara bo�lu�u
    private GameObject[] prefabs; // Prefablar dizisi
    private int selectedPrefabIndex = 0; // Se�ili prefab�n indeksi

    [MenuItem("Custom/Open Scene Click Placement Window")]
    private static void OpenWindow()
    {
        SceneClickHandler window = GetWindow<SceneClickHandler>("Scene Click Placement");
        window.minSize = new Vector2(250, 150);
        window.LoadPrefabs();
    }

    private void LoadPrefabs()
    {
        // Prefablar� "Resources/Prefabs" klas�r�nden y�kle
        prefabs = Resources.LoadAll<GameObject>("Prefabs");
    }

    private void OnGUI()
    {
        EditorGUILayout.Space(10);
        EditorGUILayout.LabelField("Select a Prefab:");

        // Prefablar� se�mek i�in bir Popup olu�turun
        selectedPrefabIndex = EditorGUILayout.Popup(selectedPrefabIndex, GetPrefabNames());

        EditorGUILayout.Space(10);
        EditorGUILayout.LabelField("Set Parent Object:");

        // Nesnelerin eklenece�i �st GameObject i�in bir ObjectField olu�turun
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

                    // Snap to grid
                    float snappedX = Mathf.Floor((mousePosition.x - gridGap) / gridCellSize) * gridCellSize + gridGap;
                    float snappedY = Mathf.Floor((mousePosition.y - gridGap) / gridCellSize) * gridCellSize + gridGap;
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
                    Debug.LogError("Selected prefab is null. Make sure the prefab is assigned correctly.");
                }
            }
        }
    }

    private string[] GetPrefabNames()
    {
        if (prefabs == null)
        {
            // Burada "Resources/Prefabs" klas�r�nde bulunan t�m prefablar� y�kl�yoruz.
            // Dizinini iste�inize g�re d�zenleyebilirsiniz.
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
