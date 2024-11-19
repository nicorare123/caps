using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public Text messageText;  // 출력할 UI 텍스트
    public bool[] condition ;  // 조건을 설정하는 변수 (전화기)
   
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
    private void Start()
    {
        condition[0] = false;
        condition[1] = false;
        condition[2] = false;
        condition[3] = false;
    }
    void Update()
    {
        if (condition[0])
        {
            TextUI.SetActive(true);
            // 조건이 true라면 텍스트를 출력하고 사라지게 만듦
            StartCoroutine(DisplayText());
            condition[0] = false;
        }
        else if (condition[1])
        {
            
                TextUI.SetActive(true);
                // 조건이 true라면 텍스트를 출력하고 사라지게 만듦
                StartCoroutine(DisplayText1());
                condition[1] = false;
            
        }
        else if (condition[2]) // 전기연결후 전화기
        {

            TextUI.SetActive(true);
            // 조건이 true라면 텍스트를 출력하고 사라지게 만듦
            StartCoroutine(DisplayText2());
            condition[2] = false;

        }
        else if (condition[3]) // 1층 엘베 버튼
        {
            Debug.Log("작동11");
            TextUI.SetActive(true);
            // 조건이 true라면 텍스트를 출력하고 사라지게 만듦
            StartCoroutine(DisplayText3());
            condition[3] = false;

        }
        else if (condition[4]) // 1층 엘베 버튼
        {
            Debug.Log("작동11");
            TextUI.SetActive(true);
            // 조건이 true라면 텍스트를 출력하고 사라지게 만듦
            StartCoroutine(DisplayText4());
            condition[4] = false;

        }
    }

    private IEnumerator DisplayText()
    {
        // 텍스트 출력
        messageText.text = "...전기가 나간거같다. 다른 전화기를 찾아보자";

        // 3초 대기
        yield return new WaitForSeconds(3f);

        // 텍스트를 빈 문자열로 설정하여 텍스트를 사라지게 함
        messageText.text = "";

        TextUI.SetActive(false);
    }
    private IEnumerator DisplayText1()
    {
        // 텍스트 출력
        messageText.text = "...전기가 나간거같다11.";

        // 3초 대기
        yield return new WaitForSeconds(3f);

        // 텍스트를 빈 문자열로 설정하여 텍스트를 사라지게 함
        messageText.text = "";

        TextUI.SetActive(false);
    }
    private IEnumerator DisplayText2()
    {
        // 텍스트 출력
        messageText.text = ".....";

        // 3초 대기
        yield return new WaitForSeconds(3f);

        // 텍스트를 빈 문자열로 설정하여 텍스트를 사라지게 함
        messageText.text = "";

        TextUI.SetActive(false);
    }
    private IEnumerator DisplayText3()
    {
        // 텍스트 출력
        messageText.text = "아무런 반응이 없다..";

        // 3초 대기
        yield return new WaitForSeconds(3f);

        // 텍스트를 빈 문자열로 설정하여 텍스트를 사라지게 함
        messageText.text = "";

        TextUI.SetActive(false);
    }
    private IEnumerator DisplayText4()
    {
        // 텍스트 출력
        messageText.text = "키카드가 필요하다.";

        // 3초 대기
        yield return new WaitForSeconds(3f);

        // 텍스트를 빈 문자열로 설정하여 텍스트를 사라지게 함
        messageText.text = "";

        TextUI.SetActive(false);
    }
}
