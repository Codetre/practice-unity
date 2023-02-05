using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;  // 8. 클리어 장면으로 넘어가기 위해서.

public class PlayerController : MonoBehaviour
{
    // 1. 외력 작용을 위한 컴포넌트와, 외력 결정 인자들.
    Rigidbody2D rigid2D;
    Animator animator;  // 6. 애니메이션 적용.
    float jumpForce = 680.0f;
    float walkForce = 30.0f;
    float maxWalkSpeed = 2.0f;
    float sensorThreshold = 0.2f;  // 12. 가속도 센서의 좌우 판정을 위한 문턱값.

    void Start()
    {
        // 2. 힘을 가할 컴포넌트 획득.
        this.rigid2D = GetComponent<Rigidbody2D>();
        this.animator = GetComponent<Animator>();
    }

    void Update()
    {
        // 3. 점프한다. 10. 공중에 떠 있는 동안 점프를 금지한다.
        bool validJumpInput = Input.GetKeyDown(KeyCode.Space) || 
                            Input.GetMouseButtonDown(0);
        if (validJumpInput && this.rigid2D.velocity.y == 0)
        {
            // 14. 점프 애니메이션 트리거를 발동시킨다.
            this.animator.SetTrigger("JumpTrigger");

            this.rigid2D.AddForce(transform.up * this.jumpForce);
        }

        // 4. 좌우로 걷는다. 13. 핸드폰 기울임에도 대응할 수 있도록 입력 추가.
        int walkingDirection = 0;
        bool validRightInput = (Input.acceleration.x > this.sensorThreshold) ||
                                Input.GetKey(KeyCode.RightArrow);
        bool validLeftInput = (Input.acceleration.x < -this.sensorThreshold) ||
                                Input.GetKey(KeyCode.LeftArrow);
        if (validRightInput) walkingDirection = 1;
        if (validLeftInput) walkingDirection = -1;

        float speedx = Mathf.Abs(this.rigid2D.velocity.x);
        // TODO (me): 최대 속력을 넘어도 방향 전환은 되게 해야 한다.
        int currentDirection = this.rigid2D.velocity.x > 0 ? 1 : -1;
        if (speedx < this.maxWalkSpeed || currentDirection != walkingDirection)
        {
            this.rigid2D.AddForce(transform.right * walkingDirection * this.walkForce);
        }

        // 5. 걷는 방향에 맞춰 스프라이트 방향도 바뀐다.
        if (walkingDirection != 0)
        {
            transform.localScale = new Vector3(walkingDirection, 1, 1);
        }

        // 7. 플레이어 속도에 맞춰 애니메이션 속도도 바꾼다.
        // 15. 움직임(점프/걷기)별로 애니메이션 속도 조절.
        if (this.rigid2D.velocity.y == 0) // 걷기.
        {
            this.animator.speed = speedx / 2.0f;
        } else  // 점프.
        {
            this.animator.speed = 1.0f;
        }

        // 11. 돌아올 수 없을만큼 아래로 떨어졌다면 게임 재시작.
        float deadLine = -10.0f;
        if (transform.position.y < deadLine)
        {
            SceneManager.LoadScene("GameScene");
        }
    }

    // 9. 깃발과 부딪혔다면 게임을 완수한 것이다.
    void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Goal reached");
        SceneManager.LoadScene("ClearScene");
    }
}
