using UnityEngine;

public class BotMovement : MonoBehaviour
{
    private Vector3 startPos;
    private Vector3 targetPos;
    private bool movingRight = true;
    private float moveDistance = 2.0f;
    private float moveSpeed = 0.002f;

    void Start()
    {
        startPos = transform.position;
        // Initial direction and target based on starting scale
        if (transform.localScale.x < 0)
        {
            movingRight = false;
        }
        UpdateTargetPosition();
    }

    void Update()
    {
        Vector3 currentPos = transform.position;

        // Move towards target
        if (currentPos != targetPos)
        {
            transform.position = Vector3.MoveTowards(currentPos, targetPos, moveSpeed);
        }
        // At destination - switch direction and update target
        else
        {
            movingRight = !movingRight;
            UpdateTargetPosition();
            FlipSprite();
        }
    }

    private void UpdateTargetPosition()
    {
        targetPos = movingRight ?
            startPos + new Vector3(moveDistance, 0, 0) :
            startPos + new Vector3(-moveDistance, 0, 0);
    }

    private void FlipSprite()
    {
        Vector3 newScale = transform.localScale;
        // Reversed the logic here - now negative scale when moving right
        newScale.x = Mathf.Abs(newScale.x) * (movingRight ? -1 : 1);
        transform.localScale = newScale;
    }
}