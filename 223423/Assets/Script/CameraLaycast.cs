using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CameraLaycast : MonoBehaviour
{
    public static CameraLaycast instance1;


    public float rayDistance = 100f;  // 레이캐스트의 거리 설정
    public float interactionDistance = 5f;  // 상호작용이 가능한 거리 설정
    private Material originalMaterial; // 원래 오브젝트의 Material 저장
    private GameObject lastHighlightedObject; // 마지막으로 하이라이트된 오브젝트 저장
    public Material highlightMaterial; // 하이라이트를 위한 Material 설정

    public GameObject textUiF;

    private GameObject InteractiveObject;
    public InventoryManager inventoryManager;

    public GameObject[] gimiceobject; // 기믹들

    bool coditionPhone1=false;
    bool coditionPhone2 = false;
    public GameObject[] activeobject; // [0]전화기 등

    public bool iscardkey = false; // 카드키 가지고있는지
    public bool iscardkey1 = false; // 카드키 사용할건지
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
        // 마우스를 숨기고 고정
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        // 싱글톤 설정
        if (instance1 == null)
        {
            instance1 = this;
        }
        else
        {
            Debug.LogWarning("A의 인스턴스가 이미 존재합니다! 중복 제거.");
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

        // 레이캐스트의 디버그 라인을 초록색으로 그리기
        Debug.DrawRay(ray.origin, ray.direction * rayDistance, Color.green);
        if (Physics.Raycast(ray, out hit, rayDistance))
        {
            // 충돌한 오브젝트가 "Object" 태그를 가진 경우
            if (hit.collider.CompareTag("Object"))
            {
                // 플레이어와 오브젝트 간의 거리 계산
                float distanceToObject = Vector3.Distance(transform.position, hit.collider.gameObject.transform.position);

                // 거리가 상호작용 거리 내에 있는지 확인
                if (distanceToObject <= interactionDistance)
                {
                    // 오브젝트 하이라이트 적용
                    if (lastHighlightedObject != hit.collider.gameObject)
                    {
                        // 이전에 하이라이트된 오브젝트가 있으면 원래 색상 복원
                        if (lastHighlightedObject != null)
                        {
                            lastHighlightedObject.GetComponent<Renderer>().material = originalMaterial;
                        }

                        // 새로운 오브젝트 하이라이트 적용
                        lastHighlightedObject = hit.collider.gameObject;
                        Renderer renderer = lastHighlightedObject.GetComponent<Renderer>();

                        if (renderer != null)
                        {
                            originalMaterial = renderer.material; // 원래 Material 저장
                            renderer.material = highlightMaterial; // 하이라이트 Material 적용
                        }
                    }
                    InteractiveObject = hit.collider.gameObject;

                }
                else
                {
                    // 플레이어가 오브젝트에서 멀어지면 하이라이트 해제
                    if (lastHighlightedObject != null)
                    {
                        lastHighlightedObject.GetComponent<Renderer>().material = originalMaterial;
                        lastHighlightedObject = null;
                    }
                }
            }
            else if (hit.collider.CompareTag("Phone")) // 전화기누르면 gamemanager 조건 true
            {
                
                if (Input.GetKeyDown(KeyCode.F))
                {
                    
                    GameManager.instance.condition[0] = true;
                     coditionPhone1 = true;
                }
            }
            else if (hit.collider.CompareTag("Phone1")) // 전화기누르면 gamemanager 조건 true
            {

                if (Input.GetKeyDown(KeyCode.F)&&coditionPhone1)
                {
                    GameManager.instance.condition[1] = true;
                    coditionPhone2 = true;
                }
            }
            else if (hit.collider.CompareTag("Phone2")) // 전화기누르면 gamemanager 조건 true
            {

                if (Input.GetKeyDown(KeyCode.F))
                {
                    GameManager.instance.condition[2] = true;
                }
            }
            else if (hit.collider.CompareTag("Phone3")) // 전기전선 gamemanager 조건 true&& coditionPhone1 && coditionPhone2
            {

                if (Input.GetKeyDown(KeyCode.F))
                {
                    if (rotateobject.activeSelf)
                    {
                        Debug.Log("출력");
                        nomalending.SetActive(true);
                    }
                }


            }
            else if (hit.collider.CompareTag("Phone4")) // 히든엔딩
            {

                if (Input.GetKeyDown(KeyCode.F))
                {
                    phoneend.SetActive(true);
                }


            }
            else if (hit.collider.CompareTag("Electric1") &&coditionPhone1 &&coditionPhone2) // 전기전선 gamemanager 조건 true
            {

                if (Input.GetKeyDown(KeyCode.F))
                { // 마우스를 숨기고 고정
                    Cursor.visible = true;
                    Cursor.lockState = CursorLockMode.None;
                    gimiceobject[0].SetActive(true); //전기미니게임 시작
                    activeobject[0].SetActive(true); // 전화기 활성화
                    activeobject[1].SetActive(false); // 기존 전화기 비활성화
                }
            }
            else if (hit.collider.CompareTag("Ebutton")) // 전기전선 gamemanager 조건 true&& coditionPhone1 && coditionPhone2
            {

                if (Input.GetKeyDown(KeyCode.F))
                {
                    Debug.Log("작동");
                    GameManager.instance.condition[3] = true;
                }
            }
            else if (hit.collider.CompareTag("Ebutton1")) // 전기전선 gamemanager 조건 true&& coditionPhone1 && coditionPhone2
            {

                if (Input.GetKeyDown(KeyCode.F))
                {
                    if (!iscardkey)
                    {
                        Debug.Log("작동");
                        GameManager.instance.condition[4] = true;
                    }
                    else if (iscardkey)// 순간이동
                    {
                        Debug.Log("순간이동");
                        iscardkey1 = true;
                        iscardkey = false;
                    }
                   
                }
            }
            else if (hit.collider.CompareTag("Eopen")) // 전기전선 gamemanager 조건 true&& coditionPhone1 && coditionPhone2
            {

                if (Input.GetKeyDown(KeyCode.F))
                {
                    Debug.Log("엘베열리기");
                    sliding.instance1.playerTrigger = true;
                }
            }
            else if (hit.collider.CompareTag("Eopen1")) // 전기전선 gamemanager 조건 true&& coditionPhone1 && coditionPhone2
            {

                if (Input.GetKeyDown(KeyCode.F))
                {
                    Debug.Log("엘베열리기");
                    sliding1.instance2.playerTrigger = true;
                }
            }
            else if (hit.collider.CompareTag("Eopen2")) // 전기전선 gamemanager 조건 true&& coditionPhone1 && coditionPhone2
            {

                if (Input.GetKeyDown(KeyCode.F))
                {
                    Debug.Log("엘베열리기");
                    sliding2.instance3.playerTrigger = true;
                }
            }
            else if (hit.collider.CompareTag("password")) // 비밀번호키 // 마우스처리
            {

                if (Input.GetKeyDown(KeyCode.F))
                { // 마우스를 숨기고 고정
                    Cursor.visible = true;
                    Cursor.lockState = CursorLockMode.None;
                    gimiceobject[2].SetActive(true);
                    
                }
            }
            else if (hit.collider.CompareTag("Card")) // 비밀번호키
            {

                if (Input.GetKeyDown(KeyCode.F))
                {
                    gimiceobject[3].SetActive(false);
                    iscardkey = true;
                }
            }
            else if (hit.collider.CompareTag("Battery")) // 배터리
            {

                if (Input.GetKeyDown(KeyCode.F))
                {
                    gimiceobject[4].SetActive(false);
                    isbattery = true;
                }
            }
            else if (hit.collider.CompareTag("Connet")) // 배터리
            {

                if (Input.GetKeyDown(KeyCode.F)&&!isbattery) // 배터리 없을때
                {
                   
                }
                if (Input.GetKeyDown(KeyCode.F) && isbattery) // 배터리 있을때
                {

                    Cursor.visible = true;
                    Cursor.lockState = CursorLockMode.None;
                    gimiceobject[5].SetActive(true);
                    gimiceobject[6].SetActive(true);// 돌리기 기믹 ui 활성화 
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
                // 레이캐스트가 오브젝트에 충돌하지 않으면 이전에 하이라이트된 오브젝트 복원
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

