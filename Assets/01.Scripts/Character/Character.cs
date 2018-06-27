using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour {


	// Use this for initialization
	void Start ()
	{
		Init();
	}
	
	// Update is called once per frame
	void Update () {
		UpdateProcess();
	}

	public void Init()
	{
		InitGroupType();
		//InitItem();
		InitState();
		ChangeState(eState.IDLE);
	}

	// GroupType

	public enum eGroupType
	{
		PLAYER,
        TARGET,
		NPC,
	}

	protected eGroupType _groupType;

    virtual protected void InitGroupType()
	{
		_groupType = eGroupType.PLAYER;
	}

    public eGroupType GetGroupType()
	{
		return _groupType;
	}

    // Update

    virtual protected void UpdateProcess()
	{
		UpdateRotate();
		UpdateState();
	}

    // State

	public enum eState
	{
		IDLE,
        MOVE,
        INTERACTION,      
	}
	protected Dictionary<eState, State> _stateDic = new Dictionary<eState, State>();
	protected State _currentState;

    virtual protected void InitState()
	{
		State idleState = new IdleState();
		State moveState = new MoveState();
		State interactionState = new InteractionState();

		idleState.Init(this);
		moveState.Init(this);
		interactionState.Init(this);

		_stateDic.Add(eState.IDLE, idleState);
		_stateDic.Add(eState.MOVE, moveState);
		_stateDic.Add(eState.INTERACTION, interactionState);

	}

	public void ChangeState(eState nextState)
	{
		if(null != _currentState)
		{
			_currentState.Stop();
		}

		_currentState = _stateDic[nextState];
		_currentState.Start();
	}

    public void UpdateState()
	{
		_currentState.Update();
	}

    // Input

    public enum eInputDirection
	{
		NONE,
        FRONT,
        BACK,
        LEFT,
        RIGHT
	}

	protected eInputDirection _inputVerticalDirection = eInputDirection.NONE;
	protected eInputDirection _inputHorizontalDirection = eInputDirection.NONE;
	public eInputDirection _inputAniDirection = eInputDirection.NONE;

    public eInputDirection GetInputVerticalDirection()
	{
		return _inputVerticalDirection;
	}
	public eInputDirection GetInputHorizontalDirection()
	{
		return _inputHorizontalDirection;
	}

	public eInputDirection GetAniDirection()
	{
		return _inputAniDirection;
	}

	// Rotate

	protected float _rotationY = 0.0f;

    virtual protected void UpdateRotate()
	{
		
	}

	// Move
    
    // 공중에서 못 움직이게 bool 구현하기 or 중력 값 적용
    public void UpdateMove()
	{
		Vector3 addPosition = Vector3.zero;

		switch(_inputVerticalDirection)
		{
			case eInputDirection.FRONT:
				addPosition.z = MoveOffset(2.0f);
				break;
			case eInputDirection.BACK:
				addPosition.z = MoveOffset(-2.0f);
				break;

		}
		switch(_inputHorizontalDirection){
			case eInputDirection.LEFT:
				addPosition.x = MoveOffset(-2.0f);
				break;
			case eInputDirection.RIGHT:
				addPosition.x = MoveOffset(-2.0f);
				break;
		}
		transform.position += (transform.rotation * addPosition);
	}

    float MoveOffset(float moveSpeed)
	{
		return (moveSpeed * Time.deltaTime);
	}

    // Interaction

    // 마우스 클릭하면 아이템을 바라보고, 집는모션

    // Item

    // Animation
    /*
    public AnimationModule GetAnimationModule()
	{
		return CharacterModel.GetComponent<GetAnimationModule>();
	}
	*/
}