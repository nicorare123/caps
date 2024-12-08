using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class dialougeobject1 : MonoBehaviour
{
    public Text dialogueText; // UI �ؽ�Ʈ ����
    public string message = "����� ���ִ�"; // ����� �޽���
    public float displayTime = 3f; // �޽����� ǥ�õǴ� �ð�

    private void Start()
    {
        if (dialogueText != null)
        {
            // �ڷ�ƾ ����
            StartCoroutine(DisplayMessageCoroutine());
        }
        else
        {
            Debug.LogError("Dialogue Text is not assigned in the Inspector!");
        }
    }

    private System.Collections.IEnumerator DisplayMessageCoroutine()
    {
        // �ؽ�Ʈ Ȱ��ȭ �� �޽��� ����
        dialogueText.gameObject.SetActive(true);
        dialogueText.text = message;

        // ������ �ð� ���
        yield return new WaitForSeconds(displayTime);

        // �ؽ�Ʈ ��Ȱ��ȭ
        dialogueText.gameObject.SetActive(false);

        // ���� ������Ʈ �ı�
        Destroy(gameObject);
    }

}
