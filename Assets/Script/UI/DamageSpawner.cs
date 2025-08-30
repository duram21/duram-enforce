using UnityEngine;

public class DamageSpawner : MonoBehaviour
{
    public void SpawnDamage(float amount)
    {        
        Vector3 worldPosition = transform.position + Vector3.up * 2f;
        Vector3 screenPosition = Camera.main.WorldToScreenPoint(worldPosition);

        // 텍스트 프리팹 생성
        GameObject textObj = GameManager.Inst.pool.Get(3);

        // 텍스트의 RectTransform을 가져오기
        RectTransform rectTransform = textObj.GetComponent<RectTransform>();

        // 화면 좌표로 위치 지정
        rectTransform.position = screenPosition;

        // 추가적인 offset 적용 (스크린 좌표에서 직접 이동)
        rectTransform.anchoredPosition += new Vector2(Random.Range(-30f, 0f), Random.Range(0f, 10f));

        // 텍스트를 나타낼 DamageText 컴포넌트
        Damage damageText = textObj.GetComponent<Damage>();

        // 텍스트 설정
        string damageStr = amount.ToString();
        Color textColor = Color.red;

        // 데미지 텍스트 표시
        damageText.Show(damageStr, textColor, Vector3.zero);  // offset은 이미 rectTransform에서 처리됨
    }
}
