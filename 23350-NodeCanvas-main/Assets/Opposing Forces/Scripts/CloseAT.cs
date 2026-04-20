using NodeCanvas.Framework;
using NodeCanvas.Tasks.Conditions;
using ParadoxNotion.Design;
using Unity.VisualScripting;
using UnityEngine;


namespace NodeCanvas.Tasks.Actions
{

    public class CloseAT : ActionTask
    {
        public GameObject hinge, lid;

        protected override string OnInit()
        {
            return null;
        }

        protected override void OnExecute()
        {

        }

        protected override void OnUpdate()
        {
            Vector3 temp = hinge.transform.eulerAngles; //rotates the top half of the clam until it is closed again
            temp.x -= 300 * Time.deltaTime;
            hinge.transform.eulerAngles = temp;

            if ((temp.x < 1) || (temp.x > 300))
            {
                temp.x = 1;
                hinge.transform.eulerAngles = temp;
                EndAction(true);
            }
        }

        protected override void OnStop()
        {

        }

        protected override void OnPause()
        {

        }

    }
}