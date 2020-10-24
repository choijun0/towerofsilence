using System.Collections.Generic;
#if UNITY_EDITOR
using UnityEditor;
#endif
using UnityEngine;

public class StartingCharacter : ScriptableObject
{
    public List<int> characterIndexList = new List<int>();

#if UNITY_EDITOR
    [MenuItem("Scriptable/StartingCharacter/Create")]
    public static void Create()
    {
        var instance = ScriptableObject.CreateInstance<StartingCharacter>();
        AssetDatabase.CreateAsset(instance, "Assets/Resources/Scriptable/StartingCharacter.asset");
        AssetDatabase.SaveAssets();
        AssetDatabase.Refresh();
    }
#endif

    public static StartingCharacter Load()
    {
        return Resources.Load<StartingCharacter>("Scriptable/StartingCharacter");
    }
    
}


