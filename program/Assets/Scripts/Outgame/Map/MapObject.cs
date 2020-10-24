using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MapObject : MonoBehaviour
{
    public int Index { get; set; }
    [SerializeField] private TextMeshProUGUI txtStage;
    [SerializeField] private GameObject monster;
    [SerializeField] private GameObject partner;
    [SerializeField] private GameObject boss;
    [SerializeField] private GameObject mark;
    [SerializeField] private Button button;
    
    private static MapObject loadedResource = null;
    public static MapObject Load(RectTransform parent)
    {
        if (loadedResource == null)
        {
            loadedResource = Resources.Load<MapObject>("MapObject");
        }

        return Instantiate(loadedResource, parent);
    }

    public void SetData(MapData data)
    {
        txtStage.text = data.index.ToString();
        Index = data.index;
        monster.SetActive(data.mapType == EnumMapType.MONSTER);
        partner.SetActive(data.mapType == EnumMapType.PARTNER);
        boss.SetActive(data.mapType == EnumMapType.BOSS);

        bool interactable = GameDataManager.Instance.CurrentStage == Index - 1;
        mark.SetActive(interactable);
        button.interactable = interactable;
    }

    public void OnClickStage()
    {
        SceneManager.LoadScene("Ingame");
    }
}
