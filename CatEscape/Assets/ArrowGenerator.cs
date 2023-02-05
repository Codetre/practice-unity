using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowGenerator : MonoBehaviour
{
    // 1. 
    public GameObject arrowPrefab;
    float span = 1.0f;  // 생성 시간 단위.
    float delta = 0;  // 마지막 생성 이후로 축적된 시간.
    int leftGenBound = -6;  // 인스턴스 생성 x축 좌측 한계
    int rightGenBound = 7;  // 인스턴스 생성 x축 좌측 한계
    int initGenHeight = 7;  // 인스턴스 생성 시 초기 높이.

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // 2. 경과 시간을 쌓는다.
        this.delta += Time.deltaTime;
        if (this.delta > this.span)
        {
            this.delta = 0;
            GameObject arrowInstance = Instantiate(arrowPrefab);
            int px = Random.Range(leftGenBound, rightGenBound);
            arrowInstance.transform.position = new Vector3(px, initGenHeight, 0);
        }       
    }
}
