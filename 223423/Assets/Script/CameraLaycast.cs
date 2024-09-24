using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraLaycast : MonoBehaviour
{
    public float rayDistance = 100f;  // 레이캐스트의 거리 설정

    void Update()
    {
        // 레이캐스트를 카메라의 전방 방향으로 쏘기 위해 Ray 생성
        Ray ray = new Ray(transform.position, transform.forward);
        RaycastHit hit;

        // 레이캐스트의 디버그 라인을 초록색으로 그리기
        Debug.DrawRay(ray.origin, ray.direction * rayDistance, Color.green);

        // 레이캐스트 쏘기
        if (Physics.Raycast(ray, out hit, rayDistance))
        {
            if (Input.GetKeyDown(KeyCode.F))
            {
                // 충돌한 오브젝트가 "Object" 태그를 가진 경우
                if (hit.collider.CompareTag("Object"))
                {
                    // 김치 스크립트 실행
                    Debug.Log("김치 스크립트가 실행되었습니다!");

                    // 추가 동작을 이곳에 정의할 수 있습니다.
                    // 예: hit.collider.gameObject.SetActive(false);
                }
            }
        }
    }

}
