using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ItemManual : MonoBehaviour
{
    public Sprite grapeSprite;  // 포도 스프라이트를 할당할 변수
    public Image targetImage;   // 비교할 이미지가 담긴 UI 오브젝트

    // 마우스가 UI 이미지에 들어왔을 때 호출됨
  
    public void Itembutton()
    {
        // 이미지의 스프라이트가 포도 스프라이트와 일치하는지 확인
        if (targetImage != null && targetImage.sprite == grapeSprite)
        {
            Debug.Log("김치");
        }
    }
}
