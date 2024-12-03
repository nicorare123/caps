using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



public class endingdialogue : MonoBehaviour
{
    public Text dialogueText; // ��縦 ǥ���� UI Text
    public Text endText; // "End.."�� ǥ���� UI Text

    public GameObject player;
    public Transform Targetpos;

    private string[] dialogues =
    {
        "�������� ������ ���� ������ �ȿ� �ִ� ��Ȳ�� ������ ����غ�����",
        "�ٵ� ���� �̻��� ��� ����� ��",
        "�ۿ��� �Ȱ� �ٸ��� ������� ����� �ϻ��� ���ӵǰ� �־���.",
        "������ �� �����ǿ��� �ƹ��͵� ������ ���ϱ�...",
    };
    private float dialogueDelay = 4f; // ��� ����
    private float initialDelay = 3f; // ù ��� ���� �� ������
    private float endTextDelay = 1f; // ��� ���� �� "End.." ��� ������

    void Start()
    {
       
        StartCoroutine(ShowDialogue());
        player.transform.position = Targetpos.position;

    }

    IEnumerator ShowDialogue()
    {
        yield return new WaitForSeconds(initialDelay); // ù ��� ���� �� 3�� ���
        for (int i = 0; i < dialogues.Length; i++)
        {
            dialogueText.text = dialogues[i];
            yield return new WaitForSeconds(dialogueDelay);
        }
        dialogueText.text = ""; // ������ ��縦 ����

        // ��� ���� �� 4�� ���
        yield return new WaitForSeconds(endTextDelay);

        // "End.." �ؽ�Ʈ ǥ��
        endText.text = "End..";


    }
}
