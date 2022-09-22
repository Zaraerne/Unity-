using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour
{
    // 三个技能预设体
    public GameObject Skill_1;
    public GameObject Skill_2;
    public GameObject Skill_3;

    private void Init()
    {
        GameObject obj = GameObject.Instantiate(Skill_1);
        obj.transform.SetParent(transform);
        GameObject obj1 = GameObject.Instantiate(Skill_2);
        obj1.transform.SetParent(transform);
        GameObject obj2 = GameObject.Instantiate(Skill_3);
        obj2.transform.SetParent(transform);
    }
    // Start is called before the first frame update
    void Start()
    {
        // 添加商城物品
        Init();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
}
