using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
public class UI_CoolTime_Script : MonoBehaviour
{
    public Button btn;
    public float coolTime = 10f;
    public TMP_Text textCoolTime;
    private Coroutine coolTimeRoutine;
    public Image imgFill;

    public void Init()
    {
        this.textCoolTime.gameObject.SetActive(false);
        this.imgFill.fillAmount = 0;
    }
    // Start is called before the first frame update
    void Start()
    {
        this.btn = this.GetComponent<Button>();
        this.btn.onClick.AddListener(() =>
        {
            if (this.coolTimeRoutine != null)
            {
                Debug.Log("쿨타임 중입니다...");
            }
            else
            {
                this.coolTimeRoutine = this.StartCoroutine(this.CoolTimeRoutine());
            }
        });

        Init();
    }


    // Update is called once per frame
    void Update()
    {
        
    }

    private void CoolTImeOn()
    {
        if (this.coolTimeRoutine != null)
        {
            Debug.Log("쿨타임 중입니다...");
        }
        else
        {
            this.coolTimeRoutine = this.StartCoroutine(this.CoolTimeRoutine());
        }
    }
    private IEnumerator CoolTimeRoutine()
    {
        Debug.Log(textCoolTime);
        this.textCoolTime.gameObject.SetActive(true);
        var time = this.coolTime;

        while (true)
        {
            time -= Time.deltaTime;
            this.textCoolTime.text = time.ToString("F1");

            var per = time / this.coolTime;
            //Debug.Log(per);
            this.imgFill.fillAmount = per;

            if (time <= 0)
            {
                this.textCoolTime.gameObject.SetActive(false);
                break;
            }
            yield return null;
        }

        this.coolTimeRoutine = null;
    }

}
