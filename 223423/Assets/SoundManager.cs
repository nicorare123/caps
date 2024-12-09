using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    // 감시할 오브젝트들을 드래그 앤 드롭으로 할당합니다.
    public GameObject[] objectsToWatch;

    void Update()
    {
        // 감시할 모든 오브젝트 중 하나라도 활성화되었는지 확인
        bool shouldPause = false;
        foreach (GameObject obj in objectsToWatch)
        {
            if (obj.activeInHierarchy)
            {
                shouldPause = true;
                break;
            }
        }

        // 활성화 여부에 따라 오디오 정지 또는 재개
        AudioListener.pause = shouldPause;
    }
}
