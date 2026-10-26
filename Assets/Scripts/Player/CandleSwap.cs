using UnityEngine;
using StarterAssets;
using UnityEngine.InputSystem;
using Unity.Cinemachine;

public class CandleSwap : MonoBehaviour
{
    [Header("Candle Assignment")]
    public GameObject startCandle; //I need to update this to be the self of the candle selected later...
    public GameObject endCandle;
    public CinemachineCamera cineCam;
    private bool m_isControllingStartCandle = true;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if (startCandle == null && endCandle == null)
        {
            Debug.LogWarning("The candles have not been set up in the inspector, fix it dingus.");
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SwapCandle()
    {
        //set the current "start candle" inactive in the hierarchy
        startCandle.SetActive(false);
        //get and set the Character Controller of the new candle active
        endCandle.TryGetComponent<CharacterController>(out CharacterController endController);
        endController.enabled = true;
        //get and set the ThirdPersonController of the new candle active
        endCandle.TryGetComponent<ThirdPersonController>(out ThirdPersonController thirdPersonController);
        thirdPersonController.enabled = true;
        //get and set the PlayerInput of the new candle active
        endCandle.TryGetComponent<PlayerInput>(out PlayerInput playerInput);
        playerInput.enabled = true;
        //get and set the StarterAssetInputs script of the new candle active
        endCandle.TryGetComponent<StarterAssetsInputs>(out StarterAssetsInputs starterAssetsInputs);
        starterAssetsInputs.enabled = true;
        //get and set the Collider of the new candle inactive
        endCandle.TryGetComponent<CapsuleCollider>(out CapsuleCollider capsuleCollider);
        capsuleCollider.enabled = false;
        //
        endCandle.transform.Find("Flame").gameObject.SetActive(true);
        endCandle.tag = "Player";
    }

    void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("CheckPoint"))
        {
            Debug.Log("IN RANGE OF NEW CANDLE");
        }
        
        if (Input.GetKeyDown(KeyCode.E))
        {
            Debug.Log("E pressed");
            SwapCandle();
            cineCam = GameObject.FindFirstObjectByType<CinemachineCamera>();
            Transform playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
        
            if (cineCam != null)
            {
                cineCam.Follow = playerTransform;
                cineCam.LookAt = playerTransform; 
            }
            m_isControllingStartCandle = false;
        }
    }
}
