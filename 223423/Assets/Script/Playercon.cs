using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Playercon : MonoBehaviour
{
    public float speed = 5.0f;  // 기본 이동 속도
    public float runSpeed = 10.0f;  // 달리기 속도
    public float jumpForce = 2.0f;  // 점프 힘
    public float gravity = 9.81f;  // 중력 값
    public float groundCheckDistance = 0.2f;  // 지면 체크 거리
    public float mouseSensitivity = 300.0f;  // 마우스 감도
    public Transform playerCamera;  // 플레이어 카메라

    private CharacterController controller;
    private Vector3 moveDirection = Vector3.zero;
    private float xRotation = 0f;

    // 지면 감지 관련 변수
    private bool isGrounded;
    public LayerMask groundMask;  // 감지할 지면 레이어

    private Vector3 originalScale; // 초기 크기를 저장할 변수
    private bool isShrinking = false; // 축소 상태를 저장할 변수
    private bool isBlockedAbove = false;  // 위에 물체가 있는지 여부를 저장할 변수

    void Start()
    {
        controller = GetComponent<CharacterController>();

        // 오브젝트의 초기 크기를 저장
        originalScale = transform.localScale;
    }

    void Update()
    {
        // 플레이어 이동 및 회전 처리
        MovePlayer();
        RotatePlayer();

        // 땅에 닿아있는지 Raycast로 감지
        GroundCheck();

        // 위에 물체가 있는지 체크하는 함수 호출
        CheckForObstacleAbove();

        // 'C' 키가 눌러져 있으면
        if (Input.GetKey(KeyCode.C))
        {
            // Y축 크기를 반으로 줄이기
            if (!isShrinking)
            {
                transform.localScale = new Vector3(originalScale.x, originalScale.y / 2, originalScale.z);
                isShrinking = true;
            }
        }
        else
        {
            // 'C' 키가 떼어지면, 위에 물체가 없을 경우에만 원래 크기로 돌아오기
            if (isShrinking && !isBlockedAbove)
            {
                transform.localScale = originalScale;
                isShrinking = false;
            }
        }
    }

    void MovePlayer()
    {
        // 달리기 기능을 위해 좌우 이동 속도 결정
        float moveSpeed = Input.GetKey(KeyCode.LeftShift) ? runSpeed : speed;

        // 수평 이동 입력 처리 (WASD 키 입력에 따라)
        Vector3 move = transform.right * Input.GetAxis("Horizontal") + transform.forward * Input.GetAxis("Vertical");
        moveDirection.x = move.x * moveSpeed;
        moveDirection.z = move.z * moveSpeed;

        // 점프 처리: 땅에 닿아있을 때만 점프 가능
        if (isGrounded && Input.GetButtonDown("Jump"))
        {
            moveDirection.y = jumpForce;
        }
        else if (!isGrounded)
        {
            // 공중에 있을 때 중력 적용
            moveDirection.y -= gravity * Time.deltaTime;
        }

        // 캐릭터 컨트롤러로 이동 적용
        controller.Move(moveDirection * Time.deltaTime);
    }

    void RotatePlayer()
    {
        // 마우스 입력에 따른 회전 처리
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        // 플레이어 좌우 회전
        transform.Rotate(Vector3.up * mouseX);

        // 카메라 상하 회전 제한 (-90도에서 +90도 사이)
        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        // 카메라 회전 적용
        playerCamera.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
    }

    void GroundCheck()
    {
        // 플레이어의 발 아래로 Raycast를 쏴서 지면과의 충돌을 감지
        RaycastHit hit;
        Vector3 rayOrigin = transform.position + Vector3.down * (controller.height / 2);

        isGrounded = Physics.Raycast(rayOrigin, Vector3.down, out hit, groundCheckDistance, groundMask);

        // 디버그용: 레이캐스트 시각적으로 표시 (선택 사항)
        Debug.DrawRay(rayOrigin, Vector3.down * groundCheckDistance, Color.red);
    }

    void CheckForObstacleAbove()
    {
        // 캡슐의 머리 위로 Raycast 발사
        float rayDistance = originalScale.y / 2 + 0.1f; // 캡슐의 반 높이 + 약간의 여유
        RaycastHit hit;

        // Ray를 위쪽으로 쏘아 물체가 있는지 확인
        if (Physics.Raycast(transform.position, Vector3.up, out hit, rayDistance))
        {
            isBlockedAbove = true; // 위에 물체가 있으면 true
        }
        else
        {
            isBlockedAbove = false; // 위에 물체가 없으면 false
        }

        // 디버그용: 레이캐스트 시각적으로 표시 (선택 사항)
        Debug.DrawRay(transform.position, Vector3.up * rayDistance, Color.green);
    }
}
