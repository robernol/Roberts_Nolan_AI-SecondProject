using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;


namespace NodeCanvas.Tasks.Actions {

	public class PositionAT : ActionTask {

		public BBParameter<Transform> player;
		public BBParameter<float> speed, ramTimer;
		public BBParameter<Pearl> pearl;

        protected override string OnInit() {
			return null;
		}

		//This is called once each time the task is enabled.
		//Call EndAction() to mark the action as finished, either in success or failure.
		//EndAction can be called from anywhere.
		protected override void OnExecute() {
			
		}

		//Called once per frame while the action is active.
		protected override void OnUpdate() {
			if (pearl.value.GetState() == 1)
			{
				ramTimer.value = 0;
			}
			else
			{
				ramTimer.value = 1;
			}
				agent.transform.LookAt(player.value.transform);
			if (!agent.GetComponent<Fish>().ramRange)
			{
                agent.transform.position += agent.transform.forward * Time.deltaTime * speed.value;
            }
			else
			{
                EndAction(true);
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