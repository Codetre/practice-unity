using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChestnutBurrGenerator : MonoBehaviour
{
    public GameObject chestnutBurrPrefab;
    int force = 2000;
    void Start()
    {
        
    }

    void Update()
    {
        // 1. 탭마다 밤송이 날리기.
        if (Input.GetMouseButtonDown(0))
        {
            GameObject chestnutBurr = Instantiate(chestnutBurrPrefab);
            // 2. 누른 위치에 따라(스크린 좌표 -> 월드 좌표) 다른 각도로 밤송이 날리기.
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            Vector3 worldDir = ray.direction;
            chestnutBurr.GetComponent<ChestnutBurrController>().Shoot(worldDir.normalized * force);
        }
    }
}
