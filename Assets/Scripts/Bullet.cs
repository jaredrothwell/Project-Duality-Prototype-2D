using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 10f;
    private Rigidbody2D rb;
    public Transform target;
    public Vector3 heading;
    public float distance;
    public Vector3 direction;

    private float timer = 20f;
    
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        Vector3 heading = target.position - transform.position;
        distance = heading.magnitude;
        direction = heading / distance;
        //Quaternion rotation = Quaternion.LookRotation(relativePos, Vector3.up);
        //transform.rotation = rotation;
    }

    // Update is called once per frame
    void Update()
    {

        // the second argument, upwards, defaults to Vector3.up
        rb.velocity = direction * speed;

        timer -= Time.deltaTime;
        if (timer < 0)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Shield" || other.gameObject.tag == "Wall")
        {
            Destroy(gameObject);
        }
		else if(other.gameObject.tag == "PlayerBody")
		{
			Model.takeDamage(20);
			Destroy(gameObject);
		}
    }
}
