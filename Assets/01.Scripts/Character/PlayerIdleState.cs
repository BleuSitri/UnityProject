using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerIdleState : State {

	// Use this for initialization
	override public void Start () {
		
	}
	
	// Update is called once per frame
	override public void Update () {

		Vector3 inputVertical = new Vector3(0.0f, 0.0f, Input.GetAxis("Vertical"));
        Vector3 inputHorizontal = new Vector3(Input.GetAxis("Horizontal"), 0.0f, 0.0f);
        if (0.0f != inputVertical.z || 0.0f != inputHorizontal.x)
        {
            _character.ChangeState(Player.eState.MOVE);
        }
	}
}
