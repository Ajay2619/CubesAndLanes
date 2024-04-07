using System.Collections;
using System.Collections.Generic;
using UnityEditor.ShaderKeywordFilter;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float speed = 5f;
    void Update()
    {
        transform.Translate(speed * Vector3.down * Time.deltaTime);
    }
}
