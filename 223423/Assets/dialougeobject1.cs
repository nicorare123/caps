using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class dialougeobject1 : MonoBehaviour
{
    public Text dialogueText; // UI 텍스트 참조
    public string message = "사과가 맛있다"; // 출력할 메시지
    public float displayTime = 3f; // 메시지가 표시되는 시간

    private void Start()
    {
        
            // 코루틴 실행
            StartCoroutine(DisplayMessageCoroutine());
        
        
            
        
    }

    private System.Collections.IEnumerator DisplayMessageCoroutine()
    {
        // 텍스트 활성화 및 메시지 설정
        dialogueText.gameObject.SetActive(true);
        dialogueText.text = message;

        // 지정된 시간 대기
        yield return new WaitForSeconds(displayTime);

        // 텍스트 비활성화
        dialogueText.gameObject.SetActive(false);

        // 현재 오브젝트 파괴
        Destroy(gameObject);
    }

}
