using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class keynumber : MonoBehaviour
{
    private string correctPassword = "1969";  // ���� ��й�ȣ
    private string currentInput = "";         // ���� ����ڰ� �Է��� ��
    public GameObject passwordpanel;
    public GameObject[] door;

    // ���� ��ư Ŭ�� �� ȣ��
    public void AddDigit(string digit)
    {
        if (currentInput.Length < correctPassword.Length) // �Է� ���� ����
        {
            currentInput += digit; // �Է� �߰�
            Debug.Log("���� �Է�: " + currentInput);

            // �Է� �Ϸ� �� Ȯ��
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

    // �Է� Ȯ��
    private void CheckPassword()
    {
        if (currentInput == correctPassword)
        {
            door[0].SetActive(false);
            door[1].SetActive(true);
            Time.timeScale = 1f;
            Debug.Log("����");
            // ���콺�� ����� ����
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;
            passwordpanel.SetActive(false);
            
        }
        else
        {
            Time.timeScale = 1f;
            Debug.Log("����");
            passwordpanel.SetActive(false);
            
        }

        ResetInput(); // �Է� �ʱ�ȭ
    }

    // �Է� �ʱ�ȭ
    private void ResetInput()
    {
        currentInput = "";
        Debug.Log("�Է� �ʱ�ȭ��");
    }
}
