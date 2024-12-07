using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sliding2 : MonoBehaviour
{
    public static sliding2 instance3;

    public Transform leftDoor; // 왼쪽 문 큐브
    public Transform rightDoor; // 오른쪽 문 큐브
    public float openDistance = 2.0f; // 문이 열리는 거리
    public float speed = 2.0f; // 열리고 닫히는 속도
    public float openDuration = 3.0f; // 열림 상태 유지 시간

    private Vector3 leftDoorClosedLocalPosition;
    private Vector3 rightDoorClosedLocalPosition;
    private bool isOpening = false;
    private bool isClosing = false;

    public bool playerTrigger = false;

    public AudioSource openSound;
    public AudioSource closeSound;
    private void Awake()
    {
        // 싱글톤 패턴 구현
        if (instance3 == null)
        {
            instance3 = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        // 초기 로컬 위치 저장
        leftDoorClosedLocalPosition = leftDoor.localPosition;
        rightDoorClosedLocalPosition = rightDoor.localPosition;
    }

    void Update()
    {
        OpenEv();
    }
    public void OpenEv()
    {
        if (playerTrigger)
        {
            Open();
            playerTrigger = false;
        }

        if (isOpening)
        {
            OpenDoors();
        }
        else if (isClosing)
        {
            CloseDoors();
        }
    }

    public void Open()
    {
        if (!isOpening && !isClosing)
        {
            isOpening = true;
            isClosing = false;

            // 문 열림 소리 재생
            if (openSound != null)
                openSound.Play();

            StartCoroutine(CloseAfterDelay());
        }
    }

    private IEnumerator CloseAfterDelay()
    {
        yield return new WaitForSeconds(openDuration);
        Close();
    }

    public void Close()
    {
        if (!isOpening && !isClosing)
        {
            isClosing = true;
            isOpening = false;

            // 문 닫힘 소리 재생
            if (closeSound != null)
                closeSound.Play();
        }
    }

    private void OpenDoors()
    {
        // 로컬 좌표계 기준으로 문을 열기
        leftDoor.localPosition = Vector3.MoveTowards(leftDoor.localPosition, leftDoorClosedLocalPosition + new Vector3(openDistance, 0, 0), speed * Time.deltaTime);
        rightDoor.localPosition = Vector3.MoveTowards(rightDoor.localPosition, rightDoorClosedLocalPosition - new Vector3(openDistance, 0, 0), speed * Time.deltaTime);

        // 목표 위치에 도달하면 멈춤
        if (Vector3.Distance(leftDoor.localPosition, leftDoorClosedLocalPosition + new Vector3(openDistance, 0, 0)) < 0.01f &&
            Vector3.Distance(rightDoor.localPosition, rightDoorClosedLocalPosition - new Vector3(openDistance, 0, 0)) < 0.01f)
        {
            isOpening = false;
        }
    }

    private void CloseDoors()
    {
        // 로컬 좌표계 기준으로 문을 닫기
        leftDoor.localPosition = Vector3.MoveTowards(leftDoor.localPosition, leftDoorClosedLocalPosition, speed * Time.deltaTime);
        rightDoor.localPosition = Vector3.MoveTowards(rightDoor.localPosition, rightDoorClosedLocalPosition, speed * Time.deltaTime);

        // 목표 위치에 도달하면 멈춤
        if (Vector3.Distance(leftDoor.localPosition, leftDoorClosedLocalPosition) < 0.01f &&
            Vector3.Distance(rightDoor.localPosition, rightDoorClosedLocalPosition) < 0.01f)
        {
            isClosing = false;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerTrigger = true;
        }
    }
}
