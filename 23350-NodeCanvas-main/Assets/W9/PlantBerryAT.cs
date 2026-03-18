using NodeCanvas.Framework;
using ParadoxNotion.Design;
using System.Collections.Generic;
using UnityEngine;


namespace NodeCanvas.Tasks.Actions {

	public class PlantBerryAT : ActionTask {

		public Transform mound;
		public BBParameter<List<GameObject>> plants;

		public GameObject deadPlant;

        GameObject plant, plantedPlant, killedPlant;

		//Use for initialization. This is called only once in the lifetime of the task.
		//Return null if init was successfull. Return an error string otherwise
		protected override string OnInit() {
			return null;
		}

		//This is called once each time the task is enabled.
		//Call EndAction() to mark the action as finished, either in success or failure.
		//EndAction can be called from anywhere.
		protected override void OnExecute() {
			int rand = Random.Range(0, plants.value.Count);
			plant = plants.value[rand];
			plantedPlant = GameObject.Instantiate(plant, new Vector3(mound.position.x, mound.position.y + 1, mound.position.z), Quaternion.identity);
            plantedPlant.transform.localScale = new Vector3(0.2f, 0.2f, 0.2f);
        }

		//Called once per frame while the action is active.
		protected override void OnUpdate() {

			plantedPlant.transform.localScale *= 1.001f; 

			int death = Random.Range(0, 1000);
			if (death == 1)
			{
				plants.value.Remove(plant);

				killedPlant = GameObject.Instantiate(deadPlant, new Vector3(mound.position.x, mound.position.y+1, mound.position.z), Quaternion.identity);
				killedPlant.transform.localScale = plantedPlant.transform.localScale;
                GameObject.Destroy(plantedPlant);

                EndAction(false);
            }
        }

		//Called when the task is disabled.
		protected override void OnStop() {
			
		}

		//Called when the task is paused.
		protected override void OnPause() {
			
		}
	}
}