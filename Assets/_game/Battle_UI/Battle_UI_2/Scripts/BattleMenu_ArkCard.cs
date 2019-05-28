using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class BattleMenu_ArkCard : MonoBehaviour
{
    public Image arkImg;
    public TextMeshProUGUI arkName;
    public Slider arkHp;
    public Transform costPanel;
    public GameObject costPfb;

    void SetAllData(Sprite _img, string _name, int _hp, int _cost)
    {
        arkImg.sprite = _img;
        arkName.text = _name;
        arkHp.value = _hp;
        int yOffset = 0;
        for (int i = 0; i < _cost; i++)
        {
            GameObject crystal = Instantiate(costPfb, costPanel.transform);
            crystal.GetComponent<RectTransform>().anchoredPosition = new Vector3(15 + (15*i), -15-(20*yOffset), 0);
            if (i % 7 == 0)
                yOffset++;
        }
    }

    void Start()
    {
        
    }

    void Update()
    {
        
    }
}
