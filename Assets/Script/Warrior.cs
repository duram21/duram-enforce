using UnityEngine;
using System.Collections;

public class Warrior : MonoBehaviour
{
    Vector3 originPos;
    public Transform warrior;
    public SpriteRenderer warriorSpriter;
    public Transform box;
    public Weapon weapon;
    Coroutine equipRoutine;
    public Animator anim;

    void Awake()
    {
        originPos = warrior.position;
        warriorSpriter = warrior.GetComponent<SpriteRenderer>();
        anim = warrior.GetComponent<Animator>();
    }

    public void EquipWeapon(Item item)
    {
        weapon.Unequip();
        if(equipRoutine != null)
        {
            StopCoroutine(equipRoutine);
            equipRoutine = null;
        }
        equipRoutine = StartCoroutine(EquipWeaponRoutine(item));
    }

    public IEnumerator EquipWeaponRoutine(Item item)
    {
        // 1. 상자로 이동
        warriorSpriter.flipX = true;
        anim.SetBool("isRunning", true);
        yield return MoveToPosition(box.position);

        // 2. 장착 애니메이션 or 이펙트
        //PlayEquipAnimation(); // 애니메이션 실행
        yield return new WaitForSeconds(1f); // 장착 시간

        // 3. 무기 실제 장착
        //Equip(weapon);
        weapon.Init(item);

        // 4. 원래 위치로 복귀
        warriorSpriter.flipX = false;
        yield return MoveToPosition(originPos);
        anim.SetBool("isRunning", false);

        yield return null;
    }

    private IEnumerator MoveToPosition(Vector3 targetPos)
    {
        float speed = 1f;
        while (Vector3.Distance(warrior.position, targetPos) > 0.1f)
        {
            warrior.position = Vector3.MoveTowards(warrior.position, targetPos, speed * Time.deltaTime);
            yield return null;
        }
    }


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
