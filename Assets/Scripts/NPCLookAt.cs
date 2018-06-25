using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCLookAt : MonoBehaviour {

    public Transform target;
    public float speed = 3f;

	void Update ()
    {
        if (Vector3.Distance(target.position, this.transform.position) < 8)
        {
       
            Vector3 direction = target.position - transform.position;

            Vector3 delta = new Vector3(direction.x, 0f, direction.z);
            Quaternion rotation = Quaternion.LookRotation(delta);

          /*  Quaternion rotation = Quaternion.LookRotation(direction); */
            transform.rotation = Quaternion.Lerp(transform.rotation, rotation, speed * Time.deltaTime);
        }
	}
}
