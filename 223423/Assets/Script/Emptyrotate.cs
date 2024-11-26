using UnityEngine;
using UnityEngine.UI;

public class Emptyrotate : MonoBehaviour
{
    public void RotateButtonImage(Button targetButton)
    {
        // 버튼의 Image 컴포넌트 가져오기
        Image buttonImage = targetButton.GetComponentInChildren<Image>();

        if (buttonImage != null)
        {
            // RectTransform을 기준으로 90도 회전
            buttonImage.rectTransform.Rotate(Vector3.forward, 90f);
        }
        else
        {
            Debug.LogWarning("버튼 내부에 Image 컴포넌트가 없습니다!");
        }
    }
}
