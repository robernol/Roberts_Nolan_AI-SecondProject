using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;


namespace NodeCanvas.Tasks.Conditions {

	public class ProximityCT : ConditionTask {

		public BBParameter<Transform> player;

		//Use for initialization. This is called only once in the lifetime of the task.
		//Return null if init was successfull. Return an error string otherwise
		protected override string OnInit(){
			return null;
		}

		//Called whenever the condition gets enabled.
		protected override void OnEnable() {
			
		}

		//Called whenever the condition gets disabled.
		protected override void OnDisable() {
			
		}

		//Called once per frame while the condition is active.
		//Return whether the condition is success or failure.
		protected override bool OnCheck() {

			float dist = ((agent.transform.position) - (player.value.position)).magnitude;

            Debug.Log(dist);
			Debug.Log( agent.transform.position);
            if (dist < 30)
			{
				return true;
            }
            return false;
		}
	}
}