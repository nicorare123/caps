using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Ending : MonoBehaviour
{
    public Text dialogueText; // 대사를 표시할 UI Text
    public Text endText; // "End.."를 표시할 UI Text
    public GameObject Endimage; // 마지막 이미지를 표시할 GameObject
    public AudioSource endingSound; // 마지막에 재생될 사운드
    public CanvasGroup endImageCanvasGroup; // Fade-In을 위한 CanvasGroup

    private string[] dialogues =
    {
        "무사히 탈출한 나는 자료를 믿을만한 곳에 넘겨주었고\n 이후 상황은 일사천리로 진행되었다.",
        "연구소는 국가를 전복시킬 연구를 진행 중 사고가 발생했던 것이었고\n 필요하면 인체실험도 불사하던 곳이었다.",
        "대부분의 언론기관도 전부 포섭해 입막음을 하고 있었던 것 같다.\n 동료들 역시 돈을 받아 내 말을 믿어주지 않은 것 같다.",
        "연구원들은 전부 연행되었다고 한다. 이걸로 된 거겠지...\n   하지만 자꾸 불안한 느낌이 드는 건 왜일까?"
    };
    private float dialogueDelay = 4f; // 대사 간격
    private float initialDelay = 3f; // 첫 대사 시작 전 딜레이
    private float endTextDelay = 1f; // 대사 종료 후 "End.." 출력 딜레이
    private float fadeDuration = 2f; // Fade-In 효과 지속 시간

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

        // 대사 끝난 후 대기
        yield return new WaitForSeconds(endTextDelay);

        // Fade-In 및 사운드 재생 시작
        StartCoroutine(ShowEndImage());
    }

    IEnumerator ShowEndImage()
    {
        if (endingSound != null)
        {
            endingSound.Play(); // 사운드 재생
        }

        float elapsedTime = 0f;
        while (elapsedTime < fadeDuration)
        {
            elapsedTime += Time.deltaTime;
            float alpha = Mathf.Clamp01(elapsedTime / fadeDuration); // 0에서 1로 점진적으로 증가
            endImageCanvasGroup.alpha = alpha; // 이미지 투명도 설정
            yield return null;
        }

        endImageCanvasGroup.alpha = 1f; // 완전한 투명도 설정
    }
}
