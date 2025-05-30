using System.Collections;
using UnityEngine;

public class DropItem : MonoBehaviour
{
    Rigidbody2D rb;
    Vector3 spawnPosition;
    float gravity = 20f; // 중력 가속도 (원하는 값으로 조정)
    float targetY;       // 착지할 목표 y좌표

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    public void Init(Vector3 monsterPos)
    {
        spawnPosition = monsterPos;
        targetY = monsterPos.y - 1.0f;

        transform.position = spawnPosition;

        // 처음에 위로 튀게 힘을 줘
        rb.linearVelocity = new Vector2(Random.Range(-4f, 4f), Random.Range(8f, 12f));
    }

    void Update()
    {
        // 계속 중력 적용
        rb.linearVelocity += Vector2.down * gravity * Time.deltaTime;

        // 목표 y위치에 도달했으면 멈춘다
        if (transform.position.y <= targetY)
        {
            transform.position = new Vector3(transform.position.x, targetY, transform.position.z);
            rb.linearVelocity = Vector2.zero;
        }


        // 마우스 위치를 월드 좌표로 변환
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePosition.z = 0; // 2D 게임에서는 z값을 0으로 설정

        Collider2D[] colliders = Physics2D.OverlapPointAll(mousePosition);

        // 모든 충돌체를 확인
        foreach (Collider2D collider in colliders)
        {
            // 현재 아이템 박스를 먹으면??
            if (collider.gameObject == this.gameObject)
            {

                GetNewItem();
                gameObject.SetActive(false);
                break;
            }
        }
    }

    public void GetNewItem()
    {
        int type = Random.Range(0, 2);
        Debug.Log("선택됨" + type);

        switch(type)
        {
            case 0:
                SelectWeapon();
                break;
            
            case 1:
                SelectCoin();
                break;
        }
            
        
    }

    public void SelectWeapon()
    {
         Debug.Log("무기 선택됨");
        // 일단 임시로 무기만 얻을 수 있도록 해보자.
        // 무기 정보 랜덤으로 하나 뽑기...
        ItemSO[] weaponData = GameManager.Inst.weaponArray.weaponData;
        int randIndex = Random.Range(0, weaponData.Length);

        // 뽑은건 inventory에 넣어주자
        GameObject inventory = GameManager.Inst.inventory;

        // 자식을 가져오자 일단 inventory가 16개라고 가정!
        for(int i = 0 ; i < inventory.transform.childCount; i++){
            Transform currentChild = inventory.transform.GetChild(i).GetChild(0);
            if(currentChild.gameObject.activeSelf)
                continue;
            
            currentChild.gameObject.SetActive(true);
            currentChild.GetComponent<DraggableUI>().Init(new Item(weaponData[randIndex]));
            break;
        }
    }

    public void SelectCoin()
    {
        Debug.Log("코인 선택됨");
        int coinCount = Random.Range(1, 11);
        GameManager.Inst.Coin += coinCount;
    }
    
}
