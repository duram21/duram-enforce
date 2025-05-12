using System.Collections.Generic;
using UnityEngine;

public class PoolManager : MonoBehaviour
{
    public GameObject[] prefabs;
    List<GameObject>[] pools;

    void Awake()
    {
        pools = new List<GameObject>[prefabs.Length];

        for(int i = 0 ; i < pools.Length; i++)
        {
            pools[i] = new List<GameObject>();
        }
    }

    public GameObject Get(int index)
    {
        GameObject select = null;

        // ... 선택한 풀의 놀고 있는 GameObject 접근

        // ... 발견하면 select 변수에 할당
        foreach (GameObject item in pools[index])
        {
            if (!item.activeSelf)
            {
                select = item;
                select.SetActive(true);
                break;
            }
        }

        if (!select)
        {            
            if(index == 3) // UI Damage
            {
                select = Instantiate(prefabs[index], GameManager.Inst.canvas.transform);
            }
            else // World Prefabs
            {
                select = Instantiate(prefabs[index], transform);   
            }
            pools[index].Add(select);
        }

         

        return select;
    }
    
    
}
