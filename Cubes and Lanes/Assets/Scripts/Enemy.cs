using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [HideInInspector] public bool canMoveHorizontally = false;
    private int laneIndex;
    [SerializeField] private float speed = 5f;
    public int LaneIndex { get => laneIndex; set => laneIndex = value; }

    void Update()
    {
        transform.Translate(speed * Vector3.down * Time.deltaTime);

        if(GameManager.Instance.CanMoveHorizontally && canMoveHorizontally)
        {
            if(transform.position.y <= 0 && transform.position.y >= -0.2f)
            {
                MoveHorizontally();
            }
        }
    }

    private void MoveHorizontally()
    {
        switch (laneIndex)
        {
            case 0:
                transform.position = new Vector3(transform.position.x + 2.25f, transform.position.y, transform.position.z);
                break;
            case 1:
                if(Random.Range(1,3) % 2 == 0)
                {
                    transform.position = new Vector3(transform.position.x + 2.25f, transform.position.y, transform.position.z);
                }
                else
                {
                    transform.position = new Vector3(transform.position.x - 2.25f, transform.position.y, transform.position.z);
                }
                break;
            case 2:
                transform.position = new Vector3(transform.position.x - 2.25f, transform.position.y, transform.position.z);
                break;
        }

        canMoveHorizontally = false;
    }
}
