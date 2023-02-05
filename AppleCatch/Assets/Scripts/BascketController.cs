using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BascketController : MonoBehaviour
{
    // 4. 물체를 받은 순간 재생할 음향 효과 설정.
    public AudioClip appleSE;
    public AudioClip bombSE;
    AudioSource audioSourceComp;
    
    // 5. 받은 물체에 따라 득점을 갱신하라고 감독의 관련 메서드를 호출해야 한다.
    GameObject gameDirector;

    void Start()
    {
        this.audioSourceComp = GetComponent<AudioSource>();    
        gameDirector = GameObject.Find("GameDirector");
    }

    void Update()
    {
        // 1.터치한 곳으로 바구니를 옮긴다.
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, Mathf.Infinity))
            {
                // 매트의 각 셀 중심 좌표는 {-1, 0, 1} 셋만 가능하며,
                // stage의 콜라이더 범위 밖은 Ray가 그대로 통과하기에 단순 반올림만으로도 충분.
                float x = Mathf.RoundToInt(hit.point.x);
                float z = Mathf.RoundToInt(hit.point.z);
                transform.position = new Vector3(x, 0, z);
            }
        }
    }

    // 2. 받은 물체를 메모리에서 제거.
    void OnTriggerEnter(Collider other)
    {
        // 3. 받은 물체 종류에 따라 다르게 득점을 처리한다.
        GameObject catched = other.gameObject;
        Debug.Log($"Catch {catched.name}.");
        if (catched.tag == "Apple")
        {
            // 6-1. 사과 득점
            gameDirector.GetComponent<GameDirector>().CatchApple();
            // Plays an AudioClip, and scales the AudioSource volume by volumeScale.
            this.audioSourceComp.PlayOneShot(this.appleSE);
        } else
        {
            // 6-2. 폭탄 득점
            gameDirector.GetComponent<GameDirector>().CatchBomb();
            this.audioSourceComp.PlayOneShot(this.bombSE);
        }
        Destroy(other.gameObject);
    }
}
