using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CameraLaycast : MonoBehaviour
{
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
            else if (hit.collider.CompareTag("Electric1") &&coditionPhone1 &&coditionPhone2) // 전기전선 gamemanager 조건 true
            {

                if (Input.GetKeyDown(KeyCode.F))
                {
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
                    Debug.Log("작동");
                    GameManager.instance.condition[4] = true;
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
            else if (hit.collider.CompareTag("password")) // 비밀번호키
            {

                if (Input.GetKeyDown(KeyCode.F))
                {
                    gimiceobject[2].SetActive(true);
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

