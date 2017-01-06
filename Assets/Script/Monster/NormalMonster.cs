using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NormalMonster : MonsterBase
{
    // 运动速度朝向
    public Vector2 velocity;
    // 速度值
    public float speed = 1.0F;

    private bool bDie = false;

    // Use this for initialization
    void Start () {
        float angle = Vector2.Angle(Vector2.right, velocity);

        if (velocity.y < 0)
            angle = -angle;

        Quaternion q = Quaternion.Euler(0, 0, angle - 90);
        transform.rotation = q;
	}
	
	// Update is called once per frame
	void Update () {

        if ( speed == 0 )
            return;

        Vector3 curPos = transform.position;

        curPos.x += velocity.x * speed * Time.deltaTime;
        curPos.y += velocity.y * speed * Time.deltaTime;


        transform.position = curPos;

        checkValidity();

    }


    // 怪物被击中
    override public void OnHit(int damage)
    {
        if ( !bDie )
        {
            bDie = true;

            string url = "Prefab/Effect/Destoryed";
            GameObject destoryPrefab = Resources.Load<GameObject>(url);

            GameObject destory = Instantiate(destoryPrefab);

            HitEffect hitEffect = destory.GetComponent<HitEffect>();

            if (hitEffect)
                hitEffect.setParent(transform);

            StartCoroutine(waitAndDestory(0.25f));
        }
    }

    private IEnumerator waitAndDestory( float time )
    {
        yield return new WaitForSeconds(time);

        Destroy(gameObject);
    }
}
