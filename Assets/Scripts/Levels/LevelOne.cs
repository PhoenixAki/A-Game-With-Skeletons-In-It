﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelOne : MonoBehaviour {

	public static int enemyCount;
	public GameObject ironBars;
	public Skeleton[] skeletons;

	private void Update()
	{
		switch (enemyCount) {
			case 7:
				GameObject.Find ("Skeleton8").GetComponent<Skeleton> ().active = true;
				GameObject.Find ("Skeleton9").GetComponent<Skeleton> ().active = true;
				break;
			case 9:
				if (ironBars.activeSelf)
					ironBars.SetActive (false);
				break;
			default:
				break;
		}
	}

	public static void EnemyTrigger(string trigger)
	{
		//This function handles activating enemies from their stationary position once the player hits certain trigger points.
		switch (trigger) {
			case "Trigger1":
				GameObject.Find ("Skeleton1").GetComponent<Skeleton> ().active = true;
				break;
			case "Trigger2":
				GameObject.Find ("Skeleton2").GetComponent<Skeleton> ().active = true;
				GameObject.Find ("Skeleton3").GetComponent<Skeleton> ().active = true;
				break;
			case "Trigger3":
				GameObject.Find ("Skeleton4").GetComponent<Skeleton> ().active = true;
				GameObject.Find ("Skeleton5").GetComponent<Skeleton> ().active = true;
				GameObject.Find ("Skeleton6").GetComponent<Skeleton> ().active = true;
				break;
			case "Trigger4":
				GameObject.Find ("Skeleton7").GetComponent<Skeleton> ().active = true;
				break;
			case "BossTrigger":
				GameObject.Find ("SkeletonBoss").GetComponent<Skeleton> ().active = true;
				break;
		}
	}
}
