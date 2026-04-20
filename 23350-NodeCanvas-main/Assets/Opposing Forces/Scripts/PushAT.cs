using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;


namespace NodeCanvas.Tasks.Actions {

	public class PushAT : ActionTask {

		public BBParameter<GameObject> pushObject, fish;

        protected override string OnInit() {
			return null;
		}

		protected override void OnExecute() {
			pushObject.value.GetComponent<Rigidbody>().AddForce(new Vector3(0, 0, -10000)); //when hit by the closing clam, player is launched towards the back of the level with explosive force
            EndAction(true);
		}

		protected override void OnUpdate() {
			
		}

		protected override void OnStop() {
			
		}

		protected override void OnPause() {
			
		}
	}
}