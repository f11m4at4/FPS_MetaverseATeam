using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// 플레이어의 체력을 관리
// 필요속성 : 체력, UI
public class PlayerHealth : MonoBehaviour
{
    [SerializeField]
    // 필요속성 : 체력, UI
    int hp = 3;
    public Image damageUI;

    public int HP
    {
        get
        {
            return hp;
        }
        set
        {
            hp = value;
            damageUI.enabled = true;
            // 일정시간동안 damageUI 를 활성화 했다가 끄고 싶다.
        }
    }

    public float blinkTime = 0.205f;
    float currentTime;

    public static PlayerHealth Instance;
    private void Awake()
    {
        Instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        // 만약 damageUI 가 활성화 됐다면
        if (damageUI.enabled)
        {
            // 일정시간동안 damageUI 를 활성화 했다가 끄고 싶다.
            currentTime += Time.deltaTime;
            if(currentTime > blinkTime)
            {
                currentTime = 0;
                damageUI.enabled = false;
            }
        }
    }
}
