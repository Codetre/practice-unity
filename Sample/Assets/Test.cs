// 아래 2줄은 필요한 Type 제공.
using System.Collections;
using System.Collections.Generic;
using UnityEngine;  // Unity 동작에 필요한 기능 제공.

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
        Debug.Log(damage + " 데미지를 입고, " + this.hp + " 체력이 남았다.");
    }
}

public class Test : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        // 기본적인 데이터형.
        int age = 30;
        float height = 170.1f;  // 수치 뒤 `f`가 없으면 double형이다.
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

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
