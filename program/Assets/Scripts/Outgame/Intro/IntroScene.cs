using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class IntroScene : MonoBehaviour
{
    [SerializeField] private CharacterSelectionView characterSelectionView;
    [SerializeField] private TextMeshProUGUI txtStage;
    
    
    [SerializeField] private GameObject introView;
    [SerializeField] private GameObject selectionView;
    [SerializeField] private GameObject stageView;

    [SerializeField] private Image imgProgressBar;

    private const float ORIGINAL_PROGRESSBAR_SIZE = 800F;
    
    private List<CharacterSelectionView> characterList = new List<CharacterSelectionView>();

    private void Awake()
    {
        GameManager.Instance.Initialize();
        
        introView.SetActive(true);
        selectionView.SetActive(false);
        stageView.SetActive(false);
    }
    
    public void OnClickStartButton()
    {
        introView.SetActive(false);
        selectionView.SetActive(true);
        stageView.SetActive(false);
        
        StartCoroutine(CoRoutineAtIntro());
    }

    public void OnClickResetButton()
    {
        PlayerPrefs.DeleteAll();
        
        GameDataManager.Instance.saveData = new GameDataManager.SaveData();
    }

    public void OnClickSelectCharacter(CharacterSelectionView selectionView)
    {
        var selectedCharacterIndex = GameDataManager.Instance.SelectedStartingCharacter.characterIndexList[selectionView.Index];

        GameDataManager.Instance.saveData.characterList.Add(GameDataManager.Instance.GetCharacter(selectedCharacterIndex));
        GameDataManager.Instance.Save();
    }

    private IEnumerator CoRoutineAtIntro()
    {
        yield return StartCoroutine(CoSelectCharacter());
        yield return StartCoroutine(CoMoveCharacterToCurrentStage());

        MoveToMapScene();
    }

    private IEnumerator CoSelectCharacter()
    {
        if (GameDataManager.Instance.saveData.characterList.Count > 0)
        {
            yield break;
        }
        
        characterSelectionView.gameObject.SetActive(true);
        ShowCharacters();
        
        while (GameDataManager.Instance.saveData.characterList.Count < 1)
        {
            yield return null;
        }
    }

    private void ShowCharacters()
    {
        var parent = characterSelectionView.transform.parent;
        const int ITEM_COUNT = 3;

        characterList.Add(characterSelectionView);
        for (int i = 0; i < ITEM_COUNT-1; ++i)
        {
            var instantiated = Instantiate(characterSelectionView, parent);
            characterList.Add(instantiated);
        }

        for (int i = 0; i < ITEM_COUNT; ++i)
        {
            var index = GameDataManager.Instance.SelectedStartingCharacter.characterIndexList[i];
            CharacterData characterData;
            List<SkillData> skillDataList;
            
            GameDataManager.Instance.GetCharacterAndSkill(index,out characterData,out skillDataList);
            
            var characterHandle = characterList[i];
            characterHandle.Set(i,characterData, skillDataList);
        }
    }

    private IEnumerator CoMoveCharacterToCurrentStage()
    {
        introView.SetActive(false);
        selectionView.SetActive(false);
        stageView.SetActive(true);
        
        txtStage.text = GameDataManager.Instance.CurrentStage.ToString();
        for (int i = 0; i < characterList.Count; ++i)
        {
            characterList[i].gameObject.SetActive(false);
        }

        float progress = 0;
//        var rectTransform = imgProgressBar.GetComponent<RectTransform>();
//        var sizeDelta = rectTransform.sizeDelta;
        while (progress < 1F)
        {
            progress += 0.04F;
//            sizeDelta.x = ORIGINAL_PROGRESSBAR_SIZE * progress;
//            rectTransform.sizeDelta = sizeDelta;
            yield return null;
        }
    }

    private void MoveToMapScene()
    {
        SceneManager.LoadScene("Map");
    }
}
