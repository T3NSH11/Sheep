using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class SelectAllOfTag : ScriptableWizard
{
    public string searchTag = "Write the tag here";

    [MenuItem("Mazen's Tools / Search all of Tag")]
    static void SelectAllOfTagWizard()
    {
        ScriptableWizard.DisplayWizard<SelectAllOfTag>("Select all of tag..", "Make Selection");
    }

    void OnWizardCreate()
    {
        GameObject[] gameObjects = GameObject.FindGameObjectsWithTag(searchTag);
        Selection.objects = gameObjects;
    }
    void OnWizardUpdate()
    {
        helpString = "Objects must be active for this to work!";
    }
}

