using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour {

    //private Vector2 targetPos;
    public float Yincrement;

    public float speed;
    public float maxHeight;
    public float minHeight;

    public int health = 3;
    public GameObject effect;
    public Vector3 SlashOffset;

    
    

    void Start()
    {
        
        var rb = GetComponent<Rigidbody2D>();
        
        
        var constr = rb.constraints; //grab a copy (NOT a reference)
        constr = RigidbodyConstraints2D.FreezePositionX; //(modify the copy)
    }

    // Update is called once per frame
    void Update ()
    {
        if(health <= 0 )
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }

        //transform.position = Vector2.MoveTowards(transform.position, targetPos, speed * Time.deltaTime);




        /* if (Input.GetKeyDown(KeyCode.UpArrow) && transform.position.y < maxHeight)
         {


             Instantiate(effect, transform.position + SlashOffset, transform.rotation);
             targetPos = new Vector2(transform.position.x, transform.position.y + Yincrement);

         }
         else if (Input.GetKeyDown(KeyCode.DownArrow) && transform.position.y > minHeight)
         {

             Instantiate(effect, transform.position + SlashOffset, Quaternion.identity);
             targetPos = new Vector2(transform.position.x, transform.position.y - Yincrement);
         }*/
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0); // get first touch since touch count is greater than zero

            if (touch.phase == TouchPhase.Stationary || touch.phase == TouchPhase.Moved)
            {
                // get the touch position from the screen touch to world point
                Vector3 touchedPos = Camera.main.ScreenToWorldPoint(new Vector3(touch.position.x, touch.position.y, 10));
                // lerp and set the position of the current object to that of the touch, but smoothly over time.
                transform.position = Vector3.Lerp(transform.position, touchedPos, Time.deltaTime);
            }
        }
    }
}
