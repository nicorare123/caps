using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;



public class endingdialogue : MonoBehaviour
{
    public Text dialogueText; // ��縦 ǥ���� UI Text
    public Text endText; // "End.."�� ǥ���� UI Text

    public GameObject player;
    public Transform Targetpos;
    public GameObject endingpanel;
    public CharacterController controller;
    public GameObject[] chageobject;
    public GameObject panel;




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
       // controller.enabled = false;
        StartCoroutine(ShowDialogue());
        Debug.Log("����");
        chageobject[0].SetActive(true);
        chageobject[1].SetActive(false);

     //   controller.enabled = true;



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
        player.transform.position = Targetpos.position;
        // ��� ���� �� 4�� ���
        yield return new WaitForSeconds(endTextDelay);

        // "End.." �ؽ�Ʈ ǥ��
        endText.text = "End..?";

        yield return new WaitForSeconds(2f);
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
        panel.SetActive(true);

        
    }

    
}
