using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterScript : MonoBehaviour
{

    [SerializeField]
    private float moveForce = 10f;
    private float movementX;
    private string DEAD_ANIMATION="redzone";
    private Animator anim;
    private string WALL_TAG="wall";

    private void Awake()
    {
        anim = GetComponent<Animator>();
    }


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        movePlayerKeyboard();
        AnimatePlayer();

    }

    void movePlayerKeyboard()
    {
        movementX = Input.GetAxis("Horizontal");
        transform.position += moveForce * Time.deltaTime * new Vector3(movementX, 0f, 0f);
    }

    void AnimatePlayer()
    {
        if (transform.position.x < -10.92)
        {
            anim.SetBool(DEAD_ANIMATION, true);
        }
        else if (transform.position.x > 10.93)
        {
            anim.SetBool(DEAD_ANIMATION, true);
        }
        else
        {
            anim.SetBool(DEAD_ANIMATION, false);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag(WALL_TAG))
        {
            Debug.Log("Collision Happend");
        }
    }

}
