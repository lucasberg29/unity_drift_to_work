using UnityEngine;
using Unity.Cinemachine;

public class CameraScript : CinemachineExtension
{
    public float xPosition = 0;
    public float yPosition = 16;

    protected override void PostPipelineStageCallback(
        CinemachineVirtualCameraBase vcam,
        CinemachineCore.Stage stage, ref CameraState state, float deltaTime)
    {
        if (stage == CinemachineCore.Stage.Body)
        {
            var pos = state.RawPosition;
            pos.x = xPosition;
            pos.y = yPosition;
            state.RawPosition = pos;
        }
    }
}
