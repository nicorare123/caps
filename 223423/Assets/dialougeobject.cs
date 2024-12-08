using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class dialougeobject : MonoBehaviour
{
    public Text dialogueText; // UI �ؽ�Ʈ ����
    public string message = "����� ���ִ�"; // ����� �޽���
    public float displayTime = 3f; // �޽����� ǥ�õǴ� �ð�
    public string playerTag = "Player"; // �÷��̾��� �±� �̸�

    private void Start()
    {
        // UI �ؽ�Ʈ�� ��Ȱ��ȭ ���·� ����
        if (dialogueText != null)
        {
            dialogueText.gameObject.SetActive(false);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        // �浹 ����� �±װ� "Player"�� ���� ����
        if (other.CompareTag(playerTag))
        {
            if (dialogueText != null)
            {
                // �ؽ�Ʈ Ȱ��ȭ �� �޽��� ����
                dialogueText.gameObject.SetActive(true);
                dialogueText.text = message;

                // ���� �ð� �� �ؽ�Ʈ ��Ȱ��ȭ �� ������Ʈ �ı�
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

        // ���� ������Ʈ �ı�
        Destroy(gameObject);
    }
}

