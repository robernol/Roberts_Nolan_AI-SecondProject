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

		protected override string OnInit() {
			return null;
		}

		protected override void OnExecute() {
			timer = Time.time + duration; //sets timer
			originalRot = agent.transform.eulerAngles; //stores original rotation
		}

		protected override void OnUpdate() {
			if (Time.time > timer)
			{
                agent.transform.LookAt(player.value); //looks at the player again before ending
                EndAction(true);
			}
			else
			{
				agent.transform.LookAt(player.value);
				Vector3 temp = originalRot;
				temp.y += swishPath.Evaluate(Time.time); //follows an animationcurve to swish side to side before charging
				agent.transform.eulerAngles = temp;
			}
		}

		protected override void OnStop() {
			
		}

		protected override void OnPause() {
			
		}
	}
}