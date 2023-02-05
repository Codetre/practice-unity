using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// 1. UI 요소 사용에 필수임.
using UnityEngine.UI;

public class GameDirector : MonoBehaviour
{
    // 2. HP를 표시하는 게이지 오브젝트 참조와 깎아나갈 양을 설정.
    GameObject HPGauge;
    float amt = 0.1f;

    void Start()
    {
        // 3. HP 게이지 오브젝트를 찾는다.
        HPGauge = GameObject.Find("HPGauge");
    }

    void Update()
    {
        
    }

    // 4. 충돌 시마다 게이지를 깎는다.
    public void DecreaseHP()
    {
        this.HPGauge.GetComponent<Image>().fillAmount -= amt;
    }
}
