using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectMove : MonoBehaviour
{
    public Vector3 _tar;
    public float speed;
    private void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position,_tar,0.03f);
        if (transform.position == _tar)
        {
            Destroy(gameObject);
        }
    }
}
