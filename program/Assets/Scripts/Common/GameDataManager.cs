
using System.Collections.Generic;
using UnityEngine;

public class GameDataManager : ScriptableObject
{
    [System.Serializable]
    public class SaveData
    {
        public List<CharacterData> characterList = new List<CharacterData>();
    }
    
    public List<CharacterData> characterDataList = new List<CharacterData>();
    public List<SkillData> skillDataList = new List<SkillData>();
    
    #region SavedData
    private const string SAVE_DATA_KEY = @"GameDataManager.SavedData";

    [System.NonSerialized]
    public SaveData saveData = new SaveData();
    
    public int CurrentStage
    {
        get { return PlayerPrefs.GetInt("GameDataManager.CurrentStage", 1); }
        set { PlayerPrefs.SetInt("GameDataManager.CurrentStage", value);}
    }
    
    #endregion
    
    private static GameDataManager instance = null;
    public static GameDataManager Instance
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
    
#if UNITY_EDITOR
    [UnityEditor.MenuItem("SilentTower/Remove PlayerPrefs All Data")]
    public static void RemoveAllPlayerPrefs()
    {
        PlayerPrefs.DeleteAll();
    }
    
    [UnityEditor.MenuItem("Scriptable/GameDataManager/Create")]
    public static void Create()
    {
        var instance = ScriptableObject.CreateInstance<GameDataManager>();
        UnityEditor.AssetDatabase.CreateAsset(instance, "Assets/Resources/Scriptable/GameDataManager.asset");
        UnityEditor.AssetDatabase.SaveAssets();
        UnityEditor.AssetDatabase.Refresh();
    }
#endif

    public static GameDataManager Load()
    {
        return Resources.Load<GameDataManager>("Scriptable/GameDataManager");
    }

    public void Initialize()
    {
        string data = PlayerPrefs.GetString(SAVE_DATA_KEY, string.Empty);
        
        var deserialized = JsonUtility.FromJson<SaveData>(data);
        if ( deserialized != null)
        {
            saveData = deserialized;
        }
    }

    public void Save()
    {
        string data = JsonUtility.ToJson(saveData);
        PlayerPrefs.SetString(SAVE_DATA_KEY, data);
    }

    private StartingCharacter selectedStartingCharacter = null;
    public StartingCharacter SelectedStartingCharacter
    {
        get
        {
            if (selectedStartingCharacter == null)
            {
                selectedStartingCharacter = StartingCharacter.Load();
            }
            return selectedStartingCharacter;
        }
    }

    public void GetCharacterAndSkill(int index, out CharacterData characterData, out List<SkillData> skillDataList)
    {
        characterData = GetCharacter(index);
        skillDataList = new List<SkillData>();

        var skillIndexList = characterData.skillIndexList;
        for (int i = 0; i<skillIndexList.Count; ++i)
        {
            skillDataList.Add(GetSkill(skillIndexList[i]));
        }
    }
    
    public CharacterData GetCharacter(int index)
    {
        return characterDataList.Find(item => item.index == index);
    }

    public SkillData GetSkill(int index)
    {
        return skillDataList.Find(item => item.index == index);
    }
}
