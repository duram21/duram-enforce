using UnityEngine;
using TMPro;
using DG.Tweening;

public class Damage : MonoBehaviour
{
    public TMP_Text tmpText;

    public void Show(string text, Color color, Vector3 moveOffset, float duration = 1.0f)
    {
        tmpText.text = text;
        tmpText.color = color;

        // 시작 위치 기억
        Vector3 startPos = transform.position;
        Vector3 endPos = startPos + moveOffset;

        // 위치 이동 + 페이드 아웃
        transform.DOMove(endPos, duration).SetEase(Ease.OutCubic);
        tmpText.DOFade(0, duration).OnComplete(() => gameObject.SetActive(false));
    }
}