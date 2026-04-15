using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;


namespace NodeCanvas.Tasks.Actions {

	public class BlowBubblesAT : ActionTask {

		public float bubbleCount, interval;
		float bubbleCounter, timer;

		public Vector3 bubbleBlower;
		public BBParameter<GameObject> bubblePrefab;

        //Use for initialization. This is called only once in the lifetime of the task.
        //Return null if init was successfull. Return an error string otherwise
        protected override string OnInit() {
			return null;
		}

		//This is called once each time the task is enabled.
		//Call EndAction() to mark the action as finished, either in success or failure.
		//EndAction can be called from anywhere.
		protected override void OnExecute() {
			timer = Time.time + interval;
        }

		//Called once per frame while the action is active.
		protected override void OnUpdate() {
			//if (Time.time > timer)
			//{
			//	GameObject bubble = InstantiateGameObject(bubblePrefab.value, agent.transform.position + bubbleBlower, Quaternion.identity);

			//	bubbleCounter++;
			//	timer = Time.time + interval;
   //         }
        }

		//Called when the task is disabled.
		protected override void OnStop() {
			
		}

		//Called when the task is paused.
		protected override void OnPause() {
			
		}
	}
}