using UnityEngine;
using UnityEditor;
using UnityEditor.SceneManagement;
using System.IO;
//using System.Collections;

public class PinUITopMenu : EditorWindow
{
    // %(Ctrl), #(Shift), &(Alt), _(None)

  

    [MenuItem("PinGUI/Toggle Activate &A", false, -98)]
    static void ToggleActivate()
    {
        if (Selection.activeGameObject.activeSelf)
        {
            Selection.activeGameObject.SetActive(false);
        }
        else
        {
            Selection.activeGameObject.SetActive(true);
        }
    }



    //####################################################################
    // Open Scene with confirmation
    //####################################################################
    //------------------------------------------
    static void OpenNewScene(string myScene)
    {
        var q = EditorSceneManager.SaveCurrentModifiedScenesIfUserWantsTo();
        if (q)
        {
            EditorSceneManager.OpenScene(myScene);
        }
    }
}
