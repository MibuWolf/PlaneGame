using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class gameUI : MonoBehaviour {

    // 失败界面
    public GameObject uiFail;

    // 大招界面
    public Text uiDazhao;
    // 大招界面
    public Text uiDazhao2;
    // 盾牌界面
    public Text uiDunpai;


    // Use this for initialization
    void Start () {

        uiFail.SetActive(false);

        PlayerPrefs.SetInt("dazhao", 3);
        PlayerPrefs.SetInt("dazhao2", 3);
        PlayerPrefs.SetInt("dunpai", 3);
    }
	
	// Update is called once per frame
	void Update () {
		
	}


    public void dodazhao()
    {
        int dazhao = PlayerPrefs.GetInt("dazhao");

        if (dazhao > 0)
        {
            PlayerPrefs.SetInt("dazhao", --dazhao);
            GameObject player = GameObject.FindWithTag("Player");
            player.GetComponent<ButlleEmitter>().setDazhao();
            uiDazhao.text = PlayerPrefs.GetInt("dazhao").ToString();
        }
    }

    public void dodazhao2()
    {
        int dazhao2 = PlayerPrefs.GetInt("dazhao2");

        if (dazhao2 > 0)
        {
            PlayerPrefs.SetInt("dazhao2", --dazhao2);
            GameObject player = GameObject.FindWithTag("Player");

            player.GetComponent<ButlleEmitter>().setDazhao2();
            uiDazhao2.text = PlayerPrefs.GetInt("dazhao2").ToString();
        }
    }

    public void dodunpai()
    {
        int dunpai = PlayerPrefs.GetInt("dunpai");

        if (dunpai > 0)
        {
            PlayerPrefs.SetInt("dunpai", --dunpai);
            GameObject player = GameObject.FindWithTag("Player");
        }
    }
}
