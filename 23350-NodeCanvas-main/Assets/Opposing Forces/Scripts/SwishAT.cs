using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;


namespace NodeCanvas.Tasks.Actions {

	public class SwishAT : ActionTask {

		Vector3 originalRot;
		public AnimationCurve swishPath;
		public BBParameter<Transform> player;
		public float duration;
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
			timer = Time.time + duration;
			originalRot = agent.transform.eulerAngles;
		}

		//Called once per frame while the action is active.
		protected override void OnUpdate() {
			if (Time.time > timer)
			{
                agent.transform.LookAt(player.value);
                EndAction(true);
			}
			else
			{
				agent.transform.LookAt(player.value);
				Vector3 temp = originalRot;
				temp.y += swishPath.Evaluate(Time.time);
				agent.transform.eulerAngles = temp;
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