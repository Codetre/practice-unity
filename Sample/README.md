- 용어
    - Script: 오브젝트를 어떻게 움직여야 하는지 명령하는 대본. 유니티에서 리소스로 취급된다.
    - Empty object(빈 오브젝트): 속이 빈(내용이 없는) 오브젝트.
    - 프레임: 게임 Scene의 시간 단위. 프레임 간 시간은 동일함이 이상적이나, 게임이 실행 중인 기기의 성능에 따라 일정하지 않을 수 있다. 

- 프로젝트 진행 순서
    1. 2D 프로젝트 생성
    2. C# 스크립트 작성
        - 위치: Project 창 > Create > C# Script
        - `Start()`: 게임을 실행할 때 최초 1회 실행되는 메서드.
        - `Update()`: 게임 실행 후 매 프레임마다 호출되는 메서드.
        - `Time.deltaTime`: 직전 프레임이 지나간 후 시간이 얼마나 흘렀는지 알 수 있다.
    3. 스크립트와 오브젝트 연결
    4. 게임 실행

- C# 문법
    - 데이터형
        ```C#
        // 기본적인 데이터형.
        int age = 30;
        float height = 170.1f; // 수치 뒤 `f`가 없으면 double형이다.
        string name = "Sera";
        int[] array1 = new int[5];
        int[] array2 = { 1, 2, 3, 4 };
        int lenOfArray2 = array2.Length;
        Debug.Log(age);
        
        // 자주 쓰는 내장 데이터형 - Vector
        Vector2 playerPos = new Vector2(3.0f, 4.0f);
        playerPos.x += 1.0f;
        playerPos.y -= 0.3f;
        Debug.Log("지금 플레이어 위치: " + playerPos);
        
        Vector2 initPos = new Vector2(0.0f, 0.0f);
        Vector2 endPos = new Vector2(3.0f, -1.5f);
        Vector2 posVector = endPos - initPos;
        float len = posVector.magnitude;
        Debug.Log(len + "만큼 이동했다.");
        ```
    - 클래스
        ```C#
        // 접근제한자: public, private, protected
        public class Player
        {
            private int hp = 100;
            private int power = 50;
          
            public void Attack()
            {
                Debug.Log(this.power + " 데미지를 입혔다.");
            }
            
            public void GotDamaged(int damage)
            {
                this.hp -= damage;
                Debug.Log($" 체력이 {this.hp} 남았다.");
            }
        }
        ```