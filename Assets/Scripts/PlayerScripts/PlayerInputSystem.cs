﻿using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputSystem : MonoBehaviour
{
	[SerializeField] private Player playerScript;
	[SerializeField] private PlayerCamera playerCamera;
	private PlayerInputActions playerInputActions;


	private void Awake()
	{
		playerInputActions = new PlayerInputActions();
		playerInputActions.PlayerControls.Move.performed += SetMove;
		playerInputActions.PlayerControls.Camera.performed += SetCamera;
		playerInputActions.PlayerControls.Jump.performed += SetJump;
	}

	public void SetMove(InputAction.CallbackContext context)
	{
		playerScript.movementInput = context.ReadValue<Vector2>();
	}

	public void SetCamera(InputAction.CallbackContext context)
	{
		playerCamera.cameraInput = context.ReadValue<Vector2>();
	}

	public void SetJump(InputAction.CallbackContext context)
    {
		playerScript.jumpInput = true;
    }

	private void OnEnable()
	{
		playerInputActions.Enable();
	}

	private void OnDisable()
	{
		playerInputActions.Disable();	
	}
}
