using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class colorlight : MonoBehaviour
{
    public Light directionalLight; // Directional Light 참조
    public float targetIntensity = 2.0f; // 목표 Intensity 값
    public float duration = 1.0f; // 변화에 걸리는 시간 (초)

    private float initialIntensity;
    private float timer;

    void Start()
    {
        if (directionalLight == null)
        {
            Debug.LogWarning("Directional Light가 할당되지 않았습니다. 자동으로 첫 번째 Directional Light를 찾습니다.");
            directionalLight = FindObjectOfType<Light>(); // 첫 번째 Light를 찾음
        }

        if (directionalLight != null)
        {
            initialIntensity = directionalLight.intensity; // 초기 Intensity 저장
        }
        else
        {
            Debug.LogError("Directional Light를 찾을 수 없습니다.");
        }
    }

    void Update()
    {
        if (directionalLight == null) return;

        // Intensity 값을 점진적으로 증가시킴
        if (timer < duration)
        {
            timer += Time.deltaTime;
            directionalLight.intensity = Mathf.Lerp(initialIntensity, targetIntensity, timer / duration);
        }
    }
}
