```C#
/* 이 객체는 Scene의 스프라이트의 내부 로직을 결정한다.
 * 스프라이트가 껍데기라면 그와 연결된 스크립트 객체는 영혼인 셈
 */
public class GameDirector : MonoBehaviour {
    void Start() {}  // 게임 최초 실행 시 1회만 실행되는 메서드.
    void Update() {}  // 매 프레임마다 실행되는 메서드.
}
```
- `public` 접근 제어자로 설정된 객체는 Inspecpector에 노출된다.
- (x, y)를 나타내는 벡터 데이터형: `Vector2`
    - property: `x`, `y`
    - `new Vector2(0.1f, 3.5f)`
UI 오브젝트 사용을 위한 전제: `using UnityEngine.UI;`

- 입력 장치:
    - 마우스 버튼 종류 `0`: 왼쪽, `1`: 오른쪽, `2`: 휠로 나뉜다.
    * 눌림이 최초 감지된 프레임 동안만: `Input.GetMouseButtonDown`
    * 뗌이 최초 감지된 프레임 동안만: `Input.GetMouseButtonUp`
    * 누르고 있는 매 프레임 동안: `Input.GetMouseButton`
    - 입력 이벤트가 발생한 위치: `Vector2 pos = Input.mousePosition`

- 움직임(Transform)
    - 회전:` transform.Rotate(0, 0, this.rotSpeed)`
    - 평행 이동: `transform.Translate(this.speed, 0, 0)`
    - 스프라이트 scale: `transform.localScale` in `Vector3` type.
    - 방향: `transform.up` in `Vector3` type.

- 오브젝트
    - 오브젝트를 위한 데이터 타입: `GameObject car;`
    - Scene에 올라온 오브젝트 찾기: `this.car = GameObject.Find("car");`

- 컴포넌트
    - 컴포넌트 참조 얻기: `GetComponent<component>()`
    - Transform 컴포넌트는 자주 쓰이므로 특별히 `transform`이란 참조가 예약돼 있다.

- Scene
    - 시작: `using UnityEngine.SceneManagement`
    - 장면 불러오기: `SceneManager.LoadScene("SceneName");`

- Physics
    - 외력 작용 Physics 컴포넌트
        - 오브젝트에 조립한 컴포넌트 참조 얻기: `GetComponent<Rididbody2D>()`
        - 외력 작용: `rigid2DComp.AddForce(vector2DForce)`
        - 현재 속력: `rigid2DComp.velocity`
            - prop: `x`, `y`
    - 충돌 판정 Physics 컴포넌트
        - 오브젝트에 조립한 컴포넌트 참조 얻기: `GetComponent<Collider2D>()`
        - 충돌 이벤트 트리거: 인터페이스 `OnTriggerEnter2D(Collider2D other)`을 정의한다.
            - 그외 인터페이스(`Collision` 부분을 `Trigger`로 바꿔도 성립): 
                - 충돌 시작 순간: `OnCollisionEnter2D`
                - 충돌 동안: `OnCollisionStay2D`
                - 충돌 끝난 순간: `OnCollisionExit2D` 
            - 

- 애니메이션:
    - `GetComponent<Animator>()`
    - 애니메이션 진행 속력: `animatorComp.speed` in `float` type.
    - 트리거(다른 애니메이션으로 전환 시점) 설정: `animatorComp.SetTrigger("TriggerName")`

- 수학:
    - 절대값: `Mathf.Abs(scalar)`