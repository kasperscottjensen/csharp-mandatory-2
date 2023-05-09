using UnityEngine;
using Cinemachine;

public class CameraSettingsController : MonoBehaviour
{

    [SerializeField]
    private CinemachineFreeLook cinemachineFreeLook;

    private int _index = 0;
    private readonly int[] _povs = { 50, 70, 30 };

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.C))
        {
            cinemachineFreeLook.m_Lens.FieldOfView = _povs[_index];
            _index++;
            if (_index == 3)
            {
                _index = 0;
            }
        }
    }
    
}
