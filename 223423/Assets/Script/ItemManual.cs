using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ItemManual : MonoBehaviour
{
    public Sprite grapeSprite;  // ���� ��������Ʈ�� �Ҵ��� ����
    public Image targetImage;   // ���� �̹����� ��� UI ������Ʈ

    // ���콺�� UI �̹����� ������ �� ȣ���
  
    public void Itembutton()
    {
        // �̹����� ��������Ʈ�� ���� ��������Ʈ�� ��ġ�ϴ��� Ȯ��
        if (targetImage != null && targetImage.sprite == grapeSprite)
        {
            Debug.Log("��ġ");
        }
    }
}
