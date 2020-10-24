using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class CharacterSelectionView:MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI txtJob;

    [SerializeField] private List<CharacterSkillView> skillViewList;

    [SerializeField] private GameObject[] characterArray;
    
    public int Index { get; set; }

    public void Set(int itemIndex,CharacterData characterData ,List<SkillData> skillList)
    {
        for (int i = 0; i < characterArray.Length; ++i)
        {
            characterArray[i].SetActive(i == characterData.imageIndex);
        }
        
        Index = itemIndex;
        txtJob.text = characterData.job.ToString();
        
        Debug.Assert(skillViewList.Count == skillList.Count, "[Skill]Invalid List Count");

        for (int i = 0; i<skillList.Count; ++i)
        {
            skillViewList[i].Set(skillList[i].skillType);
        }
    }
}
