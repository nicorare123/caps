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

    void Start()
    {
        // 초기 위치 저장
        leftDoorClosedPosition = leftDoor.position;
        rightDoorClosedPosition = rightDoor.position;

        // 게임 시작 시 문 열기
        Open();
    }

    void Update()
    {
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

            // 열림 상태를 유지한 후 닫히도록 타이머 시작
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
}
