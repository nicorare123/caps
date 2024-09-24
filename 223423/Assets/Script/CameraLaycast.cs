using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraLaycast : MonoBehaviour
{
    // 플레이어가 상호작용할 수 있는 거리
    public float interactionDistance = 3f;
    // 상호작용 대상 태그 (ex: "Interactable")
    public string interactableTag = "Object";

    void Update()
    {
        // F키를 눌렀는지 확인
        if (Input.GetKeyDown(KeyCode.F))
        {
            // 카메라의 정면을 기준으로 Ray를 쏩니다.
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            // Ray가 상호작용 가능한 물체에 닿는지 확인
            if (Physics.Raycast(ray, out hit, interactionDistance))
            {
                if (hit.collider.CompareTag(interactableTag))
                {
                    // 상호작용 로직 실행
                    InteractWithObject(hit.collider.gameObject);
                }
            }
        }
    }

    void InteractWithObject(GameObject interactableObject)
    {
        // 여기서 원하는 상호작용 내용을 작성하세요.
        Debug.Log(interactableObject.name + "와 상호작용했습니다!");
    }

}
