using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Ending : MonoBehaviour
{
    public Text dialogueText; // ��縦 ǥ���� UI Text
    public Text endText; // "End.."�� ǥ���� UI Text
    public GameObject Endimage; // ������ �̹����� ǥ���� GameObject
    public AudioSource endingSound; // �������� ����� ����
    public CanvasGroup endImageCanvasGroup; // Fade-In�� ���� CanvasGroup

    private string[] dialogues =
    {
        "������ Ż���� ���� �ڷḦ �������� ���� �Ѱ��־���\n ���� ��Ȳ�� �ϻ�õ���� ����Ǿ���.",
        "�����Ҵ� ������ ������ų ������ ���� �� ��� �߻��ߴ� ���̾���\n �ʿ��ϸ� ��ü���赵 �һ��ϴ� ���̾���.",
        "��κ��� ��б���� ���� ������ �Ը����� �ϰ� �־��� �� ����.\n ����� ���� ���� �޾� �� ���� �Ͼ����� ���� �� ����.",
        "���������� ���� ����Ǿ��ٰ� �Ѵ�. �̰ɷ� �� �Ű���...\n   ������ �ڲ� �Ҿ��� ������ ��� �� ���ϱ�?"
    };
    private float dialogueDelay = 4f; // ��� ����
    private float initialDelay = 3f; // ù ��� ���� �� ������
    private float endTextDelay = 1f; // ��� ���� �� "End.." ��� ������
    private float fadeDuration = 2f; // Fade-In ȿ�� ���� �ð�

    void Start()
    {
        StartCoroutine(ShowDialogue());
    }

    IEnumerator ShowDialogue()
    {
        yield return new WaitForSeconds(initialDelay); // ù ��� ���� �� ���
        for (int i = 0; i < dialogues.Length; i++)
        {
            dialogueText.text = dialogues[i];
            yield return new WaitForSeconds(dialogueDelay);
        }
        dialogueText.text = ""; // ������ ��縦 ����

        // ��� ���� �� ���
        yield return new WaitForSeconds(endTextDelay);

        // Fade-In �� ���� ��� ����
        StartCoroutine(ShowEndImage());
    }

    IEnumerator ShowEndImage()
    {
        if (endingSound != null)
        {
            endingSound.Play(); // ���� ���
        }

        float elapsedTime = 0f;
        while (elapsedTime < fadeDuration)
        {
            elapsedTime += Time.deltaTime;
            float alpha = Mathf.Clamp01(elapsedTime / fadeDuration); // 0���� 1�� ���������� ����
            endImageCanvasGroup.alpha = alpha; // �̹��� ���� ����
            yield return null;
        }

        endImageCanvasGroup.alpha = 1f; // ������ ���� ����
    }
}
