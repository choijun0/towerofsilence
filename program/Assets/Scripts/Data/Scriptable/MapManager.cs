using System.Collections.Generic;
#if UNITY_EDITOR
using UnityEditor;
#endif
using UnityEngine;
using UnityEngine.Serialization;

public class MapManager : ScriptableObject
{
    private static MapManager instance = null;
    public static MapManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = Load();
            }
            return instance;
        }
    }
    public List<MapData> mapDataList = new List<MapData>();
    
#if UNITY_EDITOR
    [MenuItem("Scriptable/MapData/Create")]
    public static void Create()
    {
        var instance = ScriptableObject.CreateInstance<MapManager>();
        AssetDatabase.CreateAsset(instance, "Assets/Resources/Scriptable/MapData.asset");
        AssetDatabase.SaveAssets();
        AssetDatabase.Refresh();
    }
#endif

    public static MapManager Load()
    {
        return Resources.Load<MapManager>("Scriptable/MapData");
    }
    
}

[System.Serializable]
public class MapData
{
    public int index;
    public int nextIndex = -1;
    public EnumMapType mapType;
    public Vector2 mapPosition;
}

public enum EnumMapType
{
    MONSTER=0,
    PARTNER=1,
    BOSS=2,
}
