using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class screenfade : MonoBehaviour
{
   
    public GameObject fadePanel;  // ȭ�� ��ο����� Panel
    public float fadeSpeed = 1.0f; // ���� �ӵ� ����
    private bool isFading = false;

    private Image panelImage;  // Panel�� Image ������Ʈ
   
   
    void Start()
    {
        FadeToBlack();  // ȭ���� ������Ŵ
      
        // Panel�� Image ������Ʈ�� ��������
        if (fadePanel != null)
        {
            panelImage = fadePanel.GetComponent<Image>();
            if (panelImage != null)
            {
                panelImage.color = new Color(0, 0, 0, 0); // Panel �ʱ�ȭ: ����
            }
        }
        
    }

    void Update()
    {
        // ȭ�� ������ ���� ���� ���
        if (isFading)
        {
            Color currentColor = panelImage.color;
            float newAlpha = Mathf.MoveTowards(currentColor.a, 1f, fadeSpeed * Time.deltaTime);
            panelImage.color = new Color(currentColor.r, currentColor.g, currentColor.b, newAlpha);

            // ȭ���� ������ �����Ǿ�����
            if (newAlpha >= 1f)
            {
                isFading = false; // ������ �������� ǥ��
            }
        }
    }

    // ȭ���� õõ�� ������Ű�� �Լ�
    public void FadeToBlack()
    {
        isFading = true;
    }

    // ȭ���� õõ�� ��� ����� �Լ�
    public void FadeToClear()
    {
        isFading = false;
        panelImage.color = new Color(0, 0, 0, 0);  // ���� �� 0���� �ʱ�ȭ
    }
}
