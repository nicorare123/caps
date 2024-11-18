using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CameraLaycast : MonoBehaviour
{
    public float rayDistance = 100f;  // ����ĳ��Ʈ�� �Ÿ� ����
    public float interactionDistance = 5f;  // ��ȣ�ۿ��� ������ �Ÿ� ����
    private Material originalMaterial; // ���� ������Ʈ�� Material ����
    private GameObject lastHighlightedObject; // ���������� ���̶���Ʈ�� ������Ʈ ����
    public Material highlightMaterial; // ���̶���Ʈ�� ���� Material ����

    public GameObject textUiF;

    private GameObject InteractiveObject;
    public InventoryManager inventoryManager;

    public GameObject[] gimiceobject; // ��͵�

    bool coditionPhone1=false;
    bool coditionPhone2 = false;
    public GameObject[] activeobject; // [0]��ȭ�� ��

    public void Start()
    {
        textUiF.SetActive(false);
    }
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
                    
                    GameManager.instance.condition[0] = true;
                     coditionPhone1 = true;
                }
            }
            else if (hit.collider.CompareTag("Phone1")) // ��ȭ�⴩���� gamemanager ���� true
            {

                if (Input.GetKeyDown(KeyCode.F)&&coditionPhone1)
                {
                    GameManager.instance.condition[1] = true;
                    coditionPhone2 = true;
                }
            }
            else if (hit.collider.CompareTag("Phone2")) // ��ȭ�⴩���� gamemanager ���� true
            {

                if (Input.GetKeyDown(KeyCode.F))
                {
                    GameManager.instance.condition[2] = true;
                }
            }
            else if (hit.collider.CompareTag("Electric1") &&coditionPhone1 &&coditionPhone2) // �������� gamemanager ���� true
            {

                if (Input.GetKeyDown(KeyCode.F))
                {
                    gimiceobject[0].SetActive(true); //����̴ϰ��� ����
                    activeobject[0].SetActive(true); // ��ȭ�� Ȱ��ȭ
                    activeobject[1].SetActive(false); // ���� ��ȭ�� ��Ȱ��ȭ
                }
            }
            else if (hit.collider.CompareTag("Ebutton")) // �������� gamemanager ���� true&& coditionPhone1 && coditionPhone2
            {

                if (Input.GetKeyDown(KeyCode.F))
                {
                    Debug.Log("�۵�");
                    GameManager.instance.condition[3] = true;
                }
            }
            else if (hit.collider.CompareTag("Eopen")) // �������� gamemanager ���� true&& coditionPhone1 && coditionPhone2
            {

                if (Input.GetKeyDown(KeyCode.F))
                {
                    Debug.Log("����������");
                    sliding.instance1.playerTrigger = true;
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

