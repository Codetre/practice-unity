- 순서
    1. 오브젝트 배치
        - 플레이어 캐릭터, 구름, 깃발, 배경, 종료 화면 배경
    2. 컨트롤러
        - 움직일 수 있는 오브젝트: 플레이어 캐릭터
            - 플레이어 캐릭터 동작: 좌표를 직접 바꾸는 방식 대신 여기서는 Physics로 외력을 주는 방식으로 위치를 바꾼다.
                - y 좌표가 기준치 이하면 게임 오버로 보고 GameScene을 다시 불러온다.
                - 
                - 점프: space 키 혹은 화면 탭
                    - 점프 도중 재점프할 수 없도록 만든다.
                - 좌우 이동: 좌우 화살표 혹은 화면 기울이기
                    - 좌우 이동 시 스프라이트의 모양도 좌우 반전이 되야 한다.
                - 좌우 이동 애니메이션 작성: 
                    - 애니메이션 클립 최초 작성 시 다음 과정이 자동으로 일어난다.
                        1. 클립 파일 생성
                        2. 컨트롤러 파일 생성
                        3. 생성된 컨트롤러가 Animator 컴포넌트에 등록됨
                        4. 오브젝트에 컴포넌트가 조립됨.
                    1. Window > Animation > Animation 창
                    2. Create로 클립과 컨트롤러 생성. 
                    3. Clip 타임라인 편집: Add Property > Sprite Renderer > Sprite 추가. cat(0.0) -> cat_walk1(0.07) -> cat_walk2(0.14) -> cat_walk3(0.21-0.28)
                    4. 스크립트에서 애니메이션 속도 조절 
                - Position = (0, 0, 0)
                - Physics 2D > Rigidbody 2D
                    - Gravity Scale = 3(3배)
                - Physics 2D > Circle Collider 2D
                    - 구름과 충돌하고 판정이 남을 확인하고 나면 캡슐형 콜라이더로 바꿔 정확한 판정 영역으로 만들자. 
                        - Circle Collider: Offset = (0, -0.3) Radius = 0.15
                        - Box Collider: Size = (0.3, 0.6)
                        - RigidBody > Constraints > Freeze Rotation: Z축 고정.
        - 카메라 오브젝트: 게임에 직접 나오진 않으나 플레이어 움직임에 맞춰 같이 움직여야 함.
        - 움직이지 않는 오브젝트: 구름, 깃발, 배경, 종료화면 배경
            - 구름:
                - Position = (0, -2, 0)
                - Physics 2D > Box Collider 2D
                    - Size = (1.4, 0.5)
                - Physics 2D > Rigidbody 2D
                    - Kinematic 체크: 외력이 적용되지 않는다.
                1. 프리팹으로 등록. 
                2. 제너레이터 대신 수동으로 오브젝트 추가. 
            - 깃발:
                - Position = (0.9, 17.4, 0)
                - Collider: Is Trigger 체크로 Trigger 모드(통과) 
            - 배경:
                - Position = (0, 11, 0) Scale = (2, 12, 1) Sprite Renderer > Order in Layer = -1
            - 클리어 Scene 배경:
                - Position: (0, 0, 0)
    3. 제너레이터
    4. 감독: UI 갱신 및 Scene 관리.
        - Scene 전환용 감독
            - Scenes: ClearScene, GameScene 두 장면 필요.
            - ClearScene: 완료 -> 게임 씬으로 전환 담당.
            - Build Settings > Scenes In Build 에서 사용할 씬 모두 등록.
        - 
    5. 스크립트 작성 순서 결정


- 용어:
    - 스프라이트 애니메이션: 플립북 방식 애니메이션. 단일 애니메이션에 필요한 스프라이트 이미지를 다수 준비하고 이를 정해진 시점에 변경하는 방식으로 애니메이션을 구현. 애니메이션 클립 파일로 구현.
    - 메카님(mecanim): 애니메이션 작성 및 실행 시 유니티 에디터에서 일관되게 조작할 수 있는 기능. 플레이 중 오브젝트의 상태를 감지하고 애니메이션 간 전환 시기라고 판단하면 자동으로 전환한다. 
        - 스프라이트: 애니메이션 중 한 순간의 모습.
        - 애니메이션 클립: 단일 동작에 속하는 스프라이트들의 묶음. 애니메이션 재생 속도,  시간.
        - 애니메이터 컨트롤러: 어떤 애니메이션 클립을 언제 실행할지 정한다.
        - Animator 컴포넌트: 애니메이션을 설정할 오브젝트에 조립해 넣는 컴포넌트로 여기서 메카님을 제공한다.

- 문법
    - 장면 관리자:
        - 전제 조건: `using UnityEngine.SceneManagement`
        - 장면 불러오기: `SceneManager.LoadScene("SceneName")`
    - 컴포넌트 `Rigidbody2D`
        - `GetComponent<Rigidbody2D>()`
        - 외력 작용: `rigid2d.AddForce(vector2DForce)`
        - 현재 속력: `rigid2D.velocity`
            - properties: x, y
    - 컴포넌트 `Collideer2D`
        - 충돌 판정: 인터페이스 `OnTriggerEnter2D(Collider2D other)`을 정의한다.
    - 컴포넌트 `Animator`
        - `GetComponent<Animator>()`
        - 애니메이션 진행 속력: `animator.speed` in float type.
        - 트리거 설정: `animatorComp.SetTrigger("TriggerName");`
    - 방향:
        - transform.up, transform.right
        - 스프라이트 스케일: `transform.localScale` Vector3 형식임.
    - 수학:
        - 절대값: `Mathf.Abs(scalar)`