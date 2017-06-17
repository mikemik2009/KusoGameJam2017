using UnityEditor;
using UnityEngine;
using UnityEngine.UI;
using UnityEditor.SceneManagement;
//using System.Collections;

public class ZDGUIContextMenu : EditorWindow
{
    [MenuItem("GameObject/--> Select Current Scene", false, -1050)]
    static void SelectCurrentScene()
    {
        string myScene = EditorSceneManager.GetActiveScene().path;

        if (myScene == "")
        {
            Debug.LogFormat("<b>" + "Your scene is not saved yet!" + "</b>");
        }
        else
        {
            Debug.LogFormat("<b><color=Blue>" + myScene + "</color></b>");
            EditorGUIUtility.PingObject(AssetDatabase.LoadMainAssetAtPath(myScene));
        }

    }


    /*[MenuItem("GameObject/~ Diff Prefab ~", false, -1000)]
    public static void DiffPrefab()
    {

        var propertyMods = PrefabUtility.GetPropertyModifications(Selection.activeGameObject);
        if (propertyMods != null)
        {
            var window = EditorWindow.GetWindow<ToolsPrefabDiff>(true, "Diff Prefab", true);

            window.Values = propertyMods;
            window.parentSelected = Selection.activeGameObject;
            window.ShowPopup();
        }
        else
        {
            EditorUtility.DisplayDialog("Diff Prefab Warning!", "Game Object is not a prefab!", "OK");
        }

    }*/




    [MenuItem("GameObject/Reset Transform 0,0,0 Scale 1,1,1", false, -1000)]
    public static void ResetTransform()
    {
        Selection.activeTransform.localPosition = new Vector3(-100, -100, 10);
        Selection.activeTransform.localScale = new Vector3(1, 1, 1);
        Selection.activeTransform.localPosition = new Vector3(0, 0, 0);
    }

    [MenuItem("Assets/", false, 1000)]
    static void Seperator1()
    {

    }
    
    [MenuItem("Assets/---> Scene", false, 10000)]
    static void UIScene()
    {
        Selection.activeObject = AssetDatabase.LoadMainAssetAtPath("Assets/UI_PiLiQ/Scenes/root.tif");
        //EditorGUIUtility.PingObject(Selection.activeObject);
    }

    [MenuItem("Assets/---> Scene (HUD)", false, 10001)]
    static void UISceneCombat()
    {
        Selection.activeObject = AssetDatabase.LoadMainAssetAtPath("Assets/UI_PiLiQ/Scenes/HUD/root.tif");
        //EditorGUIUtility.PingObject(Selection.activeObject);
    }

    [MenuItem("Assets/---> Scene (Dialog)", false, 10001)]
    static void UISceneDialog()
    {
        Selection.activeObject = AssetDatabase.LoadMainAssetAtPath("Assets/UI_PiLiQ/Scenes/Dialog/root.tif");
        //EditorGUIUtility.PingObject(Selection.activeObject);
    }

    [MenuItem("Assets/---> Scene (SystemMessage)", false, 10001)]
    static void UISceneSystemMessage()
    {
        Selection.activeObject = AssetDatabase.LoadMainAssetAtPath("Assets/UI_PiLiQ/Scenes/SystemMessage/root.tif");
        //EditorGUIUtility.PingObject(Selection.activeObject);
    }

    [MenuItem("Assets/---> Textures", false, 10002)]
    static void UITextures()
    {
        Selection.activeObject = AssetDatabase.LoadMainAssetAtPath("Assets/UI_PiLiQ/Textures/root.tif");
    }

    [MenuItem("Assets/---> Widgets", false, 10004)]
    static void UIWidgets()
    {
        Selection.activeObject = AssetDatabase.LoadMainAssetAtPath("Assets/UI_PiLiQ/Widgets/root.tif");
    }

    [MenuItem("Assets/---> Scripts", false, 10005)]
    static void UIScripts()
    {
        Selection.activeObject = AssetDatabase.LoadMainAssetAtPath("Assets/UI_PiLiQ/Scripts/root.tif");
    }

    [MenuItem("Assets/---> Sound", false, 10006)]
    static void UISound()
    {
        Selection.activeObject = AssetDatabase.LoadMainAssetAtPath("Assets/UI_PiLiQ/Sound/root.tif");
    }

    [MenuItem("Assets/---> Icons", false, 10007)]
    static void Icons()
    {
        Selection.activeObject = AssetDatabase.LoadMainAssetAtPath("Assets/UI_PiLiQ/Icons/aaa_DefaultTest.tif");
    }

    [MenuItem("Assets/---> GameIcon", false, 10008)]
    static void GameIconFolder()
    {
        Selection.activeObject = AssetDatabase.LoadMainAssetAtPath("Assets/UI_PiLiQ/Widgets/GameIcon/GameIcon.unity");
    }

    [MenuItem("Assets/---> Tabs", false, 10008)]
    static void TabFolder()
    {
        Selection.activeObject = AssetDatabase.LoadMainAssetAtPath("Assets/UI_PiLiQ/Widgets/Tabs/Tabs.unity");
    }

    [MenuItem("Assets/---> UI (BUDDHA UI SCENES)", false, 10008)]
    static void BuddhaUIScenesFolder()
    {
        Selection.activeObject = AssetDatabase.LoadMainAssetAtPath("Assets/UI/Scenes/root.tif");
    }

    [MenuItem("Assets/---> Localizer_Text.cs, Find Asset Reference. Heirarchy View, Root, Search", false, 10008)]
    static void Localizer_Text()
    {
        Selection.activeObject = AssetDatabase.LoadMainAssetAtPath("Assets/scripts/GUI/Common/UI/Localization/Localizer_Text.cs");
    }

    //LocalizerEditor
    [MenuItem("GameObject/ZDGUI/EditorOnly/LocalizerEditor", false, -100)]
    static void LocalizerEditor()
    {
        Object uiWidget = AssetDatabase.LoadAssetAtPath("Assets/UI_PiLiQ/Widgets/LocalizerEditor.prefab", typeof(GameObject));
        CreateInRootNoBreak(uiWidget);
    }

    //Comments
    [MenuItem("GameObject/ZDGUI/EditorOnly/Comments", false, -100)]
    static void Comments()
    {
        Object uiWidget = AssetDatabase.LoadAssetAtPath("Assets/UI_PiLiQ/Widgets/Comments/COMMENTS.prefab", typeof(GameObject));
        CreateInRootNoBreak(uiWidget);
    }

    [MenuItem("GameObject/ZDGUI/EditorOnly/ChineseText ---PiLiQ", false, 1)]
    static void ChineseText()
    {
        Object uiWidget = AssetDatabase.LoadAssetAtPath("Assets/UI_PiLiQ/Widgets/HongKongRoastGoose.prefab", typeof(GameObject));
        CreateAsChild(uiWidget);
    }

    [MenuItem("GameObject/ZDGUI/EditorOnly/3DCube", false, 1)]
    static void EDITORONLY3DTEST()
    {
        Object uiWidget = AssetDatabase.LoadAssetAtPath("Assets/UI_PiLiQ/Widgets/EditorOnly3DCube/EDITOR_ONLY_3D_CUBE.prefab", typeof(GameObject));
        CreateAsChild(uiWidget);
    }

    [MenuItem("GameObject/ZDGUI/EditorOnly/TestButton", false, 2)]
    static void TestButton()
    {
        Object uiWidget = AssetDatabase.LoadAssetAtPath("Assets/UI_PiLiQ/Widgets/TestButton/TestButton.prefab", typeof(GameObject));
        CreateAsChild(uiWidget);
    }

    //####################################################################
    //MISC

    //FPS Counter
    [MenuItem("GameObject/ZDGUI/Misc/FPS", false, -101)]
    static void FPS()
    {
        Object uiWidget = AssetDatabase.LoadAssetAtPath("Assets/UI_PiLiQ/Widgets/FPS/Canvas_ssOverlay_FPS.prefab", typeof(GameObject));
        CreateInRootNoBreak(uiWidget);
    }

    //CoolDown
    [MenuItem("GameObject/ZDGUI/Misc/CoolDown", false, -100)]
    static void CoolDown()
    {
        Object uiWidget = AssetDatabase.LoadAssetAtPath("Assets/UI_PiLiQ/Widgets/CoolDown/CoolDown.prefab", typeof(GameObject));
        CreateAsChildNoBreak(uiWidget);
    }

    //GAMEICON
    [MenuItem("GameObject/ZDGUI/Misc/GameIcon", false, -99)]
    static void GameIcon_BackPack()
    {
        Object uiWidget = AssetDatabase.LoadAssetAtPath("Assets/UI_PiLiQ/Widgets/GameIcon/GameIcon_BagPack/P_GameIcon_BagPack/GameIcon_BagPack.prefab", typeof(GameObject));
        CreateAsChildNoBreak(uiWidget);
    }

    [MenuItem("GameObject/ZDGUI/Misc/Slot", false, -99)]
    static void Slot()
    {
        Object uiWidget = AssetDatabase.LoadAssetAtPath("Assets/UI_PiLiQ/Widgets/GameIcon/Slot.prefab", typeof(GameObject));
        CreateAsChild(uiWidget);
    }

    [MenuItem("GameObject/ZDGUI/Misc/Image_Line", false, -98)]
    static void ImageLine()
    {
        Object uiWidget = AssetDatabase.LoadAssetAtPath("Assets/UI_PiLiQ/Widgets/Image_Line.prefab", typeof(GameObject));
        CreateAsChild(uiWidget);
    }

    [MenuItem("GameObject/ZDGUI/Misc/CurrencyL", false, -97)]
    static void CurrencyL()
    {
        Object uiWidget = AssetDatabase.LoadAssetAtPath("Assets/UI_PiLiQ/Widgets/Currency/CurrencyL.prefab", typeof(GameObject));
        CreateAsChild(uiWidget);
    }

    [MenuItem("GameObject/ZDGUI/Misc/CurrencyR", false, -97)]
    static void CurrencyR()
    {
        Object uiWidget = AssetDatabase.LoadAssetAtPath("Assets/UI_PiLiQ/Widgets/Currency/CurrencyR.prefab", typeof(GameObject));
        CreateAsChild(uiWidget);
    }
    [MenuItem("GameObject/ZDGUI/Misc/MyCurrencyL", false, -97)]
    static void MyCurrencyL()
    {
        Object uiWidget = AssetDatabase.LoadAssetAtPath("Assets/UI_PiLiQ/Widgets/Currency/MyCurrencyL.prefab", typeof(GameObject));
        CreateAsChild(uiWidget);
    }

    [MenuItem("GameObject/ZDGUI/Misc/SpinGameIcon", false, -96)]
    static void SpinGameIcon()
    {
        Object uiWidget = AssetDatabase.LoadAssetAtPath("Assets/UI/Widgets/SpinGameIcon/SpinGameIcon.prefab", typeof(GameObject));
        CreateAsChildNoBreak(uiWidget);
    }

    [MenuItem("GameObject/ZDGUI/Misc/Avatar3D_SP", false, -95)]
    static void Avatar3D_SP()
    {
        Object uiWidget = AssetDatabase.LoadAssetAtPath("Assets/Models_piliq/Characters/prefabs/Prefab_pc_sp_for_sound.prefab", typeof(GameObject));
        CreateAsChildNoBreak(uiWidget);

    }

    [MenuItem("GameObject/ZDGUI/Misc/Avatar3D_SW", false, -95)]
    static void Avatar3D_SW()
    {
        Object uiWidget = AssetDatabase.LoadAssetAtPath("Assets/Models_piliq/Characters/prefabs/Prefab_pc_sw_for_sound.prefab", typeof(GameObject));
        CreateAsChildNoBreak(uiWidget);

    }

    [MenuItem("GameObject/ZDGUI/Misc/Avatar3D_HA", false, -95)]
    static void Avatar3D_HA()
    {
        Object uiWidget = AssetDatabase.LoadAssetAtPath("Assets/Models_piliq/Characters/prefabs/Prefab_pc_ha_for_sound.prefab", typeof(GameObject));
        CreateAsChildNoBreak(uiWidget);

    }

    [MenuItem("GameObject/ZDGUI/Misc/Avatar3D_KN", false, -95)]
    static void Avatar3D_KN()
    {
        Object uiWidget = AssetDatabase.LoadAssetAtPath("Assets/Models_piliq/Characters/prefabs/Prefab_pc_kn_for_sound.prefab", typeof(GameObject));
        CreateAsChildNoBreak(uiWidget);

    }
   
    //####################################################################

    //TEXT
    [MenuItem("GameObject/ZDGUI/Text/Text (20, Default)", false, 51)]
    static void Text20()
    {
        Object uiWidget = AssetDatabase.LoadAssetAtPath("Assets/UI_PiLiQ/Widgets/Text/Text_20.prefab", typeof(GameObject));
        CreateAsChild(uiWidget);
    }

    [MenuItem("GameObject/ZDGUI/Text/Text (26, For Buttons)", false, 52)]
    static void Text26()
    {
        Object uiWidget = AssetDatabase.LoadAssetAtPath("Assets/UI_PiLiQ/Widgets/Text/Text_26.prefab", typeof(GameObject));
        CreateAsChild(uiWidget);
    }

    [MenuItem("GameObject/ZDGUI/Text/Text_VIPLevel", false, 53)]
    static void VIPLevel()
    {
        Object uiWidget = AssetDatabase.LoadAssetAtPath("Assets/UI_PiLiQ/Widgets/Text/Text_VIPLevel.prefab", typeof(GameObject));
        CreateAsChild(uiWidget);
    }

    [MenuItem("GameObject/ZDGUI/Text/PlayerLevel", false, 53)]
    static void PlayerLevel()
    {
        Object uiWidget = AssetDatabase.LoadAssetAtPath("Assets/UI_PiLiQ/Widgets/Text/PlayerLevel.prefab", typeof(GameObject));
        CreateAsChild(uiWidget);
    }

    [MenuItem("GameObject/ZDGUI/Text/Text_CharacterName", false, 53)]
    static void CharacterName()
    {
        Object uiWidget = AssetDatabase.LoadAssetAtPath("Assets/UI_PiLiQ/Widgets/Text/Text_CharacterName.prefab", typeof(GameObject));
        CreateAsChild(uiWidget);
    }

    [MenuItem("GameObject/ZDGUI/Text/Text_FactionName", false, 53)]
    static void FactionName()
    {
        Object uiWidget = AssetDatabase.LoadAssetAtPath("Assets/UI_PiLiQ/Widgets/Text/Text_FactionName.prefab", typeof(GameObject));
        CreateAsChild(uiWidget);
    }

    [MenuItem("GameObject/ZDGUI/Text/Text_GuildName", false, 53)]
    static void GuildName()
    {
        Object uiWidget = AssetDatabase.LoadAssetAtPath("Assets/UI_PiLiQ/Widgets/Text/Text_GuildName.prefab", typeof(GameObject));
        CreateAsChild(uiWidget);
    }

    [MenuItem("GameObject/ZDGUI/Text/CharPower", false, 53)]
    static void CharPower()
    {
        Object uiWidget = AssetDatabase.LoadAssetAtPath("Assets/UI_PiLiQ/Widgets/Text/CharPower.prefab", typeof(GameObject));
        CreateAsChild(uiWidget);
    }

    [MenuItem("GameObject/ZDGUI/Text/HeaderTitle", false, 52)]
    static void HeaderTitle()
    {
        Object uiWidget = AssetDatabase.LoadAssetAtPath("Assets/UI_PiLiQ/Widgets/HeaderTitle/HeaderTitle.prefab", typeof(GameObject));
        CreateAsChildNoBreak(uiWidget);
    }

    [MenuItem("GameObject/ZDGUI/Text/HeaderTitleB", false, 52)]
    static void HeaderTitleB()
    {
        Object uiWidget = AssetDatabase.LoadAssetAtPath("Assets/UI_PiLiQ/Widgets/HeaderTitleB/HeaderTitleB.prefab", typeof(GameObject));
        CreateAsChildNoBreak(uiWidget);
    }

    [MenuItem("GameObject/ZDGUI/Text/ItemName", false, 52)]
    static void ItemName()
    {
        Object uiWidget = AssetDatabase.LoadAssetAtPath("Assets/UI_PiLiQ/Widgets/ItemName/ItemName.prefab", typeof(GameObject));
        CreateAsChildNoBreak(uiWidget);
    }

    //####################################################################

    //BUTTONS
    [MenuItem("GameObject/ZDGUI/Buttons/ButtonA (Brush Button)", false, 101)]
    static void ButtonA()
    {
        Object uiWidget = AssetDatabase.LoadAssetAtPath("Assets/UI_PiLiQ/Widgets/Button/ButtonA.prefab", typeof(GameObject));
        CreateAsChildNoBreak(uiWidget);
    }

    [MenuItem("GameObject/ZDGUI/Buttons/ButtonB (SimpleScale Press)", false, 101)]
    static void ButtonB()
    {
        Object uiWidget = AssetDatabase.LoadAssetAtPath("Assets/UI_PiLiQ/Widgets/Button/ButtonB.prefab", typeof(GameObject));
        CreateAsChildNoBreak(uiWidget);
    }

    [MenuItem("GameObject/ZDGUI/Buttons/ButtonC (Square Button)", false, 101)]
    static void ButtonC()
    {
        Object uiWidget = AssetDatabase.LoadAssetAtPath("Assets/UI_PiLiQ/Widgets/Button/ButtonC.prefab", typeof(GameObject));
        CreateAsChildNoBreak(uiWidget);
    }

    [MenuItem("GameObject/ZDGUI/Buttons/CheckBoxA", false, 102)]
    static void CheckboxA()
    {
        Object uiWidget = AssetDatabase.LoadAssetAtPath("Assets/UI_PiLiQ/Widgets/Button/CheckBoxA.prefab", typeof(GameObject));
        CreateAsChildNoBreak(uiWidget);
    }

    [MenuItem("GameObject/ZDGUI/Buttons/RadioButtonA", false, 103)]
    static void RadioButton()
    {
        Object uiWidget = AssetDatabase.LoadAssetAtPath("Assets/UI_PiLiQ/Widgets/Button/RadioButtonA.prefab", typeof(GameObject));
        CreateAsChildNoBreak(uiWidget);
    }

    [MenuItem("GameObject/ZDGUI/Buttons/CustomToggleA", false, 104)]
    static void CustomToggleA()
    {
        Object uiWidget = AssetDatabase.LoadAssetAtPath("Assets/UI_PiLiQ/Widgets/Button/CustomToggleA.prefab", typeof(GameObject));
        CreateAsChildNoBreak(uiWidget);
    }

    //####################################################################

    //TABS
    /*
    [MenuItem("GameObject/ZDGUI/Tabs/Tab_Left", false, 151)]
    static void Tab_Left()
    {
        Object uiWidget = AssetDatabase.LoadAssetAtPath("Assets/UI/Widgets/Tab/Tab_Left.prefab", typeof(GameObject));
        CreateAsChild(uiWidget);
    }

    [MenuItem("GameObject/ZDGUI/Tabs/TabTopA", false, 152)]
    static void TabTopA()
    {

        Object uiWidget = AssetDatabase.LoadAssetAtPath("Assets/UI_PiLiQ/Widgets/Tabs/TabTopA.prefab", typeof(GameObject));
        CreateAsChild(uiWidget);
        Selection.activeObject.name = "TabTopA_THIS IS A UNIQUE NAME";

        // Add TabTopButtonA as Child
        uiWidget = AssetDatabase.LoadAssetAtPath("Assets/UI_PiLiQ/Widgets/Tabs/TabTopAButton.prefab", typeof(GameObject));

        //Add 3 TabTopButtonA to TabTopA
        for (int i = 0; i < 3; ++i)
        {
            Selection.activeObject = GameObject.Find("TabTopA_THIS IS A UNIQUE NAME");
            CreateAsChildNoBreak(uiWidget);
        }

        //Rename 'TabTopA_THIS IS A UNIQUE NAME' back to TabTopA

        Selection.activeObject = GameObject.Find("TabTopA_THIS IS A UNIQUE NAME");
        Selection.activeObject.name = "TabTopA";

    }
    */
    //####################################################################

    //SPINNER
    [MenuItem("GameObject/ZDGUI/Spinner/SpinnerA", false, 201)]
    static void SpinnerA()
    {
        Object uiWidget = AssetDatabase.LoadAssetAtPath("Assets/UI_PiLiQ/Widgets/SpinnerA/SpinnerA.prefab", typeof(GameObject));
        CreateAsChildNoBreak(uiWidget);
    }


    //####################################################################

    //INPUT FIELD
    [MenuItem("GameObject/ZDGUI/InputField/InputFieldA", false, 251)]
    static void InputFieldA()
    {
        Object uiWidget = AssetDatabase.LoadAssetAtPath("Assets/UI_PiLiQ/Widgets/InputField/InputFieldA.prefab", typeof(GameObject));
        CreateAsChildNoBreak(uiWidget);
    }

    //####################################################################

    //SCROLL VIEW
    [MenuItem("GameObject/ZDGUI/Scrollview/ScrollviewA (Vertical)", false, 301)]
    static void ScrollviewA()
    {
        Object uiWidget = AssetDatabase.LoadAssetAtPath("Assets/UI_PiLiQ/Widgets/Scrollview/ScrollviewA.prefab", typeof(GameObject));
        CreateAsChild(uiWidget);
    }

    [MenuItem("GameObject/ZDGUI/Scrollview/ScrollviewB (Vertical, No Scrollbars)", false, 302)]
    static void ScrollviewB()
    {
        Object uiWidget = AssetDatabase.LoadAssetAtPath("Assets/UI_PiLiQ/Widgets/Scrollview/ScrollviewB.prefab", typeof(GameObject));
        CreateAsChild(uiWidget);
    }

    [MenuItem("GameObject/ZDGUI/Scrollview/ScrollviewC (Horizontal)", false, 303)]
    static void ScrollviewC()
    {
        Object uiWidget = AssetDatabase.LoadAssetAtPath("Assets/UI_PiLiQ/Widgets/Scrollview/ScrollviewC.prefab", typeof(GameObject));
        CreateAsChild(uiWidget);
    }

    [MenuItem("GameObject/ZDGUI/Scrollview/ScrollviewD (Carousel)", false, 304)]
    static void ScrollviewD()
    {
        Object uiWidget = AssetDatabase.LoadAssetAtPath("Assets/UI_PiLiQ/Widgets/Scrollview/ScrollviewD.prefab", typeof(GameObject));
        CreateAsChild(uiWidget);
    }

    //####################################################################

    //SLIDER
    [MenuItem("GameObject/ZDGUI/Slider/SliderA ----Buddha", false, 401)]
    static void Slider()
    {
        Object uiWidget = AssetDatabase.LoadAssetAtPath("Assets/UI/Widgets/Slider/SliderA.prefab", typeof(GameObject));
        CreateAsChild(uiWidget);
    }

    //####################################################################

    //PROGRESSBAR
    [MenuItem("GameObject/ZDGUI/ProgressBar/ProgressBarFillA (Horizontal Fill)", false, 451)]
    static void ProgressBarFillA()
    {
        Object uiWidget = AssetDatabase.LoadAssetAtPath("Assets/UI_PiLiQ/Widgets/ProgressBarFill/ProgressBarFillA.prefab", typeof(GameObject));
        CreateAsChildNoBreak(uiWidget);
    }

    //####################################################################
    /*
    [MenuItem("GameObject/UI/------------------------------------------", false, 1749)]
    [MenuItem("GameObject/UI/!!!!!!!!      CHECK RAYCAST      !!!!!!!!!!!!!!!!!!!!!!!", false, 1750)]
    [MenuItem("GameObject/UI/!!!!!!!!      CHECK FILL CENTER  !!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!", false, 1750)]
    [MenuItem("GameObject/UI/!!!!!!!!      OPTIMIZE 9-SLICE   !!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!", false, 1750)]
    [MenuItem("GameObject/UI/!!!!!!!!      CHECK WHAT YOU DUPLICATE, REMOVE THINGS THAT IS NOT NEEDED   !!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!", false, 1750)]
    [MenuItem("GameObject/UI/--------------------------------------------", false, 2020)]
    static void REMINDERS()
    {
       //Do Nothing
    }
    */
    //####################################################################

    //####################################################################
    // Create widget as a child of selection
    //####################################################################

    //------------------------------------------
    //Create as a child object
    static void CreateAsChild(Object uiWidget)
    {
        var newPrefab = PrefabUtility.InstantiatePrefab(uiWidget) as GameObject;
        newPrefab.transform.SetParent(Selection.activeTransform, false);
        PrefabUtility.DisconnectPrefabInstance(newPrefab);
        Selection.activeObject = newPrefab;

    }

    static void CreateAsChildNoBreak(Object uiWidget)
    {
        var newPrefab = PrefabUtility.InstantiatePrefab(uiWidget) as GameObject;
        newPrefab.transform.SetParent(Selection.activeTransform, false);
        //PrefabUtility.DisconnectPrefabInstance(newPrefab);
        Selection.activeObject = newPrefab;
    }

    //Create In Root
    static void CreateInRootNoBreak(Object uiWidget)
    {
        var newPrefab = PrefabUtility.InstantiatePrefab(uiWidget) as GameObject;
        //PrefabUtility.DisconnectPrefabInstance(newPrefab);
        Selection.activeObject = newPrefab;
    }


}