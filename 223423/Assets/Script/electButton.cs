using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class electButton : MonoBehaviour
{
    public bool blue = false;
    public bool red = false;
    public bool yellow = false;
    public bool green = false;
    public bool blue1 = false;
    public bool red1 = false;
    public bool yellow1 = false;
    public bool green1 = false;

    public GameObject[] line;
    public GameObject Electobject;
    public GameObject dialogue;
    public GameObject targetObject; // 콜라이더를 제거할 오브젝트
    public void Blue()
    {
        blue = true;

        red1 = false;
        yellow1 = false;
        green1 = false;
    }
    public void Red()
    {
        red = true;

        blue1 = false;
        yellow1 = false;
        green1 = false;
    }
    public void Yellow()
    {
        yellow = true;

        red1 = false;
        blue1 = false;
        green1 = false;
    }
    public void Green()
    {
        green = true;

        red1 = false;
        yellow1 = false;
        blue1 = false;
    }
    public void Blue1()
    {
        blue1 = true;
    }
    public void Red1()
    {
        red1 = true;
    }
    public void Yellow1()
    {
        yellow1 = true;
    }
    public void Green1()
    {
        green1 = true;
    }

    public void Start()
    {
        if (targetObject == null)
        {
            Debug.LogError("Target Object가 할당되지 않았습니다.");
            return;
        }

        Collider collider = targetObject.GetComponent<Collider>();

        if (collider != null)
        {
            Destroy(collider); // 콜라이더 삭제
            Debug.Log($"Collider removed from {targetObject.name}");
        }
        else
        {
            Debug.LogWarning($"Target Object {targetObject.name}에 Collider가 없습니다.");
        }
    }
    public void Update()
    {
        
        if (blue1 && blue)
        {
            line[0].SetActive(true);
        }
        else if (yellow1 && yellow)
        {
            line[1].SetActive(true);
        }
        else if (red1 && red)
        {
            line[2].SetActive(true);
        }
        else if (green1 && green)
        {
            line[3].SetActive(true);
        }

        if (line[0].activeSelf && line[1].activeSelf && line[2].activeSelf && line[3].activeSelf)// 성공
        {
            Electobject.SetActive(false);
            // 마우스를 숨기고 고정
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;
            Time.timeScale = 1f;

            dialogue.SetActive(true);
            line[4].SetActive(false); // 패널 끄기
            Debug.Log("성공");

        }
        else {
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;

        }
        if (line[4].activeSelf)
        {
            Time.timeScale = 0f;
        }

    }
     

}
