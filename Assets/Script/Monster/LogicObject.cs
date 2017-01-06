using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LogicObject : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnCollisionEnter(Collision other)
    {

    }

    virtual public void OnHit(int damage)
    {

    }


    // 每帧监测有效性 如果超出地图区域范围则直接销毁
    protected void checkValidity()
    {
        Transform transf = this.GetComponent<Transform>();
        Camera camera = Camera.main;

        if (transf)
        {
            if (transf.position.x < -5 || transf.position.x > 5 ||
                transf.position.y - camera.transform.position.y < -5 || transf.position.y - camera.transform.position.y > 10)
            {
                Dispose();
            }

        }

    }


    // 清理当前脚本
    virtual public void Dispose()
    {
        Destroy( this.gameObject );
    }

}
