using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sliding : MonoBehaviour
{
    public Transform leftDoor; // ���� �� ť��
    public Transform rightDoor; // ������ �� ť��
    public float openDistance = 2.0f; // ���� ������ �Ÿ�
    public float speed = 2.0f; // ������ ������ �ӵ�
    public float openDuration = 3.0f; // ���� ���� ���� �ð�

    private Vector3 leftDoorClosedPosition;
    private Vector3 rightDoorClosedPosition;
    private bool isOpening = false;
    private bool isClosing = false;

    void Start()
    {
        // �ʱ� ��ġ ����
        leftDoorClosedPosition = leftDoor.position;
        rightDoorClosedPosition = rightDoor.position;

        // ���� ���� �� �� ����
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

            // ���� ���¸� ������ �� �������� Ÿ�̸� ����
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
        // ���ʰ� ������ ���� ������ ��ġ�� �̵�
        leftDoor.position = Vector3.MoveTowards(leftDoor.position, leftDoorClosedPosition - new Vector3(openDistance, 0, 0), speed * Time.deltaTime);
        rightDoor.position = Vector3.MoveTowards(rightDoor.position, rightDoorClosedPosition + new Vector3(openDistance, 0, 0), speed * Time.deltaTime);

        // ��ǥ ��ġ�� �����ϸ� ����
        if (Vector3.Distance(leftDoor.position, leftDoorClosedPosition - new Vector3(openDistance, 0, 0)) < 0.01f &&
            Vector3.Distance(rightDoor.position, rightDoorClosedPosition + new Vector3(openDistance, 0, 0)) < 0.01f)
        {
            isOpening = false;
        }
    }

    private void CloseDoors()
    {
        // ���ʰ� ������ ���� ������ ��ġ�� �̵�
        leftDoor.position = Vector3.MoveTowards(leftDoor.position, leftDoorClosedPosition, speed * Time.deltaTime);
        rightDoor.position = Vector3.MoveTowards(rightDoor.position, rightDoorClosedPosition, speed * Time.deltaTime);

        // ��ǥ ��ġ�� �����ϸ� ����
        if (Vector3.Distance(leftDoor.position, leftDoorClosedPosition) < 0.01f &&
            Vector3.Distance(rightDoor.position, rightDoorClosedPosition) < 0.01f)
        {
            isClosing = false;
        }
    }
}
