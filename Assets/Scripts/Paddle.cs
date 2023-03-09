using UnityEngine;

public class Paddle : MonoBehaviour
{
    [SerializeField] private float _movementSpeed;
    
    private void Update()
    {
        var x = ReadInput();

        var nextPosition = CalculateNextPosition(x);
        MoveTo(nextPosition);
    }
    public void ResetPosition()
    {
        transform.position = new Vector3(0, transform.position.y);
    }
    private float ReadInput()
    {
        return Input.GetAxis("Horizontal"); ;
    }

    private Vector3 CalculateNextPosition(float x)
    {
        return Vector3.right * x * _movementSpeed * Time.deltaTime;
    }

    private void MoveTo(Vector3 nextPosition)
    {
        transform.position = transform.position + nextPosition;
    }


    private void LateUpdate()
    {
        transform.position = new Vector3(Mathf.Clamp(transform.position.x, -2, 2), transform.position.y);
    }



}
