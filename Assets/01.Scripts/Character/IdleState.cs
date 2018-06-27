using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleState : State {

	float _waitTime = 1.0f;
	float _waitDuration = 0.0f;

	// Use this for initialization
	override public void Start () {
		//_character.CharacterModel.GetComponent<Animator>().SetTrigger("idle");

		_waitTime = Random.Range(1.0f, 2.0f);
		_waitDuration = 0.0f;
	}
	
	// Update is called once per frame
	override public void Update () {
		
	}
}
