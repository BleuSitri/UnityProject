﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveState : State {
	//Player.eInputDirection _prevAniDirection;
	// Use this for initialization
	override public void Start () {
		//_prevAniDirection = Player.eInputDirection.NONE;
		//UpdateAnimation();
	}
	
	// Update is called once per frame
	override public void Update () {
		if(Player.eInputDirection.NONE == _character.GetInputVerticalDirection() &&
		   Player.eInputDirection.NONE == _character.GetInputHorizontalDirection())
		{
			_character.ChangeState(Player.eState.IDLE);
			return;
		}
		//UpdateAnimation();
		_character.UpdateMove();
	}
    /*
	void UpdateAnimation()
	{
		
	}
	*/
}
