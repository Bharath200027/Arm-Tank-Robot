using JetBrains.Annotations;
using UnityEngine;

public class GripperClamp : BEInstruction
{

    public SkinnedMeshRenderer gripper;
    public bool gripperstatus;
    
    public override void BEFunction(BETargetObject targetObject, BEBlock beBlock)
    {
        gripper.SetBlendShapeWeight(0, 30);
        gripper.SetBlendShapeWeight(1, 30);
        gripperstatus = true;
        BeController.PlayNextOutside(beBlock);
    }

}
