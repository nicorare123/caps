using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class colorlight : MonoBehaviour
{
    public Light directionalLight; // Directional Light ����
    public float targetIntensity = 2.0f; // ��ǥ Intensity ��
    public float duration = 1.0f; // ��ȭ�� �ɸ��� �ð� (��)

    private float initialIntensity;
    private float timer;

    void Start()
    {
        if (directionalLight == null)
        {
            Debug.LogWarning("Directional Light�� �Ҵ���� �ʾҽ��ϴ�. �ڵ����� ù ��° Directional Light�� ã���ϴ�.");
            directionalLight = FindObjectOfType<Light>(); // ù ��° Light�� ã��
        }

        if (directionalLight != null)
        {
            initialIntensity = directionalLight.intensity; // �ʱ� Intensity ����
        }
        else
        {
            Debug.LogError("Directional Light�� ã�� �� �����ϴ�.");
        }
    }

    void Update()
    {
        if (directionalLight == null) return;

        // Intensity ���� ���������� ������Ŵ
        if (timer < duration)
        {
            timer += Time.deltaTime;
            directionalLight.intensity = Mathf.Lerp(initialIntensity, targetIntensity, timer / duration);
        }
    }
}
