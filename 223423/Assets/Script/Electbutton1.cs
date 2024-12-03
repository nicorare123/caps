using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Electbutton1 : MonoBehaviour
{
    public bool[] angle;  // ��ư ȸ�� ���¸� �����ϴ� �迭
    public Button[] buttons;  // 13���� ��ư �迭
    private Image[] buttonImages;  // �� ��ư�� Image ������Ʈ�� ������ �迭
    public GameObject panel;
    public GameObject rotateobject;

    void Start()
    {
        // ��ư�� ��ư �̹��� ������Ʈ�� �迭�� �Ҵ�
        buttonImages = new Image[buttons.Length];

        for (int i = 0; i < buttons.Length; i++)
        {
            buttonImages[i] = buttons[i].GetComponentInChildren<Image>();  // �� ��ư�� Image ������Ʈ ��������
            if (buttonImages[i] != null)
            {
                // �ʱ� ȸ�� ���� Ȯ��
                LogRotationState(i);
                UpdateAngleStatus(i);  // �ʱ� ���� ������Ʈ
            }
            else
            {
                Debug.LogWarning("��ư " + i + " ���ο� Image ������Ʈ�� �����ϴ�!");
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
        // ������ ��ư�� �̹��� ȸ��
        if (buttonImages[buttonIndex] != null)
        {
            buttonImages[buttonIndex].rectTransform.Rotate(Vector3.forward, 90f);  // 90�� ȸ��
            LogRotationState(buttonIndex);  // ȸ�� ���� ���
            UpdateAngleStatus(buttonIndex);  // angle �迭 ������Ʈ
        }
        else
        {
            Debug.LogWarning("��ư " + buttonIndex + " ���ο� Image ������Ʈ�� �����ϴ�!");
        }
    }

    // ��ư�� ȸ�� ���¿� ���� angle �迭 ������Ʈ
    private void UpdateAngleStatus(int buttonIndex)
    {
        float currentRotation = buttonImages[buttonIndex].rectTransform.localEulerAngles.z;

        // �� ��ư�� ���� Ȯ�� �� angle �迭 ������Ʈ
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
                Debug.LogWarning($"�� �� ���� ��ư �ε���: {buttonIndex}");
                break;
        }
    }

    // ȸ�� ���¸� ����ϴ� �Լ�
    private void LogRotationState(int buttonIndex)
    {
        float currentRotation = buttonImages[buttonIndex].rectTransform.localEulerAngles.z;

        // �� ��ư�� ���� ���¸� �ֿܼ� ���
        if (Mathf.Approximately(currentRotation, 0f))
        {
            Debug.Log("��ư " + (buttonIndex + 1) + " ���� ����: 0��");
        }
        else if (Mathf.Approximately(currentRotation, 90f))
        {
            Debug.Log("��ư " + (buttonIndex + 1) + " ���� ����: 90��");
        }
        else if (Mathf.Approximately(currentRotation, 180f))
        {
            Debug.Log("��ư " + (buttonIndex + 1) + " ���� ����: 180��");
        }
        else if (Mathf.Approximately(currentRotation, 270f))
        {
            Debug.Log("��ư " + (buttonIndex + 1) + " ���� ����: 270��");
        }
        else
        {
            Debug.Log($"��ư {buttonIndex + 1} ���� ����: {currentRotation}�� (�� �� ���� ����)");
        }
    }
}
