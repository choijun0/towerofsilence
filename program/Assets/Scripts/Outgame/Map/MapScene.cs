using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapScene : MonoBehaviour
{
    private List<MapObject> mapObjectList = new List<MapObject>();

    [SerializeField] private RectTransform mapParent;
    
    void Awake()
    {
        int stage = GameDataManager.Instance.CurrentStage;

        for (int i = 0; i < MapManager.Instance.mapDataList.Count; ++i)
        {
            var mapData = MapManager.Instance.mapDataList[i];
            var mapObject = MapObject.Load(mapParent);
            mapObjectList.Add(mapObject);
            mapObject.SetData(mapData);
            mapObject.GetComponent<RectTransform>().anchoredPosition = mapData.mapPosition;
        }
    }

    #if UNITY_EDITOR
    [ContextMenu("Save Position")]
    private void SaveMapPosition()
    {
        for (int i = 0; i < mapObjectList.Count; ++i)
        {
            var obj = mapObjectList[i];
            var findItem = MapManager.Instance.mapDataList.Find(item => item.index == obj.Index);
            findItem.mapPosition = obj.GetComponent<RectTransform>().anchoredPosition;
        }
        
        UnityEditor.EditorUtility.SetDirty(MapManager.Instance);
    }
    #endif
}
