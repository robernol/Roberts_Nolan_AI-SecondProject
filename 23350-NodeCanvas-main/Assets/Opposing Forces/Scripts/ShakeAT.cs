using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;


namespace NodeCanvas.Tasks.Actions {

	public class ShakeAT : ActionTask {

		Vector3 pos;
		public float shakeTime;
		float timer;

		//Use for initialization. This is called only once in the lifetime of the task.
		//Return null if init was successfull. Return an error string otherwise
		protected override string OnInit() {
			return null;
		}

		//This is called once each time the task is enabled.
		//Call EndAction() to mark the action as finished, either in success or failure.
		//EndAction can be called from anywhere.
		protected override void OnExecute() {
			pos = agent.transform.position;
			timer = Time.time + shakeTime;
        }

		//Called once per frame while the action is active.
		protected override void OnUpdate()
		{
			Vector3 temp = pos;
			temp.x += Random.Range(-0.1f, 0.1f);
			temp.y += Random.Range(-0.1f, 0.1f);
			temp.z += Random.Range(-0.1f, 0.1f);
			agent.transform.position = temp;

			if (Time.time > timer)
			{
				EndAction(true);
			}
		}

		//Called when the task is disabled.
		protected override void OnStop() {
			agent.transform.position = pos;
        }

		//Called when the task is paused.
		protected override void OnPause() {
			agent.transform.position = pos;
        }
	}
}