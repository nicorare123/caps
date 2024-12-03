using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class keynumber : MonoBehaviour
{
    private string correctPassword = "1969";  // 정답 비밀번호
    private string currentInput = "";         // 현재 사용자가 입력한 값
    public GameObject passwordpanel;
    public GameObject[] door;

    // 숫자 버튼 클릭 시 호출
    public void AddDigit(string digit)
    {
        if (currentInput.Length < correctPassword.Length) // 입력 길이 제한
        {
            currentInput += digit; // 입력 추가
            Debug.Log("현재 입력: " + currentInput);

            // 입력 완료 시 확인
            if (currentInput.Length == correctPassword.Length)
            {
                CheckPassword();
            }
        }
    }
    private void Update()
    {if (passwordpanel)
        {
            Time.timeScale = 0f;
        }
    }

    // 입력 확인
    private void CheckPassword()
    {
        if (currentInput == correctPassword)
        {
            door[0].SetActive(false);
            door[1].SetActive(true);
            Time.timeScale = 1f;
            Debug.Log("성공");
            // 마우스를 숨기고 고정
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;
            passwordpanel.SetActive(false);
            
        }
        else
        {
            Time.timeScale = 1f;
            Debug.Log("실패");
            passwordpanel.SetActive(false);
            
        }

        ResetInput(); // 입력 초기화
    }

    // 입력 초기화
    private void ResetInput()
    {
        currentInput = "";
        Debug.Log("입력 초기화됨");
    }
}
