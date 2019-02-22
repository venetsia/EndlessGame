using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shuricen : MonoBehaviour {

    public int damage = 1;
    public float speed;

    public GameObject effect;
   

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.left * speed * Time.deltaTime);

    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
          
            Instantiate(effect, transform.position, Quaternion.identity);

            //player takes damage!
            other.GetComponent<Player>().health -= damage;
            Debug.Log(other.GetComponent<Player>().health);
            Destroy(gameObject);
        }
    }

    // Use this for initialization
    void Start () {
		
	}
	
	
}
