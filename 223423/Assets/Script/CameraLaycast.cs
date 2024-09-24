using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraLaycast : MonoBehaviour
{
    // �÷��̾ ��ȣ�ۿ��� �� �ִ� �Ÿ�
    public float interactionDistance = 3f;
    // ��ȣ�ۿ� ��� �±� (ex: "Interactable")
    public string interactableTag = "Object";

    void Update()
    {
        // FŰ�� �������� Ȯ��
        if (Input.GetKeyDown(KeyCode.F))
        {
            // ī�޶��� ������ �������� Ray�� ���ϴ�.
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            // Ray�� ��ȣ�ۿ� ������ ��ü�� ����� Ȯ��
            if (Physics.Raycast(ray, out hit, interactionDistance))
            {
                if (hit.collider.CompareTag(interactableTag))
                {
                    // ��ȣ�ۿ� ���� ����
                    InteractWithObject(hit.collider.gameObject);
                }
            }
        }
    }

    void InteractWithObject(GameObject interactableObject)
    {
        // ���⼭ ���ϴ� ��ȣ�ۿ� ������ �ۼ��ϼ���.
        Debug.Log(interactableObject.name + "�� ��ȣ�ۿ��߽��ϴ�!");
    }

}
