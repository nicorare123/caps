using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class dialougeobject : MonoBehaviour
{
    public Text dialogueText; // UI 텍스트 참조
    public string message = "사과가 맛있다"; // 출력할 메시지
    public float displayTime = 3f; // 메시지가 표시되는 시간
    public string playerTag = "Player"; // 플레이어의 태그 이름

    private void Start()
    {
        // UI 텍스트를 비활성화 상태로 시작
        if (dialogueText != null)
        {
            dialogueText.gameObject.SetActive(false);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        // 충돌 대상의 태그가 "Player"일 때만 실행
        if (other.CompareTag(playerTag))
        {
            if (dialogueText != null)
            {
                // 텍스트 활성화 및 메시지 설정
                dialogueText.gameObject.SetActive(true);
                dialogueText.text = message;

                // 일정 시간 후 텍스트 비활성화 및 오브젝트 파괴
                Invoke(nameof(HideTextAndDestroy), displayTime);
            }
        }
    }

    private void HideTextAndDestroy()
    {
        if (dialogueText != null)
        {
            dialogueText.gameObject.SetActive(false);
        }

        // 현재 오브젝트 파괴
        Destroy(gameObject);
    }
}

