using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowController : MonoBehaviour
{
    // 1. 낙하 거리 설정.
    float fallAmount = 0.1f;
    float yBound = -5.0f;

    // 4. 플레이어 오브젝트
    GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        this.player = GameObject.Find("player");
    }

    // Update is called once per frame
    void Update()
    {
        // 2. 낙하시킨다.
        transform.Translate(0, -fallAmount, 0);

        // 3. 범위를 벗어나면 메모리에서 해제.
        if (transform.position.y < yBound)
        {
            Destroy(gameObject);
        }

        // 5. 충돌 판정
        Vector2 playerCenter = this.player.transform.position;
        Vector2 arrowCenter = transform.position;
        float distPlayerAndArrow = (playerCenter - arrowCenter).magnitude;
        float playerRadius = 1.0f;
        float arrowRadius = 0.5f;

        // 6. 충돌 처리
        if (distPlayerAndArrow <= arrowRadius + playerRadius)
        {
            Destroy(gameObject);

            // 7. HP를 깎는다.
            GameObject director = GameObject.Find("GameDirector");
            director.GetComponent<GameDirector>().DecreaseHP();
        }
    }
}
