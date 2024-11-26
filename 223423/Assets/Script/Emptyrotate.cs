using UnityEngine;
using UnityEngine.UI;

public class Emptyrotate : MonoBehaviour
{
    public void RotateButtonImage(Button targetButton)
    {
        // ��ư�� Image ������Ʈ ��������
        Image buttonImage = targetButton.GetComponentInChildren<Image>();

        if (buttonImage != null)
        {
            // RectTransform�� �������� 90�� ȸ��
            buttonImage.rectTransform.Rotate(Vector3.forward, 90f);
        }
        else
        {
            Debug.LogWarning("��ư ���ο� Image ������Ʈ�� �����ϴ�!");
        }
    }
}
