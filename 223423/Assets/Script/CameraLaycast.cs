using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraLaycast : MonoBehaviour
{
    public float rayDistance = 100f;  // ����ĳ��Ʈ�� �Ÿ� ����
    public float interactionDistance = 5f;  // ��ȣ�ۿ��� ������ �Ÿ� ����
    private Material originalMaterial; // ���� ������Ʈ�� Material ����
    private GameObject lastHighlightedObject; // ���������� ���̶���Ʈ�� ������Ʈ ����
    public Material highlightMaterial; // ���̶���Ʈ�� ���� Material ����

    void FixedUpdate()
    {
        // ����ĳ��Ʈ�� ī�޶��� ���� �������� ��� ���� Ray ����
        Ray ray = new Ray(transform.position, transform.forward);
        RaycastHit hit;

        // ����ĳ��Ʈ�� ����� ������ �ʷϻ����� �׸���
        Debug.DrawRay(ray.origin, ray.direction * rayDistance, Color.green);

        // ����ĳ��Ʈ ���
        if (Physics.Raycast(ray, out hit, rayDistance))
        {
            // �浹�� ������Ʈ�� "Object" �±׸� ���� ���
            if (hit.collider.CompareTag("Object"))
            {
                // �÷��̾�� ������Ʈ ���� �Ÿ� ���
                float distanceToObject = Vector3.Distance(transform.position, hit.collider.gameObject.transform.position);

                // �Ÿ��� ��ȣ�ۿ� �Ÿ� ���� �ִ��� Ȯ��
                if (distanceToObject <= interactionDistance)
                {
                    // ������Ʈ ���̶���Ʈ ����
                    if (lastHighlightedObject != hit.collider.gameObject)
                    {
                        // ������ ���̶���Ʈ�� ������Ʈ�� ������ ���� ���� ����
                        if (lastHighlightedObject != null)
                        {
                            lastHighlightedObject.GetComponent<Renderer>().material = originalMaterial;
                        }

                        // ���ο� ������Ʈ ���̶���Ʈ ����
                        lastHighlightedObject = hit.collider.gameObject;
                        Renderer renderer = lastHighlightedObject.GetComponent<Renderer>();

                        if (renderer != null)
                        {
                            originalMaterial = renderer.material; // ���� Material ����
                            renderer.material = highlightMaterial; // ���̶���Ʈ Material ����
                        }
                    }

                    // F Ű�� ���� �� ��ȣ�ۿ� ����
                    if (Input.GetKeyDown(KeyCode.F))
                    {
                        Debug.Log("��ȣ�ۿ��� ������Ʈ: " + hit.collider.gameObject.name);
                        Debug.Log("��ġ ��ũ��Ʈ�� ����Ǿ����ϴ�!");

                        // �߰� ������ �̰��� ������ �� �ֽ��ϴ�.
                        // ��: hit.collider.gameObject.SetActive(false);
                    }
                }
                else
                {
                    // �÷��̾ ������Ʈ���� �־����� ���̶���Ʈ ����
                    if (lastHighlightedObject != null)
                    {
                        lastHighlightedObject.GetComponent<Renderer>().material = originalMaterial;
                        lastHighlightedObject = null;
                    }
                }
            }
        }
        else
        {
            // ����ĳ��Ʈ�� ������Ʈ�� �浹���� ������ ������ ���̶���Ʈ�� ������Ʈ ����
            if (lastHighlightedObject != null)
            {
                lastHighlightedObject.GetComponent<Renderer>().material = originalMaterial;
                lastHighlightedObject = null;
            }
        }
    }
}

