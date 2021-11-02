using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    [SerializeField]
    private float speed = 4f;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        MovePlayer();
    }

    private void MovePlayer()
    {
        transform.Translate(Input.GetAxisRaw("Horizontal") * speed * Time.deltaTime,0, Input.GetAxisRaw("Vertical") * speed * Time.deltaTime);
    }
}
