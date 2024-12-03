using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Playercon : MonoBehaviour
{
    public screenfade fadeScript;

    public float speed = 5.0f;
    public float runSpeed = 10.0f;
    public float jumpForce = 2.0f;
    public float gravity = 9.81f;
    public float groundCheckDistance = 0.2f;
    public float mouseSensitivity = 300.0f;
    public Transform playerCamera;
    public Vector3 startPosition;
    public Vector3 usbPostition;

    private CharacterController controller;
    private Vector3 moveDirection = Vector3.zero;
    private float xRotation = 0f;

    private bool isGrounded;
    public LayerMask groundMask;

    private Vector3 originalScale;
    private bool isShrinking = false;
    private bool isBlockedAbove = false;

    public Transform[] targetPosition; // �̵��� ������
    private bool isNearDoor = false; // ���� ������� ���θ� Ȯ���ϴ� ����
    private bool isNearDoor1 = false;

    public Vector3 resetPosition;

    public GameObject fadeobject;

    public GameObject Escpanel;

    public bool[] isportal;
    public GameObject usbobject;


    void Start()
    {
        controller = GetComponent<CharacterController>();
        originalScale = transform.localScale;
        targetPosition[3].position = startPosition;
        
    }

    void Update()
    {
        MovePlayer();
        RotatePlayer();
        GroundCheck();
        CheckForObstacleAbove();

        

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Time.timeScale = 0f;
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
            Escpanel.SetActive(true);
           



        }
        if (Input.GetKey(KeyCode.C))
        {
            if (!isShrinking)
            {
                transform.localScale = new Vector3(originalScale.x, originalScale.y / 2, originalScale.z);
                isShrinking = true;
            }
        }
        else
        {
            if (isShrinking && !isBlockedAbove)
            {
                transform.localScale = originalScale;
                isShrinking = false;
            }
        }

       
    }
    private void FixedUpdate()
    {
        // ���� ������ ���� �� "E" Ű�� ������ ������ ��ġ�� �̵�
        if (isNearDoor && Input.GetKeyDown(KeyCode.F))
        {
            MoveToTargetPosition();
            
        }
        if (isNearDoor1 && Input.GetKeyDown(KeyCode.F)) //1�� ���
        {
            MoveToTargetPosition1();

        }
        else if (CameraLaycast.instance1.iscardkey1)
        {
            MoveToTargetPosition2();
            CameraLaycast.instance1.iscardkey1 = false;
        }
        if (isportal[0])
        {
            MoveToTargetPosition3();
            isportal[0] = false;

        }
        else if (isportal[1])
        {
            MoveToTargetPosition4();
            isportal[1] = false;
        }

    }

    void MovePlayer()
    {
        float moveSpeed = Input.GetKey(KeyCode.LeftShift) ? runSpeed : speed;
        Vector3 move = transform.right * Input.GetAxis("Horizontal") + transform.forward * Input.GetAxis("Vertical");
        moveDirection.x = move.x * moveSpeed;
        moveDirection.z = move.z * moveSpeed;

        if (isGrounded && Input.GetButtonDown("Jump"))
        {
            moveDirection.y = jumpForce;
        }
        else if (!isGrounded)
        {
            moveDirection.y -= gravity * Time.deltaTime;
        }

        controller.Move(moveDirection * Time.deltaTime);
    }

    void RotatePlayer()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        transform.Rotate(Vector3.up * mouseX);
        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);
        playerCamera.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
    }

    void GroundCheck()
    {
        RaycastHit hit;
        Vector3 rayOrigin = transform.position + Vector3.down * (controller.height / 2);
        isGrounded = Physics.Raycast(rayOrigin, Vector3.down, out hit, groundCheckDistance, groundMask);
        Debug.DrawRay(rayOrigin, Vector3.down * groundCheckDistance, Color.red);
    }

    void CheckForObstacleAbove()
    {
        float rayDistance = originalScale.y / 2 + 0.1f;
        RaycastHit hit;
        isBlockedAbove = Physics.Raycast(transform.position, Vector3.up, out hit, rayDistance);
        Debug.DrawRay(transform.position, Vector3.up * rayDistance, Color.green);
    }

    void MoveToTargetPosition()
    {
        if (targetPosition != null)
        {
            transform.position = targetPosition[0].position;
        }
    }
    void MoveToTargetPosition1()
    {
        if (targetPosition != null)
        {
            transform.position = targetPosition[1].position;
        }
    }
    void MoveToTargetPosition2()
    {
        if (targetPosition != null)
        {
            transform.position = targetPosition[2].position;
        }
    }
    void MoveToTargetPosition3() //��Ż3��
    {
        if (targetPosition != null)
        {
            transform.position = targetPosition[4].position;
        }
    }
    void MoveToTargetPosition4()
    {
        if (targetPosition != null)
        {
            transform.position = targetPosition[5].position;
        }
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Door"))
        {
            isNearDoor = true; // ���� ����������� ǥ��
        }
        else if (other.CompareTag("Door1"))
        {
            isNearDoor1 = true; // ���� ����������� ǥ��
        }
        else if (other.CompareTag("Laser"))
        {   if (usbobject.activeSelf)
            {
                // CharacterController ��Ȱ��ȭ �� ��ġ �̵�
                controller.enabled = false;
                transform.position = startPosition;
                controller.enabled = true;
            }
            else if (!usbobject.activeSelf)
            {
                controller.enabled = false;
                transform.position = usbPostition;
                controller.enabled = true;
            }
        }
        else if (other.CompareTag("Portal3f"))
        {
            isportal[0] = true;
            


        }
        else if (other.CompareTag("Portal4f"))
        {
            if (!usbobject.activeSelf)
            {
                Debug.Log("�̵�����");
                isportal[1] = true;
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Door"))
        {
            isNearDoor = false; // ������ �־������� ǥ��
        }
        else if(other.CompareTag("Door1"))
        {
            isNearDoor1 = false; // ������ �־������� ǥ��
        }
        

    }
    private IEnumerator ActivateTemporarily()
    {
        // ������Ʈ Ȱ��ȭ
        fadeobject.SetActive(true);

        // ������ �ð� ���� ���
        yield return new WaitForSeconds(3f);

        // ������Ʈ ��Ȱ��ȭ
        fadeobject.SetActive(false);
    }

}
