using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    [SerializeField] private Vector3 movePoint1;
    [SerializeField] private Vector3 movePoint2;

    [SerializeField] private float moveSpeed;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        movePlatform();
    }

    private void movePlatform()
    {
        if(Vector3.Distance(transform.position, movePoint1) <= 0.1f)
        {

        }
        transform.position = Vector3.Lerp(movePoint1, movePoint2, moveSpeed * Time.deltaTime);
    }
}
