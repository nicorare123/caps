using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public Text messageText;  // ����� UI �ؽ�Ʈ
    public bool condition = false;  // ������ �����ϴ� ����
    public GameObject TextUI;

    private void Awake()
    {
        // �̱��� ���� ����
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
            // ������ true��� �ؽ�Ʈ�� ����ϰ� ������� ����
            StartCoroutine(DisplayText());
            condition = false;
        }
    }

    private IEnumerator DisplayText()
    {
        // �ؽ�Ʈ ���
        messageText.text = "...���Ⱑ �����Ű���.";

        // 3�� ���
        yield return new WaitForSeconds(3f);

        // �ؽ�Ʈ�� �� ���ڿ��� �����Ͽ� �ؽ�Ʈ�� ������� ��
        messageText.text = "";

        TextUI.SetActive(false);
    }
}
