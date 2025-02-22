﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityStandardAssets.Characters.ThirdPerson;

public class PlayerController : MonoBehaviour {

	private Camera cam;

	private NavMeshAgent agent;

	public ThirdPersonCharacter character;

	private void Start() {
		agent.updateRotation = false;
	}

	private void Awake() {
		agent = GetComponent<NavMeshAgent>();
		cam = Camera.main;
	}

	// Update is called once per frame
	void Update () {
		if(Input.GetMouseButtonDown(0)){
			
			Ray ray = cam.ScreenPointToRay(Input.mousePosition);
			RaycastHit hit;

			if(Physics.Raycast(ray, out hit)){
				agent.SetDestination(hit.point);
			}

		}
		if(agent.remainingDistance > agent.stoppingDistance){
			character.Move(agent.desiredVelocity, false, false);
		}else{
			character.Move(Vector3.zero, false, false);
		}
		
	}
}
