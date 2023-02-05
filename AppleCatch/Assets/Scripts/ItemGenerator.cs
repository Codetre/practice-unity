using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemGenerator : MonoBehaviour
{
    // 1. 생성할 오브젝트에 연결할 프리팹.
    public GameObject applePrefab;
    public GameObject bombPrefab;
    
    // 2. 생성과 관련한 설정들.
    float elapsed = 0;
    int initSpawnHeight = 4;

    // 6. 생성과 관련됐으면서, 레벨 디자인을 위한 설정 변수들.
    float spawnInterval = 1.0f;  // Unit: sec.
    int bombSpwanRate = 3; // 폭탄:사과 = 3:7 비율로 생성.
    float dropSpeed = 0.03f;

    public void SetParams(float spawnInterval, float dropSpeed, int bombSpwanRate)
    {
        this.spawnInterval = spawnInterval;
        this.dropSpeed = dropSpeed;
        this.bombSpwanRate = bombSpwanRate;
    }

    void Start()
    {
            
    }

    void Update()
    {
        // 3. 일정 시간마다 새 낙하 아이템을 생성한다.
        this.elapsed += Time.deltaTime;
        if (this.elapsed > this.spawnInterval)
        {
            // 5. 생성 아이템을 매번 무작위로 결정.
            GameObject item;
            int sel = Random.Range(1, 11);
            if (sel <= bombSpwanRate)
            {
                item = Instantiate(bombPrefab);
            } else
            {
                item = Instantiate(applePrefab);
            }

            // 4. 생성 위치를 매번 무작위로 결정.
            float x = Random.Range(-1, 2);
            float z = Random.Range(-1, 2);
            item.transform.position = new Vector3(x, initSpawnHeight, z);
            item.GetComponent<ItemController>().dropSpeed = this.dropSpeed;
            this.elapsed = 0;
        }
    }
}
