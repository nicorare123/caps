using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public Text messageText;  // ����� UI �ؽ�Ʈ
    public bool[] condition ;  // ������ �����ϴ� ���� (��ȭ��)
   
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
            // ������ true��� �ؽ�Ʈ�� ����ϰ� ������� ����
            StartCoroutine(DisplayText());
            condition[0] = false;
        }
        else if (condition[1])
        {
            
                TextUI.SetActive(true);
                // ������ true��� �ؽ�Ʈ�� ����ϰ� ������� ����
                StartCoroutine(DisplayText1());
                condition[1] = false;
            
        }
        else if (condition[2]) // ���⿬���� ��ȭ��
        {

            TextUI.SetActive(true);
            // ������ true��� �ؽ�Ʈ�� ����ϰ� ������� ����
            StartCoroutine(DisplayText2());
            condition[2] = false;

        }
        else if (condition[3]) // 1�� ���� ��ư
        {
            Debug.Log("�۵�11");
            TextUI.SetActive(true);
            // ������ true��� �ؽ�Ʈ�� ����ϰ� ������� ����
            StartCoroutine(DisplayText3());
            condition[3] = false;

        }
        else if (condition[4]) // 1�� ���� ��ư
        {
            Debug.Log("�۵�11");
            TextUI.SetActive(true);
            // ������ true��� �ؽ�Ʈ�� ����ϰ� ������� ����
            StartCoroutine(DisplayText4());
            condition[4] = false;

        }
    }

    private IEnumerator DisplayText()
    {
        // �ؽ�Ʈ ���
        messageText.text = "...���Ⱑ �����Ű���. �ٸ� ��ȭ�⸦ ã�ƺ���";

        // 3�� ���
        yield return new WaitForSeconds(3f);

        // �ؽ�Ʈ�� �� ���ڿ��� �����Ͽ� �ؽ�Ʈ�� ������� ��
        messageText.text = "";

        TextUI.SetActive(false);
    }
    private IEnumerator DisplayText1()
    {
        // �ؽ�Ʈ ���
        messageText.text = "...���Ⱑ �����Ű���11.";

        // 3�� ���
        yield return new WaitForSeconds(3f);

        // �ؽ�Ʈ�� �� ���ڿ��� �����Ͽ� �ؽ�Ʈ�� ������� ��
        messageText.text = "";

        TextUI.SetActive(false);
    }
    private IEnumerator DisplayText2()
    {
        // �ؽ�Ʈ ���
        messageText.text = ".....";

        // 3�� ���
        yield return new WaitForSeconds(3f);

        // �ؽ�Ʈ�� �� ���ڿ��� �����Ͽ� �ؽ�Ʈ�� ������� ��
        messageText.text = "";

        TextUI.SetActive(false);
    }
    private IEnumerator DisplayText3()
    {
        // �ؽ�Ʈ ���
        messageText.text = "�ƹ��� ������ ����..";

        // 3�� ���
        yield return new WaitForSeconds(3f);

        // �ؽ�Ʈ�� �� ���ڿ��� �����Ͽ� �ؽ�Ʈ�� ������� ��
        messageText.text = "";

        TextUI.SetActive(false);
    }
    private IEnumerator DisplayText4()
    {
        // �ؽ�Ʈ ���
        messageText.text = "Űī�尡 �ʿ��ϴ�.";

        // 3�� ���
        yield return new WaitForSeconds(3f);

        // �ؽ�Ʈ�� �� ���ڿ��� �����Ͽ� �ؽ�Ʈ�� ������� ��
        messageText.text = "";

        TextUI.SetActive(false);
    }
}
