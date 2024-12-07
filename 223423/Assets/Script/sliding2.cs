using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sliding2 : MonoBehaviour
{
    public static sliding2 instance3;

    public Transform leftDoor; // ���� �� ť��
    public Transform rightDoor; // ������ �� ť��
    public float openDistance = 2.0f; // ���� ������ �Ÿ�
    public float speed = 2.0f; // ������ ������ �ӵ�
    public float openDuration = 3.0f; // ���� ���� ���� �ð�

    private Vector3 leftDoorClosedLocalPosition;
    private Vector3 rightDoorClosedLocalPosition;
    private bool isOpening = false;
    private bool isClosing = false;

    public bool playerTrigger = false;

    public AudioSource openSound;
    public AudioSource closeSound;
    private void Awake()
    {
        // �̱��� ���� ����
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
        // �ʱ� ���� ��ġ ����
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

            // �� ���� �Ҹ� ���
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

            // �� ���� �Ҹ� ���
            if (closeSound != null)
                closeSound.Play();
        }
    }

    private void OpenDoors()
    {
        // ���� ��ǥ�� �������� ���� ����
        leftDoor.localPosition = Vector3.MoveTowards(leftDoor.localPosition, leftDoorClosedLocalPosition + new Vector3(openDistance, 0, 0), speed * Time.deltaTime);
        rightDoor.localPosition = Vector3.MoveTowards(rightDoor.localPosition, rightDoorClosedLocalPosition - new Vector3(openDistance, 0, 0), speed * Time.deltaTime);

        // ��ǥ ��ġ�� �����ϸ� ����
        if (Vector3.Distance(leftDoor.localPosition, leftDoorClosedLocalPosition + new Vector3(openDistance, 0, 0)) < 0.01f &&
            Vector3.Distance(rightDoor.localPosition, rightDoorClosedLocalPosition - new Vector3(openDistance, 0, 0)) < 0.01f)
        {
            isOpening = false;
        }
    }

    private void CloseDoors()
    {
        // ���� ��ǥ�� �������� ���� �ݱ�
        leftDoor.localPosition = Vector3.MoveTowards(leftDoor.localPosition, leftDoorClosedLocalPosition, speed * Time.deltaTime);
        rightDoor.localPosition = Vector3.MoveTowards(rightDoor.localPosition, rightDoorClosedLocalPosition, speed * Time.deltaTime);

        // ��ǥ ��ġ�� �����ϸ� ����
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
