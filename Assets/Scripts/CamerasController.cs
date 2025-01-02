using Cinemachine;
using UnityEngine;
using Zenject;

public class CamerasController : MonoBehaviour
{
   [SerializeField] private CinemachineVirtualCamera _startCamera;
   [SerializeField] private CinemachineVirtualCamera _followCamera;
   
   private bool _isShaking = false;

   [Inject]
   private void Construct (GameController gameController)
   {
      gameController.OnGameStarted += () => { SwitchCamera(Enums.CameraType.Follow); };
   }

   private void Start()
   {
      SwitchCamera(Enums.CameraType.Start);
   }

   private void SwitchCamera(Enums.CameraType cameraType)
   {
      _startCamera.gameObject.SetActive(cameraType == Enums.CameraType.Start);
      _followCamera.gameObject.SetActive(cameraType == Enums.CameraType.Follow);
   }
}
