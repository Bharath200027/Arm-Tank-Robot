using JetBrains.Annotations;
using UnityEngine;

public class RotateArmDown : BEInstruction
{

    public GameObject[] arm;
    public GameObject wrist;
    public override void BEFunction(BETargetObject targetObject, BEBlock beBlock)
    {
        Debug.Log(arm[0].transform.rotation.z);
        float angle = Mathf.Abs(beBlock.BeInputs.numberValues[0]);
        if ((arm[0].transform.rotation.z > -0.41) && (arm[0].transform.rotation.z < 0.18))
        {
            arm[0].transform.Rotate(0, 0, angle);
            arm[1].transform.Rotate(0, 0, angle);
            wrist.transform.Rotate(0, 0, -angle);
        }
        
        BeController.PlayNextOutside(beBlock);
        /*arm[0].transform.localRotation = Quaternion.Euler(0,0, Mathf.Clamp(arm[0].transform.rotation.z, -0.35f, 0.18f));
        arm[1].transform.localRotation = Quaternion.Euler(0, 0, Mathf.Clamp(arm[0].transform.rotation.z, -0.35f, 0.18f));
        wrist.transform.localRotation = Quaternion.Euler(0, 0, Mathf.Clamp(arm[0].transform.rotation.z, -0.35f, 0.18f));*/


    }

}
