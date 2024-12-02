using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class IntrodIalogue : MonoBehaviour
{
    public Text dialogueText; // ��縦 ǥ���� UI Text
    public Image uiImage; // ������ UI �̹���
    public AudioSource explosionSound; // ������ AudioSource

    private string[] dialogues =
    {
        "���� ������ڴ�.",
        "������ �� �����Ҹ� �����غ� �����̴�.",
        "����鿡�� �̰��� ���������� ���غ��� �ƹ��� �Ͼ����� �ʾ� ȥ�� ���ԵǾ���.",
        "�ݵ�� Ư���� ã�� �⼼��"
            
    };

    private float dialogueDelay = 4.5f; // ��� ����
    private float initialDelay = 2f; // ù ��� ���� �� ������
    private float blinkInterval = 0.2f; // ������ ����
    private int blinkCount = 6; // ������ Ƚ��

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

        if (explosionSound != null)
        {
            explosionSound.Play();
            yield return new WaitForSeconds(5f);
            explosionSound.Stop();
        }
        // ������ ȿ�� ����
        StartCoroutine(BlinkImage());
    }

    IEnumerator BlinkImage()
    {
        for (int i = 0; i < blinkCount; i++)
        {
            uiImage.enabled = !uiImage.enabled; // �̹��� Ȱ��ȭ/��Ȱ��ȭ ���
            yield return new WaitForSeconds(blinkInterval);
        }
        uiImage.enabled = false; // ������ �� �̹��� ��Ȱ��ȭ
        dialogueText.text = "����� �����?..";
        yield return new WaitForSeconds(4f);
        dialogueText.text = ""; // ������ ��縦 ����
    }
}
