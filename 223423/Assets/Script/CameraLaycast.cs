using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraLaycast : MonoBehaviour
{
    public float rayDistance = 100f;  // ����ĳ��Ʈ�� �Ÿ� ����

    void Update()
    {
        // ����ĳ��Ʈ�� ī�޶��� ���� �������� ��� ���� Ray ����
        Ray ray = new Ray(transform.position, transform.forward);
        RaycastHit hit;

        // ����ĳ��Ʈ�� ����� ������ �ʷϻ����� �׸���
        Debug.DrawRay(ray.origin, ray.direction * rayDistance, Color.green);

        // ����ĳ��Ʈ ���
        if (Physics.Raycast(ray, out hit, rayDistance))
        {
            if (Input.GetKeyDown(KeyCode.F))
            {
                // �浹�� ������Ʈ�� "Object" �±׸� ���� ���
                if (hit.collider.CompareTag("Object"))
                {
                    // ��ġ ��ũ��Ʈ ����
                    Debug.Log("��ġ ��ũ��Ʈ�� ����Ǿ����ϴ�!");

                    // �߰� ������ �̰��� ������ �� �ֽ��ϴ�.
                    // ��: hit.collider.gameObject.SetActive(false);
                }
            }
        }
    }

}
