using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float raycastDistance = 2f;
    [SerializeField] private Transform[] raycastPositions;
    private List<Lane> lanes = new List<Lane>();
    private int currentLaneIndex = 1;
    
    void Start()
    {
        lanes.Add(new Lane(0, false));
        lanes.Add(new Lane(1, false));
        lanes.Add(new Lane(2, false));
    }

    void Update()
    {
        for(int i = 0; i < 3; i++)
        {
            if(Physics.Raycast(raycastPositions[i].position, transform.up, raycastDistance))
            {
                lanes[i].isOccupied = true;
            }
            else
            {
                lanes[i].isOccupied = false;
            }
        }

        if(lanes[currentLaneIndex].isOccupied)
        {
            ChangeLane();
        }

    }

    private void ChangeLane()
    {
        switch (currentLaneIndex)
        {
            case 0: 
                MoveRight();
                break;
            case 1:
                if(Random.Range(1,3) % 2 == 0)
                    MoveRight();
                else
                    MoveLeft();
                break;
            case 2:
                MoveLeft();
                break;
        }
    }
    private void MoveLeft()
    {
        transform.position = raycastPositions[currentLaneIndex -1].position;
        currentLaneIndex -= 1;
    }
    private void MoveRight()
    {
        transform.position = raycastPositions[currentLaneIndex +1].position;
        currentLaneIndex += 1;
    }
    bool CheckLane(int index )
    {
        if(lanes[index].isOccupied)
            return true;
        else
            return false;
    }
}

public class Lane
{
    public int laneIndex;
    public bool isOccupied;

    public Lane( int index, bool occupancy)
    {
        laneIndex = index;
        isOccupied = occupancy;
    }
}