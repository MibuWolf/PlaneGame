using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitEffect : MonoBehaviour {

    public float lifeTime = 1.0f;

    private float curTime = 0.0f;


	// Use this for initialization
	void Start () {
		
	}


    public void setParent( Transform ptransform )
    {
        if (!ptransform)
            return;

        transform.parent = ptransform;
        transform.localPosition = ptransform.localPosition;
    }

	
	// Update is called once per frame
	void Update () {

        curTime += Time.deltaTime;

        if (curTime >= lifeTime)
        {
            Destroy(this.gameObject);
        }
        else
        {
            if (this.transform.parent)
            {
                this.transform.position = this.transform.parent.position;
            }    
        }

    }
}
