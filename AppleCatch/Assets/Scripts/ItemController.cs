using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemController : MonoBehaviour
{
    // 1. 낙하 속도와 오브젝트를 파괴할 Y축 높이 결정.
    public float dropSpeed = 0.03f;
    float lowerLimit = -1.0f;

    void Start()
    {
        
    }

    void Update()
    {
        // 2. 물체를 낙하시키고, 일정 높이 아래에서는 메모리에서 해제한다.
        transform.Translate(0, -this.dropSpeed, 0);    
        if (transform.position.y < this.lowerLimit)
        {
            Destroy(gameObject);
        }
    }
}
