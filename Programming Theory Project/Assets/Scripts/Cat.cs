using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public abstract class Cat : Movable
{
    protected float BaseSpeed;
    protected float CurrentSpeed;

    protected float FleeDistance = 5f;
    
    
    protected float TimeToNextRun = 0f;
    protected float TimeForDirection = 0f;

    protected Vector3 CurrentDirection;
    
    protected float TimeToRun;
    
    protected bool Running;

    protected float RunSpeedFactor;


    public GameObject player;
    
    // ENCAPSULATION of flee check
    public int Weight { get; protected set; }

    // Update is called once per frame
    private void Update()
    {
        CheckFlee();
        Move();
    }

    private void Move()
    {
        // If direction should change
        if (Time.time >= TimeForDirection)
        {
            GetNewDirection();
        }
        //Debug.Log($"Run to {CurrentDirection.x}/0/{CurrentDirection.z}: " );
        transform.Translate(CurrentDirection.x * CurrentSpeed * Time.deltaTime,0, CurrentDirection.z * CurrentSpeed * Time.deltaTime);
        CheckBoundaries();
    }

    // ENCAPSULATION of different flee methods
    private void CheckFlee()
    {
        float distanceToPlayer = Vector3.Distance(transform.position, player.transform.position);
        
        if (distanceToPlayer <= FleeDistance)
        {
            Debug.Log($"try to flee from: {player.name}");
            Flee(player.transform.position);
        }
        else
        {
            Flee();
        }
    }

    // POLYMORPHISM - flee if player runs
    private void Flee()
    {
        float currentTime = Time.time;
        // Check if cat is ready to flee and player is running
        if (!Running && Input.GetKeyDown(KeyCode.Space) && TimeToNextRun <= currentTime)
        {
            Run();
            TimeToRun = currentTime + 5f;
            Running = true;
            TimeToNextRun = currentTime + 7f;
        }
        else if (Running && currentTime <= TimeToRun)
        {
            Walk();
        }
    }

    // POLYMORPHISM - flee if triggered (e.g. player is near) with a direction to flee from
    private void Flee(Vector3 direction)
    {
        float currentTime = Time.time;
        if (!Running && TimeToNextRun <= currentTime)
        {
            Vector3 fleeTo = new Vector3(-direction.x, direction.y, -direction.z);
            transform.LookAt(fleeTo);
            Run();
            TimeToRun = currentTime + 2f;
            Running = true;
            TimeToNextRun = currentTime + 3f;
        }
    }

    private void Run()
    {
        CurrentSpeed *= RunSpeedFactor;
    }

    private void Walk()
    {
        CurrentSpeed /= RunSpeedFactor;
    }

    protected void GetNewDirection()
    {
        // set random time for this direction and get new direction
        TimeForDirection = Time.time + Random.Range(1.0f, 5.0f);
        Debug.Log($"New direction for {gameObject.name} after {TimeForDirection}");

        CurrentDirection = new Vector3(Random.value, 0, Random.value);
    }

    protected override void CheckBoundaries()
    {
        if (transform.position.x > xBoundary || transform.position.x < -xBoundary || transform.position.z > zBoundary || transform.position.z < -zBoundary)
        {
            GetNewDirection();
        }
        base.CheckBoundaries();
    }

}
