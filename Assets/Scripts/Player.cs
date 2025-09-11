using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    [SerializeField]
    private float moveSpeed = 7f;

    private InputActions inputActions; // TODO: seperate to other file

    private bool isWalking;

    private void Start()
    {
        inputActions = new InputActions();
        inputActions.Enable();

        isWalking = false;
    }

    private void Update()
    {
        Vector2 inputVector = new Vector2(0, 0);

        if (inputActions.Player.MoveUp.IsPressed())
        {
            inputVector.y += 1f;
        }
        if (inputActions.Player.MoveDown.IsPressed())
        {
            inputVector.y += -1f;
        }
        if (inputActions.Player.MoveLeft.IsPressed())
        {
            inputVector.x += -1f;
        }
        if (inputActions.Player.MoveRight.IsPressed())
        {
            inputVector.x += 1f;
        }

        inputVector = inputVector.normalized;

        Vector3 moveDir = new Vector3(inputVector.x, 0f, inputVector.y);
        transform.position += moveDir * moveSpeed * Time.deltaTime;

        isWalking = moveDir != Vector3.zero;

        float rotateSpeed = 10f;
        transform.forward = Vector3.Slerp(transform.forward, moveDir, Time.deltaTime * rotateSpeed);
        Debug.Log(inputVector);
    }

    public bool IsWalking()
    {
        return isWalking;
    }
}
