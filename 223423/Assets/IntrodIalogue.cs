using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class IntrodIalogue : MonoBehaviour
{
    public Text dialogueText; // 대사를 표시할 UI Text
    public Image uiImage; // 깜빡일 UI 이미지
    public AudioSource explosionSound; // 폭발음 AudioSource

    private string[] dialogues =
    {
        "나는 무명기자다.",
        "오늘은 한 연구소를 조사해볼 생각이다.",
        "동료들에게 이곳의 수상한점을 말해봐도 아무도 믿어주지 않아 혼자 오게되었다.",
        "반드시 특종을 찾아 출세를"
            
    };

    private float dialogueDelay = 4.5f; // 대사 간격
    private float initialDelay = 2f; // 첫 대사 시작 전 딜레이
    private float blinkInterval = 0.2f; // 깜빡임 간격
    private int blinkCount = 6; // 깜빡임 횟수

    void Start()
    {
        StartCoroutine(ShowDialogue());
    }

    IEnumerator ShowDialogue()
    {
        yield return new WaitForSeconds(initialDelay); // 첫 대사 시작 전 대기
        for (int i = 0; i < dialogues.Length; i++)
        {
            dialogueText.text = dialogues[i];
            yield return new WaitForSeconds(dialogueDelay);
        }
        dialogueText.text = ""; // 마지막 대사를 지움

        if (explosionSound != null)
        {
            explosionSound.Play();
            yield return new WaitForSeconds(5f);
            explosionSound.Stop();
        }
        // 깜빡임 효과 시작
        StartCoroutine(BlinkImage());
    }

    IEnumerator BlinkImage()
    {
        for (int i = 0; i < blinkCount; i++)
        {
            uiImage.enabled = !uiImage.enabled; // 이미지 활성화/비활성화 토글
            yield return new WaitForSeconds(blinkInterval);
        }
        uiImage.enabled = false; // 깜빡임 후 이미지 비활성화
        dialogueText.text = "여기는 어디지?..";
        yield return new WaitForSeconds(4f);
        dialogueText.text = ""; // 마지막 대사를 지움
    }
}
