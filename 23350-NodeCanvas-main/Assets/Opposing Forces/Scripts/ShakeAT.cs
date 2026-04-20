using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;


namespace NodeCanvas.Tasks.Actions {

	public class ShakeAT : ActionTask {

		Vector3 pos;
		public float shakeTime;
		float timer;

		protected override string OnInit() {
			return null;
		}

		protected override void OnExecute() { //stores the original position of the clam
			pos = agent.transform.position;
			timer = Time.time + shakeTime;
        }

		protected override void OnUpdate()
		{
			Vector3 temp = pos; //randomly shakes in all directions to convey the clam is about to close
			temp.x += Random.Range(-0.1f, 0.1f);
			temp.y += Random.Range(-0.1f, 0.1f);
			temp.z += Random.Range(-0.1f, 0.1f);
			agent.transform.position = temp;

			if (Time.time > timer)
			{
				EndAction(true);
			}
		}

		protected override void OnStop() {
			agent.transform.position = pos; //resets the position of the clam when not in use
        }

		protected override void OnPause() {
			agent.transform.position = pos;
        }
	}
}