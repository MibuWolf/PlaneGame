using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NormalMonster : MonsterBase
{
    // 运动速度朝向
    public Vector3 velocity;
    // 速度值
    public float speed;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        if ( speed == 0 )
            return;

        Vector3 curPos = transform.position;

        curPos.x = velocity.x * speed * Time.deltaTime;
        curPos.y = velocity.y * speed * Time.deltaTime;
        curPos.z = velocity.z * speed * Time.deltaTime;

        transform.position = curPos;

    }
}
