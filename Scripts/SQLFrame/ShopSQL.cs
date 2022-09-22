using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum SkillBookType
{
    Skill_1,
    Skill_2,
    Skill_3

}

public static class ShopSQL
{
    private static string ShopBase = "Shop.sqlite";
    private static string PlayerBase = "Player.sqlite";
    public static bool BuySkillBook(SkillBookType type)
    {
        SQLFrame.DataBaseOpen(ShopBase);
        Int32 ShopMoney;
        string SkillName;
        switch (type)
        {
            case SkillBookType.Skill_1:
                Debug.Log(SQLFrame.InquireNoce("select SkillMoney From SkillBooks where SkillName='降龙十八掌'"));
                ShopMoney = Convert.ToInt32(SQLFrame.InquireNoce("SELECT SkillMoney From SkillBooks where SkillName='降龙十八掌'").ToString());
                SkillName = "降龙十八掌";
                break;
            
            case SkillBookType.Skill_2:
                ShopMoney = Convert.ToInt32(SQLFrame.InquireNoce("SELECT SkillMoney From SkillBooks where SkillName='次元斩'").ToString());
                SkillName = "次元斩";
                break;
                
            case SkillBookType.Skill_3:
                ShopMoney = Convert.ToInt32(SQLFrame.InquireNoce("SELECT SkillMoney From SkillBooks where SkillName='自由穿梭'").ToString());
                SkillName = "自由穿梭";
                break;
            default: 
                ShopMoney = 999999;
                SkillName = "";
                break;
        }
        
        SQLFrame.SQLClose();
        SQLFrame.DataBaseOpen(PlayerBase);
        Int32 PlayerMoney = Convert.ToInt32(SQLFrame.InquireNoce("select Money From Player where PlayerName='Zaraerne'").ToString());
        if (PlayerMoney > ShopMoney)
        {
            Debug.Log("购买成功");
            // 更改金钱
            string query = "Update Player set Money = " + (PlayerMoney - ShopMoney).ToString();
            SQLFrame.SerachDase(query);
            // 更改装备
            string query1 = "select Skills From  Player where PlayerName='Zaraerne'";
            string Quien = SQLFrame.InquireNoce(query1).ToString();
            Quien += SkillName;
            Quien += "|";
            // 存入装备
            string query2 = "Update Player set Skills = '" + Quien + "'";
            SQLFrame.SerachDase(query2);
            
            // PlayerManege.SetEquip(type);
            SQLFrame.SQLClose();
            return true;
        }
        else
        {
            Debug.Log("金钱不够，不足以购买"+SkillName);
            // 关闭数据库链接
            SQLFrame.SQLClose();
            return false;
        }
        
    }

    public static bool SaleSkillBook(SaleSkillBookType type)
    {
        SQLFrame.DataBaseOpen("Shop.sqlite");
        List<ArrayList> list = new List<ArrayList>();
        switch (type)
        {
            case SaleSkillBookType.Skill_1:
                list =SQLFrame.InquireMore(
                    "select SkillMoney,SkillAttack,SkillDefiend From SkillBooks where SkillName='降龙十八掌'");
                SQLFrame.SQLClose();
                
                
                break;
            case SaleSkillBookType.Skill_2:
                list =SQLFrame.InquireMore(
                    "select SkillMoney,SkillAttack,SkillDefiend From SkillBooks where SkillName='次元斩'");
                SQLFrame.SQLClose();
               
                
                break;
            
            case SaleSkillBookType.Skill_3:
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
        
        Def -= Convert.ToInt32(list[0][2].ToString());
        Attck -= Convert.ToInt32(list[0][1].ToString());
        mon += Convert.ToInt32(list[0][0].ToString())/2;
                
        string query = "update Player set Attack=" + Attck.ToString()+" where PlayerName = 'Zaraerne'";
        // Debug.Log("update Player  set Attack=" + Attck.ToString());
        string query1 = "update Player set Defiend=" + Def.ToString()+" where PlayerName = 'Zaraerne'";
        string query2 = "update Player set Money=" + mon.ToString()+" where PlayerName = 'Zaraerne'";
        SQLFrame.SerachDase(query);
        SQLFrame.SerachDase(query1);
        SQLFrame.SerachDase(query2);
        
        
        return true;
    }
    
    
}
