using UnityEngine;

public class Player : MonoBehaviour
{
	[SerializeField] private CharacterController characterController;
	[SerializeField] private LayerMask environmentLayerMask;
	private const float moveSpeed = 2;
	private const float jumpHeight = 3.5f;
	private const float gravity = 0.1f;
	private Vector3 velocity;
	private bool isGrounded;

	private bool _jumpInput = false;

	public Vector2 movementInput { get; set; }
	public bool jumpInput {
        get
		{
			return _jumpInput;
        }
        set
        {
            if(isGrounded)
            {
				_jumpInput = value;
            }
        }
    }


	void Update()
    {
		CheckGround();
		Gravity();
		Move();   
    }

    private void CheckGround()
    {
		Vector3 checkGround = new Vector3(transform.position.x,
            transform.position.y - characterController.height / 2,
            transform.position.z);
		isGrounded = Physics.Raycast(checkGround, Vector3.down, 0.1f, environmentLayerMask);
    }

    private void Gravity()
	{
		if (isGrounded && jumpInput)
        {
			velocity.y = jumpHeight;
			jumpInput = false;
		}
        else if(isGrounded && !jumpInput)
        {
			velocity.y = -2;
		}
		velocity.y -= gravity;
		characterController.Move(velocity * Time.deltaTime);
    }

	private void Move()
	{
		Vector3 move = transform.right * movementInput.x + transform.forward * movementInput.y;
		characterController.Move(move * moveSpeed * Time.deltaTime);
	}
}
