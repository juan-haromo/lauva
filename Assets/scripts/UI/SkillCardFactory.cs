using UnityEngine;

public class SkillCardFactory : MonoBehaviour
{
    [SerializeField] Transform container;
    [SerializeField] SkillCardView cardPrefab;
    [SerializeField] int rewardCount;

    void Start()
    {
        GenerateRewards();
    }
    public void GenerateRewards()
    {
        for(int i = container.childCount - 1; 0 <= i; i--)
        {
            Destroy(container.GetChild(i).gameObject);    
        }

        for(int i = 0; i<rewardCount; i++)
        {
            Instantiate(cardPrefab.gameObject,container);
        }
    }
}

public class SkillCardBuilder
{
    string name;
    Sprite icon;
    ActivateCard selectedEffect;
}

public delegate void ActivateCard();
