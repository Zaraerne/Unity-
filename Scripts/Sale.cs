using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
public class Sale : MonoBehaviour,IPointerDownHandler
{
    private PlayerManege player;
    public SaleSkillBookType type;

    private void Awake()
    {
        player = GameObject.Find("PlayerBG").GetComponent<PlayerManege>();
    }

    // Start is called before the first frame update
    // 按下有相应
    public void OnPointerDown(PointerEventData eventData)
    {
        if (ShopSQL.SaleSkillBook(type))
        {
            Destroy(gameObject);
            player.UpdateText();
        }
    }
    // 按下与松开有响应
    public void OnPointerClick(PointerEventData eventData)
    {
        //你要触发的代码
        
    }
}
