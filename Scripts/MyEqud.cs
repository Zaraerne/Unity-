using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class MyEqud : MonoBehaviour,IPointerDownHandler
{
    private PlayerManege player;

    private void Awake()
    {
        player = GameObject.Find("PlayerBG").GetComponent<PlayerManege>();
    }

    public SkillBookType type;
    // 按下有相应
    public void OnPointerDown(PointerEventData eventData)
    {
        Debug.Log("Buy");
        if (ShopSQL.BuySkillBook(type))
        {
            player.SetEquip(type);
            
        }
    }
    // 按下与松开有响应
    public void OnPointerClick(PointerEventData eventData)
    {
        //你要触发的代码
        
    }

}
