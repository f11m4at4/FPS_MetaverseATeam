using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// �÷��̾��� ü���� ����
// �ʿ�Ӽ� : ü��, UI
public class PlayerHealth : MonoBehaviour
{
    [SerializeField]
    // �ʿ�Ӽ� : ü��, UI
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
            // �����ð����� damageUI �� Ȱ��ȭ �ߴٰ� ���� �ʹ�.
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
        // ���� damageUI �� Ȱ��ȭ �ƴٸ�
        if (damageUI.enabled)
        {
            // �����ð����� damageUI �� Ȱ��ȭ �ߴٰ� ���� �ʹ�.
            currentTime += Time.deltaTime;
            if(currentTime > blinkTime)
            {
                currentTime = 0;
                damageUI.enabled = false;
            }
        }
    }
}
