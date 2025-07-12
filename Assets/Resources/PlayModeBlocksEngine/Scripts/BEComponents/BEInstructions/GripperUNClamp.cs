using JetBrains.Annotations;
using UnityEngine;

public class GripperUNClamp : BEInstruction
{

    public SkinnedMeshRenderer gripper;

    public override void BEFunction(BETargetObject targetObject, BEBlock beBlock)
    {
        gripper.SetBlendShapeWeight(0, 0);
        gripper.SetBlendShapeWeight(1, 0);
        BeController.PlayNextOutside(beBlock);
    }

}
