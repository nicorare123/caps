using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public Text messageText;  // 출력할 UI 텍스트
    public bool condition = false;  // 조건을 설정하는 변수
    public GameObject TextUI;

    private void Awake()
    {
        // 싱글톤 패턴 구현
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
    void Update()
    {
        if (condition)
        {
            TextUI.SetActive(true);
            // 조건이 true라면 텍스트를 출력하고 사라지게 만듦
            StartCoroutine(DisplayText());
            condition = false;
        }
    }

    private IEnumerator DisplayText()
    {
        // 텍스트 출력
        messageText.text = "...전기가 나간거같다.";

        // 3초 대기
        yield return new WaitForSeconds(3f);

        // 텍스트를 빈 문자열로 설정하여 텍스트를 사라지게 함
        messageText.text = "";

        TextUI.SetActive(false);
    }
}
