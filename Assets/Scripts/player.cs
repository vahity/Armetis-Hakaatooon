using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour
{
    public float moveSpeed;
    public float minDistance;

    private Transform target;

    void Update()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            if (touch.phase == TouchPhase.Began)
            {
                RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(touch.position), Vector2.zero);
                if (hit.collider != null && hit.collider.CompareTag("Aim"))
                {
                    target = hit.collider.transform;
                }
            }
        }

        if (target != null)
        {
            Vector3 targetPosition = target.position;
            targetPosition.z = transform.position.z;

            if (Vector3.Distance(transform.position, targetPosition) >= minDistance)
            {
                transform.position = Vector3.MoveTowards(transform.position, targetPosition, moveSpeed * Time.deltaTime);
                Debug.Log("Moving towards: " + target.name);
            }
            else
            {
                Debug.Log("Reached target: " + target.name);
                target = null;
            }
        }
    }
}
