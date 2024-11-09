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

    private GameObject InteractiveObject;
    public InventoryManager inventoryManager;

    public GameObject[] gimiceobject; // ��͵�
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F) && InteractiveObject != null)
        {
            inventoryManager.AddItem(InteractiveObject);
            InteractiveObject.SetActive(false);
            InteractiveObject = null;
        }
    }
    void FixedUpdate()
    {
        CheckObject();
    }

    void CheckObject()
    {
        Ray ray = new Ray(transform.position, transform.forward);
        RaycastHit hit;

        // ����ĳ��Ʈ�� ����� ������ �ʷϻ����� �׸���
        Debug.DrawRay(ray.origin, ray.direction * rayDistance, Color.green);
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
                    InteractiveObject = hit.collider.gameObject;

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
            else if (hit.collider.CompareTag("Phone")) // ��ȭ�⴩���� gamemanager ���� true
            {

                if (Input.GetKeyDown(KeyCode.F))
                {
                    GameManager.instance.condition = true;
                }
            }
            else if (hit.collider.CompareTag("Electric1")) // �������� gamemanager ���� true
            {

                if (Input.GetKeyDown(KeyCode.F))
                {
                    gimiceobject[0].SetActive(true); //����̴ϰ��� ����
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
                InteractiveObject = null;
            }
        }
    }
}

