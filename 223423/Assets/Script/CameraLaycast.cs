using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CameraLaycast : MonoBehaviour
{
    public static CameraLaycast instance1;


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

    public bool iscardkey = false; // ī��Ű �������ִ���
    public bool iscardkey1 = false; // ī��Ű ����Ұ���
    public bool isbattery = false;

    public GameObject nomalending;

    public bool nonemouse = true;
    public bool isusb = false;
    public GameObject rotateobject;
    public GameObject phoneend;

    public GameObject[] Phonechange;

    public GameObject setactivebuttonobject;
    private void Awake()
    {
        // ���콺�� ����� ����
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        // �̱��� ����
        if (instance1 == null)
        {
            instance1 = this;
        }
        else
        {
            Debug.LogWarning("A�� �ν��Ͻ��� �̹� �����մϴ�! �ߺ� ����.");
            Destroy(gameObject);
        }
    }

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
            else if (hit.collider.CompareTag("Phone3")) // �������� gamemanager ���� true&& coditionPhone1 && coditionPhone2
            {

                if (Input.GetKeyDown(KeyCode.F))
                {
                    if (rotateobject.activeSelf)
                    {
                        Debug.Log("���");
                        nomalending.SetActive(true);
                    }
                }


            }
            else if (hit.collider.CompareTag("Phone4")) // ���翣��
            {

                if (Input.GetKeyDown(KeyCode.F))
                {
                    phoneend.SetActive(true);
                }


            }
            else if (hit.collider.CompareTag("Electric1") &&coditionPhone1 &&coditionPhone2) // �������� gamemanager ���� true
            {

                if (Input.GetKeyDown(KeyCode.F))
                { // ���콺�� ����� ����
                    Cursor.visible = true;
                    Cursor.lockState = CursorLockMode.None;
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
            else if (hit.collider.CompareTag("Ebutton1")) // �������� gamemanager ���� true&& coditionPhone1 && coditionPhone2
            {

                if (Input.GetKeyDown(KeyCode.F))
                {
                    if (!iscardkey)
                    {
                        Debug.Log("�۵�");
                        GameManager.instance.condition[4] = true;
                    }
                    else if (iscardkey)// �����̵�
                    {
                        Debug.Log("�����̵�");
                        iscardkey1 = true;
                        iscardkey = false;
                    }
                   
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
            else if (hit.collider.CompareTag("Eopen1")) // �������� gamemanager ���� true&& coditionPhone1 && coditionPhone2
            {

                if (Input.GetKeyDown(KeyCode.F))
                {
                    Debug.Log("����������");
                    sliding1.instance2.playerTrigger = true;
                }
            }
            else if (hit.collider.CompareTag("Eopen2")) // �������� gamemanager ���� true&& coditionPhone1 && coditionPhone2
            {

                if (Input.GetKeyDown(KeyCode.F))
                {
                    Debug.Log("����������");
                    sliding2.instance3.playerTrigger = true;
                }
            }
            else if (hit.collider.CompareTag("password")) // ��й�ȣŰ // ���콺ó��
            {

                if (Input.GetKeyDown(KeyCode.F))
                { // ���콺�� ����� ����
                    Cursor.visible = true;
                    Cursor.lockState = CursorLockMode.None;
                    gimiceobject[2].SetActive(true);
                    
                }
            }
            else if (hit.collider.CompareTag("Card")) // ��й�ȣŰ
            {

                if (Input.GetKeyDown(KeyCode.F))
                {
                    gimiceobject[3].SetActive(false);
                    iscardkey = true;
                }
            }
            else if (hit.collider.CompareTag("Battery")) // ���͸�
            {

                if (Input.GetKeyDown(KeyCode.F))
                {
                    gimiceobject[4].SetActive(false);
                    isbattery = true;
                }
            }
            else if (hit.collider.CompareTag("Connet")) // ���͸�
            {

                if (Input.GetKeyDown(KeyCode.F)&&!isbattery) // ���͸� ������
                {
                   
                }
                if (Input.GetKeyDown(KeyCode.F) && isbattery) // ���͸� ������
                {

                    Cursor.visible = true;
                    Cursor.lockState = CursorLockMode.None;
                    gimiceobject[5].SetActive(true);
                    gimiceobject[6].SetActive(true);// ������ ��� ui Ȱ��ȭ 
                    gimiceobject[7].SetActive(true);

                }
               
            }
            else if (hit.collider.CompareTag("USB")) // USB
            {

                if (Input.GetKeyDown(KeyCode.F) ) 
                {
                    gimiceobject[8].SetActive(false);
                    isusb = true;

                    Phonechange[0].SetActive(true);
                    Phonechange[1].SetActive(false);

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

