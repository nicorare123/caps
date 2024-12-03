using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Electbutton1 : MonoBehaviour
{
    public bool[] angle;  // 버튼 회전 상태를 추적하는 배열
    public Button[] buttons;  // 13개의 버튼 배열
    private Image[] buttonImages;  // 각 버튼의 Image 컴포넌트를 저장할 배열
    public GameObject panel;
    public GameObject rotateobject;

    void Start()
    {
        // 버튼과 버튼 이미지 컴포넌트를 배열에 할당
        buttonImages = new Image[buttons.Length];

        for (int i = 0; i < buttons.Length; i++)
        {
            buttonImages[i] = buttons[i].GetComponentInChildren<Image>();  // 각 버튼의 Image 컴포넌트 가져오기
            if (buttonImages[i] != null)
            {
                // 초기 회전 상태 확인
                LogRotationState(i);
                UpdateAngleStatus(i);  // 초기 상태 업데이트
            }
            else
            {
                Debug.LogWarning("버튼 " + i + " 내부에 Image 컴포넌트가 없습니다!");
            }
        }
    }
    private void Update()
    {
        if (angle[0] &&
            angle[1] &&
            angle[2] &&
            angle[3] &&
            angle[4] &&
            angle[5] &&
            angle[6] &&
            angle[7] &&
            angle[8] &&
            angle[9] &&
            angle[10] &&
            angle[11] &&
            angle[12] 


            )
        {
            panel.SetActive(false);
            rotateobject.SetActive(true);
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;

        }
    }
    public void RotateButtonImage(int buttonIndex)
    {
        // 지정된 버튼의 이미지 회전
        if (buttonImages[buttonIndex] != null)
        {
            buttonImages[buttonIndex].rectTransform.Rotate(Vector3.forward, 90f);  // 90도 회전
            LogRotationState(buttonIndex);  // 회전 상태 출력
            UpdateAngleStatus(buttonIndex);  // angle 배열 업데이트
        }
        else
        {
            Debug.LogWarning("버튼 " + buttonIndex + " 내부에 Image 컴포넌트가 없습니다!");
        }
    }

    // 버튼의 회전 상태에 따라 angle 배열 업데이트
    private void UpdateAngleStatus(int buttonIndex)
    {
        float currentRotation = buttonImages[buttonIndex].rectTransform.localEulerAngles.z;

        // 각 버튼별 조건 확인 및 angle 배열 업데이트
        switch (buttonIndex)
        {
            case 0:
            case 1:
                angle[buttonIndex] = Mathf.Approximately(currentRotation, 0f);
                break;

            case 2:
            case 3:
            
            case 9:
            case 10:
            case 11:
           
                angle[buttonIndex] = Mathf.Approximately(currentRotation, 0f) || Mathf.Approximately(currentRotation, 180f);
                break;

            case 4:
            case 12:
                angle[buttonIndex] = Mathf.Approximately(currentRotation, 180f);
                break;

            case 5:
                angle[buttonIndex] = Mathf.Approximately(currentRotation, 90f);
                break;

            case 6:
            
                angle[buttonIndex] = Mathf.Approximately(currentRotation, 0f) || Mathf.Approximately(currentRotation, 180f);
                break;

            case 7:
                angle[buttonIndex] = Mathf.Approximately(currentRotation, 270f);
                break;

            case 8:
                angle[buttonIndex] = Mathf.Approximately(currentRotation, 90f) || Mathf.Approximately(currentRotation, 270f);
                break;

            default:
                Debug.LogWarning($"알 수 없는 버튼 인덱스: {buttonIndex}");
                break;
        }
    }

    // 회전 상태를 출력하는 함수
    private void LogRotationState(int buttonIndex)
    {
        float currentRotation = buttonImages[buttonIndex].rectTransform.localEulerAngles.z;

        // 각 버튼에 대한 상태를 콘솔에 출력
        if (Mathf.Approximately(currentRotation, 0f))
        {
            Debug.Log("버튼 " + (buttonIndex + 1) + " 현재 상태: 0도");
        }
        else if (Mathf.Approximately(currentRotation, 90f))
        {
            Debug.Log("버튼 " + (buttonIndex + 1) + " 현재 상태: 90도");
        }
        else if (Mathf.Approximately(currentRotation, 180f))
        {
            Debug.Log("버튼 " + (buttonIndex + 1) + " 현재 상태: 180도");
        }
        else if (Mathf.Approximately(currentRotation, 270f))
        {
            Debug.Log("버튼 " + (buttonIndex + 1) + " 현재 상태: 270도");
        }
        else
        {
            Debug.Log($"버튼 {buttonIndex + 1} 현재 상태: {currentRotation}도 (알 수 없는 상태)");
        }
    }
}
