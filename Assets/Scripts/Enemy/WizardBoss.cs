﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WizardBoss : Enemy {

	private bool invoke;
	private int changeTimer, seconds, threeRoom, twoRoom;
	private float aliveTimer;
	private Vector3 afterPosition, beforePosition;
	public Transform[] spawns;

	private void Start()
	{
		animator = GetComponent<Animator> ();
		capsule = GetComponent<CapsuleCollider> ();
		coolDown = 2f;
		if (GameManager.GetLevel () == "LevelTwo") {
			changeTimer = 5;
			maxHealth = 700;
		} else {
			changeTimer = 7;
			maxHealth = 1000;
		}
		seconds = changeTimer;
		currentHealth = (int)maxHealth;
	}

	private void Update()
	{
		transform.LookAt (player.transform);
		if (!Death () && active) {
			if (!invoke) {
				InvokeRepeating ("UpdateText", 0f, 1f);
				invoke = true;
			}

			if (aliveTimer < changeTimer) {
				aliveTimer += Time.deltaTime;
				attackTimer += Time.deltaTime;

				if (Vector3.Distance (transform.position, player.transform.position) < 13.5 && attackTimer > coolDown) {
					Invoke ("Shoot", 0f);
					Invoke ("Shoot", .1f);
					Invoke ("Shoot", .2f);
					attackTimer = 0;	
				}
			} else {
				//if here, it's time to change spawn
				beforePosition = transform.position;
				afterPosition = ChangePosition ();

				if(Vector3.Distance(beforePosition, afterPosition) > 1){
					transform.position = afterPosition;
					attackTimer = 0;
					aliveTimer = 0;
				}
			}
		}
	}

	private Vector3 ChangePosition()
	{
		//First, randomize a room value to spawn from
		threeRoom = Random.Range (0, 3);
		twoRoom = Random.Range (0, 2);

		//Next, use the player's current room + the random value to determine which room the boss will spawn in next.
		switch (PlayerMove.room) {
			case "TopLeft":
				if (twoRoom == 0)
					return spawns [1].position;
				else if (twoRoom == 1)
					return spawns [3].position;
				break;
			case "TopRight":
				if (twoRoom == 0)
					return spawns [1].position;
				else if (twoRoom == 1)
					return spawns [5].position;
				break;
			case "BottomLeft":
				if (twoRoom == 0)
					return spawns [0].position;
				else if (twoRoom == 1)
					return spawns [4].position;
				break;
			case "BottomRight":
				if (twoRoom == 0)
					return spawns [2].position;
				else if (twoRoom == 1)
					return spawns [4].position;
				break;
			case "TopMiddle":
				if (threeRoom == 0)
					return spawns [0].position;
				else if (threeRoom == 1)
					return spawns [2].position;
				else if (threeRoom == 2)
					return spawns [4].position;
				break;
			case "BottomMiddle":
				if (threeRoom == 0)
					return spawns [1].position;
				else if (threeRoom == 1)
					return spawns [3].position;
				else if (threeRoom == 2)
					return spawns [5].position;
				break;
		}
		//should never reach here
		Debug.Log("ruh roh");
		return transform.position;
	}

	private void UpdateText()
	{
		if (seconds < 3)
			UIManager.levelText.text = "Boss Moving in " + seconds + " seconds.";
		else
			UIManager.levelText.text = "";
		
		seconds--;
		if (seconds == 0)
			seconds = changeTimer;
	}
}
