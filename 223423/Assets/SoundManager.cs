using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    // ������ ������Ʈ���� �巡�� �� ������� �Ҵ��մϴ�.
    public GameObject[] objectsToWatch;

    void Update()
    {
        // ������ ��� ������Ʈ �� �ϳ��� Ȱ��ȭ�Ǿ����� Ȯ��
        bool shouldPause = false;
        foreach (GameObject obj in objectsToWatch)
        {
            if (obj.activeInHierarchy)
            {
                shouldPause = true;
                break;
            }
        }

        // Ȱ��ȭ ���ο� ���� ����� ���� �Ǵ� �簳
        AudioListener.pause = shouldPause;
    }
}
