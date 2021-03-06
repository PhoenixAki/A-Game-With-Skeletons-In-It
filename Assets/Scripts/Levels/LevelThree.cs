﻿using UnityEngine;

public class LevelThree : MonoBehaviour {

    private bool end;
    private float endTimer;
    public Animator anim;
    public FinalBoss finalBoss;
    public GameObject[] bars;
	public Skeleton[] skeletons;
    public static int enemyCount;
    public Wizard[] wizards;
	public WizardBoss wizBoss;

	private void Update()
	{
        //This function handles various level triggers as the player progresses through the level.
        switch (enemyCount) {
			case 4:
				if (!skeletons[4].active)
					skeletons[4].active = true;
				break;
			case 5:
				if (!wizards [0].active) {
					wizards [0].active = true;
					wizards [1].active = true;
					wizards [2].active = true;
					wizards [3].active = true;
				}
				break;
			case 9:
				if (bars[0].activeSelf)
					bars[0].SetActive (false);
				break;
			case 10:
				if (bars[1].activeSelf)
					bars[1].SetActive (false);
				break;
			case 11:
				if (endTimer < 1) {
					endTimer += Time.deltaTime;
				} else if(!end){
					anim.SetTrigger ("LevelComplete");
					GameManager.SetState ("LVLTHREED");
					end = true;
				}
				break;
			default:
				break;
		}
	}

	public void EnemyTrigger(string trigger)
	{
        //This function handles enemy activations once the player touches certain triggers.
        switch (trigger) {
			case "Trigger1":
				skeletons [0].active = true;
				skeletons [1].active = true;
				skeletons [2].active = true;
				skeletons [3].active = true;
				break;
			case "WizBossTrigger":
				wizBoss.active = true;
				break;
			case "FinalBossTrigger":
				finalBoss.active = true;
				break;
		}
	}
}
