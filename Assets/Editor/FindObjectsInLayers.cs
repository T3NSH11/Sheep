using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class FindObjectsInLayers : EditorWindow
{
    LayerMask SelectedLayer;
    GameObject[] AllObjects;
    List<GameObject> ObjectsInLayer = new List<GameObject>();

    [MenuItem("Zaid's Tool / Find objects in layers")]
    public static void ShowWindow()
    {
        GetWindow(typeof(FindObjectsInLayers));
    }

    private void OnEnable()
    {
        AllObjects = FindObjectsOfType<GameObject>();
    }
    private void OnGUI()
    {
        GUILayout.Label("Activate/Deavtivate by layer", EditorStyles.boldLabel);

        SelectedLayer = EditorGUILayout.LayerField("Layer", SelectedLayer);

        for (int i = 0; i < AllObjects.Length; i++)
        {
            if (AllObjects[i].layer == SelectedLayer)
            {
                ObjectsInLayer.Add(AllObjects[i]);
            }

            if (AllObjects[i].layer != SelectedLayer)
            {
                ObjectsInLayer.Remove(AllObjects[i]);
            }
        }

        
        if (GUILayout.Button("DeactivateObjects"))
        {
            for (int i = 0; i < ObjectsInLayer.Count; i++)
            {
                ObjectsInLayer[i].SetActive(false);
            }
        }
        
        if (GUILayout.Button("ActivateObjects"))
        {
            for (int i = 0; i < ObjectsInLayer.Count; i++)
            {
                ObjectsInLayer[i].SetActive(true);
            }
        }

        if (GUILayout.Button("Deactivate all with exception"))
        {
            for (int i = 0; i < AllObjects.Length; i++)
            {
                AllObjects[i].SetActive(false);
            }

            for (int i = 0; i < ObjectsInLayer.Count; i++)
            {
                ObjectsInLayer[i].SetActive(true);
            }
        }

        if (GUILayout.Button("Activate all with exception"))
        {
            for (int i = 0; i < AllObjects.Length; i++)
            {
                AllObjects[i].SetActive(true);
            }

            for (int i = 0; i < ObjectsInLayer.Count; i++)
            {
                ObjectsInLayer[i].SetActive(false);
            }
        }
    }


}
