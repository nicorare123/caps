using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class screenfade : MonoBehaviour
{
   
    public GameObject fadePanel;  // 화면 어두워지는 Panel
    public float fadeSpeed = 1.0f; // 암전 속도 조절
    private bool isFading = false;

    private Image panelImage;  // Panel의 Image 컴포넌트
   
   
    void Start()
    {
        FadeToBlack();  // 화면을 암전시킴
      
        // Panel의 Image 컴포넌트를 가져오기
        if (fadePanel != null)
        {
            panelImage = fadePanel.GetComponent<Image>();
            if (panelImage != null)
            {
                panelImage.color = new Color(0, 0, 0, 0); // Panel 초기화: 투명
            }
        }
        
    }

    void Update()
    {
        // 화면 암전이 진행 중일 경우
        if (isFading)
        {
            Color currentColor = panelImage.color;
            float newAlpha = Mathf.MoveTowards(currentColor.a, 1f, fadeSpeed * Time.deltaTime);
            panelImage.color = new Color(currentColor.r, currentColor.g, currentColor.b, newAlpha);

            // 화면이 완전히 암전되었으면
            if (newAlpha >= 1f)
            {
                isFading = false; // 암전이 끝났음을 표시
            }
        }
    }

    // 화면을 천천히 암전시키는 함수
    public void FadeToBlack()
    {
        isFading = true;
    }

    // 화면을 천천히 밝게 만드는 함수
    public void FadeToClear()
    {
        isFading = false;
        panelImage.color = new Color(0, 0, 0, 0);  // 알파 값 0으로 초기화
    }
}
