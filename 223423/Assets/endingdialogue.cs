using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;



public class endingdialogue : MonoBehaviour
{
    public Text dialogueText; // 대사를 표시할 UI Text
    public Text endText; // "End.."를 표시할 UI Text

    public GameObject player;
    public Transform Targetpos;
    public GameObject endingpanel;
    public CharacterController controller;
    public GameObject[] chageobject;
    public GameObject panel;




    private string[] dialogues =
    {
        "연구실을 나오고 나는 연구실 안에 있던 상황을 열심히 얘기해봤지만",
        "다들 나를 이상한 사람 취급할 뿐",
        "밖에는 안과 다르게 사람들의 평범한 일상만이 지속되고 있었다.",
        "정말로 저 연구실에는 아무것도 없었던 것일까...",
    };
    private float dialogueDelay = 4f; // 대사 간격
    private float initialDelay = 3f; // 첫 대사 시작 전 딜레이
    private float endTextDelay = 1f; // 대사 종료 후 "End.." 출력 딜레이

    void Start()
    {
       // controller.enabled = false;
        StartCoroutine(ShowDialogue());
        Debug.Log("실행");
        chageobject[0].SetActive(true);
        chageobject[1].SetActive(false);

     //   controller.enabled = true;



    }



    IEnumerator ShowDialogue()
    {
       
        yield return new WaitForSeconds(initialDelay); // 첫 대사 시작 전 3초 대기
        for (int i = 0; i < dialogues.Length; i++)
        {
            dialogueText.text = dialogues[i];
            yield return new WaitForSeconds(dialogueDelay);
        }
        dialogueText.text = ""; // 마지막 대사를 지움
        player.transform.position = Targetpos.position;
        // 대사 끝난 후 4초 대기
        yield return new WaitForSeconds(endTextDelay);

        // "End.." 텍스트 표시
        endText.text = "End..?";

        yield return new WaitForSeconds(2f);
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
        panel.SetActive(true);

        
    }

    
}
