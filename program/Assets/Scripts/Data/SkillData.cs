[System.Serializable]
public class SkillData
{
    #region Serializable
    public int index;
    public EnumSkillType skillType;
    #endregion
    
    public int Level { get; set; }
}

public enum EnumSkillType
{
    Skill1,
    Skill2,
    Skill3,
    Skill4,
    Skill5,
}

