using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum SaleSkillBookType
{
    Skill_1,
    Skill_2,
    Skill_3

}
public class PlayerManege : MonoBehaviour
{
    // 技能预设体
    public GameObject Skill_1;
    public GameObject Skill_2;
    public GameObject Skill_3;

    private Text Attck;
    private Text Defiend;
    private Text Money;

    private string ShopBase = "Shop.sqlite";
    private string PlayerBase = "Player.sqlite";
    private void Awake()
    {
        // 查找对象
        Attck = transform.Find("Attack/Text_1").GetComponent<Text>();
        Defiend = transform.Find("Defined/Text_1").GetComponent<Text>();
        Money = transform.Find("Money/Text_1").GetComponent<Text>();
        UpdateText();
    }


    public void UpdateText()
    {
        // 打开英雄数据库
        SQLFrame.DataBaseOpen(PlayerBase);

        string query = "select Money From Player where PlayerName='Zaraerne'";
        Money.text = SQLFrame.InquireNoce(query).ToString();
        Attck.text = SQLFrame.InquireNoce("select Attack From Player where PlayerName='Zaraerne'").ToString();
        Defiend.text = SQLFrame.InquireNoce("select Defiend From Player where PlayerName='Zaraerne'").ToString();
        SQLFrame.SQLClose();
        
    }
    // 设置装备
    public void SetEquip(SkillBookType type)
    {
        SQLFrame.DataBaseOpen(ShopBase);
        List<ArrayList> list = new List<ArrayList>();
        switch (type)
        {
            case SkillBookType.Skill_1:
                GameObject obj = GameObject.Instantiate(Skill_1);
                obj.transform.SetParent(transform.Find("PlayerQU"));

               
                list =SQLFrame.InquireMore(
                    "select SkillMoney,SkillAttack,SkillDefiend From SkillBooks where SkillName='降龙十八掌'");
                SQLFrame.SQLClose();
                
                
                break;
            case SkillBookType.Skill_2:
                GameObject obj1 = GameObject.Instantiate(Skill_2);
                obj1.transform.SetParent(transform.Find("PlayerQU"));
                
                list =SQLFrame.InquireMore(
                    "select SkillMoney,SkillAttack,SkillDefiend From SkillBooks where SkillName='次元斩'");
                SQLFrame.SQLClose();
                break;
            
            case SkillBookType.Skill_3:
                GameObject obj2 = GameObject.Instantiate(Skill_3);
                obj2.transform.SetParent(transform.Find("PlayerQU"));
                
                list =SQLFrame.InquireMore(
                    "select SkillMoney,SkillAttack,SkillDefiend From SkillBooks where SkillName='自由穿梭'");
                SQLFrame.SQLClose();
                break;
        }
        SQLFrame.DataBaseOpen(PlayerBase);
        int Attck = Convert.ToInt32(SQLFrame
            .InquireNoce("select Attack from Player where PlayerName='Zaraerne'").ToString());
        int Def = Convert.ToInt32(SQLFrame
            .InquireNoce("select Defiend from Player where PlayerName='Zaraerne'").ToString());
        int mon = Convert.ToInt32(SQLFrame
            .InquireNoce("select Money from Player where PlayerName='Zaraerne'").ToString());

        Debug.Log(mon);
        
        Def += Convert.ToInt32(list[0][2].ToString());
        Attck += Convert.ToInt32(list[0][1].ToString());
        // mon -= Convert.ToInt32(list[0][0].ToString());
                
        string query = "update Player set Attack=" + Attck.ToString()+" where PlayerName = 'Zaraerne'";
        // Debug.Log("update Player  set Attack=" + Attck.ToString());
        string query1 = "update Player set Defiend=" + Def.ToString()+" where PlayerName = 'Zaraerne'";
        // string query2 = "update Player set Money=" + mon.ToString()+" where PlayerName = 'Zaraerne'";
        SQLFrame.SerachDase(query);
        SQLFrame.SerachDase(query1);
        // SQLFrame.SerachDase(query2);
        
        SQLFrame.SQLClose();
        // 更新
        UpdateText();
        
        
    }
    
    // Start is called before the first frame update
    void Start()
    {
        


    }

    // Update is called once per frame
    void Update()
    {
        
        
        
    }
}
