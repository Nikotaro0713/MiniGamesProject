using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 2.0f;
    [SerializeField] private float moveDistance = 0.5f;

    private Vector3 startPosition;


    // Start is called before the first frame update
    void Start()
    {
        startPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        float move = Mathf.PingPong(Time.time * moveSpeed, moveDistance) - (moveDistance /2f);
        transform.position = startPosition + new Vector3(move, 0, 0);
    }
}
