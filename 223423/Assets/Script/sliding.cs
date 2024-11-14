using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sliding : MonoBehaviour
{
    public Transform leftDoor; // 왼쪽 문 큐브
    public Transform rightDoor; // 오른쪽 문 큐브
    public float openDistance = 2.0f; // 문이 열리는 거리
    public float speed = 2.0f; // 열리고 닫히는 속도
    public float openDuration = 3.0f; // 열림 상태 유지 시간

    private Vector3 leftDoorClosedPosition;
    private Vector3 rightDoorClosedPosition;
    private bool isOpening = false;
    private bool isClosing = false;

    bool playertriger = false;

    public AudioSource openSound;
    public AudioSource closeSound;

    void Start()
    {
        // 초기 위치 저장
        leftDoorClosedPosition = leftDoor.position;
        rightDoorClosedPosition = rightDoor.position;

      
    }

    void Update()
    {
        if (playertriger)
        {
            Open();
            //문열리는소리재생
            playertriger = false;
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
        // 왼쪽과 오른쪽 문을 열리는 위치로 이동
        leftDoor.position = Vector3.MoveTowards(leftDoor.position, leftDoorClosedPosition - new Vector3(openDistance, 0, 0), speed * Time.deltaTime);
        rightDoor.position = Vector3.MoveTowards(rightDoor.position, rightDoorClosedPosition + new Vector3(openDistance, 0, 0), speed * Time.deltaTime);

        // 목표 위치에 도달하면 멈춤
        if (Vector3.Distance(leftDoor.position, leftDoorClosedPosition - new Vector3(openDistance, 0, 0)) < 0.01f &&
            Vector3.Distance(rightDoor.position, rightDoorClosedPosition + new Vector3(openDistance, 0, 0)) < 0.01f)
        {
            isOpening = false;
        }
    }

    private void CloseDoors()
    {
        // 왼쪽과 오른쪽 문을 닫히는 위치로 이동
        leftDoor.position = Vector3.MoveTowards(leftDoor.position, leftDoorClosedPosition, speed * Time.deltaTime);
        rightDoor.position = Vector3.MoveTowards(rightDoor.position, rightDoorClosedPosition, speed * Time.deltaTime);

        // 목표 위치에 도달하면 멈춤
        if (Vector3.Distance(leftDoor.position, leftDoorClosedPosition) < 0.01f &&
            Vector3.Distance(rightDoor.position, rightDoorClosedPosition) < 0.01f)
        {
            isClosing = false;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playertriger = true;
        }
    }
}
