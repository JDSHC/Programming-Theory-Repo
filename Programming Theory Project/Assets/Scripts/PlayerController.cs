using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : Movable
{

    [SerializeField]
    private float speed = 7f;

    private float runFactor = 2f;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            speed *= runFactor;
        }
        else if (Input.GetKeyUp(KeyCode.Space))
        {
            speed /= runFactor;
        }
        MovePlayer();
    }

    private void MovePlayer()
    {
        transform.Translate(Input.GetAxisRaw("Horizontal") * speed * Time.deltaTime,0, Input.GetAxisRaw("Vertical") * speed * Time.deltaTime);
        CheckBoundaries();
    }
}
