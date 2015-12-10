using System;
using UnityEngine;


public class CameraAngles : MonoBehaviour
{
    public CameraAngle Angle;
    public static bool IsMoving = false;
    public static Camera _camera;
    public static CameraMoves _currentMovement;

    public void Update()
    {
        if(IsMoving)
            MoveCamera();
    }

    public void MoveCamera()
    {
        
        switch (_currentMovement)
        {
            case CameraMoves.None:
                break;
            case CameraMoves.ZoomInSlow:
                _camera.transform.Translate(Vector3.forward * Time.deltaTime * 0.005f, Space.Self);
                break;
            case CameraMoves.ZoomIn:
                _camera.transform.Translate(Vector3.forward * Time.deltaTime * 0.016f, Space.Self);
                break;
            case CameraMoves.ZoomOutSlow:
                _camera.transform.Translate(Vector3.back * Time.deltaTime * 0.006f, Space.Self);
                break;
            case CameraMoves.ZoomOut:
                _camera.transform.Translate(Vector3.back * Time.deltaTime * 0.015f, Space.Self);
                break;
            case CameraMoves.MoveUp:
                _camera.transform.Translate(Vector3.up * Time.deltaTime * 0.02f, Space.Self);
                break;
            case CameraMoves.MoveDown:
                _camera.transform.Translate(Vector3.down * Time.deltaTime * 0.02f, Space.Self);
                break;
            case CameraMoves.MoveLeft:
                _camera.transform.Translate(Vector3.left * Time.deltaTime * 0.02f, Space.Self);
                break;
            case CameraMoves.MoveRight:
                _camera.transform.Translate(Vector3.right * Time.deltaTime * 0.02f, Space.Self);
                break;
            case CameraMoves.TurnLeftSlow:
                _camera.transform.Rotate(Vector3.down * Time.deltaTime * 0.1f, Space.Self);
                break;
            case CameraMoves.TurnLeft:
                _camera.transform.Rotate(Vector3.down * Time.deltaTime, Space.Self);
                break;
            case CameraMoves.TurnRightSlow:
                _camera.transform.Rotate(Vector3.up * Time.deltaTime * 0.1f, Space.Self);
                break;
            case CameraMoves.TurnRight:
                _camera.transform.Rotate(Vector3.up * Time.deltaTime, Space.Self);
                break;
            case CameraMoves.TurnUpSlow:
                _camera.transform.Rotate(Vector3.left * Time.deltaTime * 0.1f, Space.Self);
                break;
            case CameraMoves.TurnUp:
                _camera.transform.Rotate(Vector3.left * Time.deltaTime, Space.Self);
                break;
            case CameraMoves.TurnDownSlow:
                _camera.transform.Rotate(Vector3.right * Time.deltaTime * 0.1f, Space.Self);
                break;
            case CameraMoves.TurnDown:
                _camera.transform.Rotate(Vector3.right * Time.deltaTime, Space.Self);
                break;
            case CameraMoves.TurnRoundNPCLeft:
                _camera.transform.RotateAround(GameManager.NPCs[DialoguePlayback.NPC].position, Vector3.up, 3f * Time.deltaTime);
                break;
            case CameraMoves.TurnRoundNPCLeftSlow:
                _camera.transform.RotateAround(GameManager.NPCs[DialoguePlayback.NPC].position, Vector3.up, .4f * Time.deltaTime);
                break;
            case CameraMoves.TurnRoundNPCRight:
                _camera.transform.RotateAround(GameManager.NPCs[DialoguePlayback.NPC].position, Vector3.down, 3f * Time.deltaTime);
                break;
            case CameraMoves.TurnRoundNPCRightSlow:
                _camera.transform.RotateAround(GameManager.NPCs[DialoguePlayback.NPC].position, Vector3.down, .4f * Time.deltaTime);
                break;
            case CameraMoves.TurnRoundEmmonLeft:
                _camera.transform.RotateAround(GameManager.Player.transform.position, Vector3.up, 3f * Time.deltaTime);
                break;
            case CameraMoves.TurnRoundEmmonLeftSlow:
                _camera.transform.RotateAround(GameManager.Player.transform.position, Vector3.up, .4f * Time.deltaTime);
                break;
            case CameraMoves.TurnRoundEmmonRight:
                _camera.transform.RotateAround(GameManager.Player.transform.position, Vector3.down, 3f * Time.deltaTime);
                break;
            case CameraMoves.TurnRoundEmmonRightSlow:
                _camera.transform.RotateAround(GameManager.Player.transform.position, Vector3.down, .4f * Time.deltaTime);
                break;
            default:
                break;
        }
    }

    public void StartMovingCamera(Camera camera, CameraMoves movement)
    {
        _camera = camera;
        _currentMovement = movement;
        IsMoving = true;
    }

    public static void StopMovingCamera()
    {
        IsMoving = false;
    }
}
