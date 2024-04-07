using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.TextCore;


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
        // Debug.Log($"{lanes[0].isOccupied} {lanes[1].isOccupied} {lanes[2].isOccupied}");
        if(lanes[currentLaneIndex].isOccupied)
        {
            ChangeLane();
        }

    }

    private void ChangeLane()
    {
        switch (currentLaneIndex)
        {
            //if the player is on Left lane
            case 0: 
                MoveRight();
                if(CheckLane(currentLaneIndex))
                {
                    MoveRight();
                }
                break;
            //if player in on the Middle lane
            case 1:
                if(CheckLane(currentLaneIndex - 1))
                {
                    MoveRight();
                }
                else
                {
                    MoveLeft();
                }
                break;
            //if player in on the Right lane
            case 2:
                MoveLeft();
                if(CheckLane(currentLaneIndex))
                {
                    MoveLeft();
                }
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