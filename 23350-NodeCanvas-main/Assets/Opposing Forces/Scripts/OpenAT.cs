using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;


namespace NodeCanvas.Tasks.Actions {

	public class OpenAT : ActionTask {

		public GameObject hinge;

		protected override string OnInit() {
			return null;
		}

		protected override void OnExecute() {
			
		}

		protected override void OnUpdate() {
			Vector3 temp = hinge.transform.eulerAngles; //rotates the top half of the clam until it is sufficiently open
            temp.x += 100 * Time.deltaTime;
			hinge.transform.eulerAngles = temp;
			if (temp.x > 79)
			{
				temp.x = 79;
                hinge.transform.eulerAngles = temp;
                EndAction(true);
            }
        }

		protected override void OnStop() {
			
		}

		protected override void OnPause() {
			
		}
	}
}