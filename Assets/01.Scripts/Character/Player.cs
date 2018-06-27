using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Character {

    override protected void InitGroupType()
	{
		_groupType = eGroupType.PLAYER;
	}
	// Update is called once per frame
	override protected void UpdateProcess ()
	{
		CheckMouseLock();
		UpdateInput();

		UpdateRotate();
		UpdateState();
	}

    // State

    override protected void InitState()
	{
		base.InitState();

		State idleState = new PlayerIdleState();
		idleState.Init(this);
		_stateDic[eState.IDLE] = idleState;

		State interactionState = new PlayerInterationState();
		interactionState.Init(this);
		_stateDic[eState.INTERACTION] = interactionState;
	}

    // Item

    // 아이템 추가
    /*
    override protected void InitItem()
	{
		
	}
	*/

	// Input

	bool _mouseLock = true;

    void CheckMouseLock()
	{
		if(Input.GetKeyDown(KeyCode.LeftAlt))
		{
			_mouseLock = !_mouseLock;
		}
		if(_mouseLock)
		{
			Cursor.lockState = CursorLockMode.Locked;
			Cursor.visible = false;
		}
		else
		{
			Cursor.lockState = CursorLockMode.None;
			Cursor.visible = true;
		}
	}

    void UpdateInput()
	{
		_inputVerticalDirection = eInputDirection.NONE;
		_inputHorizontalDirection = eInputDirection.NONE;
		_inputAniDirection = eInputDirection.NONE;

        if(Input.GetKey(KeyCode.W))
		{
			_inputVerticalDirection = eInputDirection.FRONT;
			_inputAniDirection = eInputDirection.FRONT;
		}
        if(Input.GetKey(KeyCode.S))
		{
			_inputVerticalDirection = eInputDirection.BACK;
			_inputAniDirection = eInputDirection.BACK;
		}
        if(Input.GetKey(KeyCode.A))
		{
			_inputHorizontalDirection = eInputDirection.LEFT;
			_inputAniDirection = eInputDirection.LEFT;
		}
        if(Input.GetKey(KeyCode.D))
		{
			_inputHorizontalDirection = eInputDirection.RIGHT;
			_inputAniDirection = eInputDirection.RIGHT;
		}

        // 점프..?

	}

    // Rotate

    override protected void UpdateRotate()
	{
		if (false == _mouseLock)
			return;

		float rateSpeed = 30.0f;
		float addRotationY = Input.GetAxis("Mouse X") * rateSpeed;
		_rotationY += (addRotationY * Time.deltaTime);
		transform.rotation = Quaternion.Euler(0.0f, _rotationY, 0.0f);
	}
}
