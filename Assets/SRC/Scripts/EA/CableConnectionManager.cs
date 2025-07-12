using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using UnityEngine;
using UnityEngine.UI;

public class CableConnectionManager : MonoBehaviour
{

    public GameObject PlayMode;
    public Transform[] startPoints;
    public Transform[] correspondingEndPoints;

    public GameObject _indicatorPrefab;
    private GameObject _startIndicator;
    private GameObject _endIndicator;

    public GameObject Finish, Done;

    [SerializeField]
    public static bool PMSuccess;
    [SerializeField]
    public static bool TMSuccess;

    public Text _instructionManager;

    public Material[] cableColors;

    
    int completedStep;

    public GameObject ConnectorPrefab;

    [SerializeField]
    private int stepCounter;

    public static int _stepCounter;

    private int hintCounter;

    bool _gameLock = true;

    GameObject PlacedConnector;

    Transform presentStartPin;

    public List<KeyValuePair<Transform, Transform>> CableConnectionMap;
    private List<int> FinishedSteps;

    private KeyValuePair<Transform, Transform> recentConnectionData;

    private ConnectionMode connectionMode = ConnectionMode.OneWay;
    public GameMode gameMode;

   

    public static bool connectionSuccessful;
    public static bool connectorStopMouseFollow;
    bool firstPass = false;

    public enum ConnectionMode
    {
        OneWay, TwoWay
    };

    public enum GameMode
    {
        Training, Practice
    };
 
    // Start is called before the first frame update
    void Start()
    {

        gameMode = Utils.gameMode;

        SetCableConnectionMap();
        FinishedSteps = new List<int>();
        connectionSuccessful = false;
        connectorStopMouseFollow = false;
        stepCounter = 0;
        _stepCounter = 0;
        hintCounter = 0;

        if (!PlayMode.GetComponent<PlayerMode>().PMode)
        {
            if (_instructionManager != null)
            {
                _instructionManager.text = "Make the Wire Connections!";
            
            }
            else
            {
                Debug.Log("Assign an Instruction Manager Object!");
            }
        }
        else if(PlayMode.GetComponent<PlayerMode>().PMode)
        {
            _instructionManager.text = "Make the Wire Connections!";
            _gameLock = false;
        }

      

    }

    // Update is called once per frame
    void Update()
    {
        if (stepCounter != _stepCounter)
        {
            _stepCounter = stepCounter;
            Debug.Log("Step Completed: " + _stepCounter);
        }

        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            var hit = new RaycastHit();
            if (Physics.Raycast(ray, out hit))
            {
                Debug.Log(hit.collider.gameObject.name);
                CheckAndAddConnectionPoint(hit.transform);
            }
            else
            {
                if(PlacedConnector!=null)
                {
                    Destroy(PlacedConnector);
                    presentStartPin = null;

                }
            }
        }

        if(Input.GetKeyDown(KeyCode.H) && PlayMode.GetComponent<PlayerMode>().PMode)
        {
            if(_indicatorPrefab!=null)
                
            DisplayRandomHint();
        }

        if(!PlayMode.GetComponent<PlayerMode>().PMode)
        {
            if (!firstPass)
            {
                _instructionManager.SendMessage("DisplayText", 0, SendMessageOptions.DontRequireReceiver);
                DisplayHintIndicator(CableConnectionMap[0]);
                _gameLock = false;
                firstPass = true;
            }
        }

        if (PlayMode.GetComponent<PlayerMode>().PMode)
        {
            _indicatorPrefab = null;
            _instructionManager.SendMessage("DisplayText", 0, SendMessageOptions.DontRequireReceiver);
            DisplayHintIndicator(CableConnectionMap[0]);
            _gameLock = false;
            firstPass = true;
        }

    }

    void SetCableConnectionMap()
    {
        if(startPoints!=null && correspondingEndPoints!=null)
        {
            if (startPoints.Length == correspondingEndPoints.Length)
            {
                CableConnectionMap = new List<KeyValuePair<Transform, Transform>>();
                for (int i = 0; i < startPoints.Length; i++)
                {
                    CableConnectionMap.Add(new KeyValuePair<Transform, Transform>(startPoints[i], correspondingEndPoints[i]));
                }
            }
        }
         
    }

    //TBO**
    void CheckAndAddConnectionPoint(Transform clickedTransform)
    {
        if (_gameLock)
            return;

        //int start = CheckStartConnection(clickedTransform);

        switch (connectionMode)
        {
            case ConnectionMode.OneWay:
                if ((CheckStartConnection(clickedTransform) != 6969 || CheckEndConnection(clickedTransform) != 6969) && PlacedConnector == null)
                {
                    connectionSuccessful = false;

                    PlacedConnector = Instantiate(ConnectorPrefab, clickedTransform.position, Quaternion.identity);
                    presentStartPin = clickedTransform;
                    PlacedConnector.SendMessage("SetCableMaterial", GetCableMaterial(presentStartPin), SendMessageOptions.DontRequireReceiver);
                    connectorStopMouseFollow = false;



                }
                else if (CheckValidEndPoint(clickedTransform)) 
                {
                    
                    if(gameMode == GameMode.Training)
                    {
                       
                            if (!StepCheck(recentConnectionData))
                            {
                            presentStartPin = null;
                            PlacedConnector = null;

                            return;

                        }
                           
                        
                    }
                    else
                    {
                       if(!PracticeModeMarkStep(recentConnectionData)) return;
                        
                    }
                  
                    
                    connectionSuccessful = true;
                    PlacedConnector.SendMessage("PlaceConnectorEnd", clickedTransform, SendMessageOptions.DontRequireReceiver);
                    connectorStopMouseFollow = true;
                    presentStartPin = null;
                    PlacedConnector = null;
                   
                }
                else
                {
                    Destroy(PlacedConnector);
                    connectionSuccessful = false;
                    connectorStopMouseFollow = true;
                    presentStartPin = null;
                    PlacedConnector = null;
                    if(gameMode == GameMode.Training)
                    {
                        if (stepCounter < CableConnectionMap.Count)
                            DisplayHintIndicator(CableConnectionMap[stepCounter]);
                    }
                    
                }
                break;
               
             //TWO WAY MODE WILL BE REVAMPED. DO NOT USE FOR NOW
            case ConnectionMode.TwoWay:
                if (CheckStartConnection(clickedTransform)!=6969 || CheckEndConnection(clickedTransform)!=6969)
                {
                    if (presentStartPin == null)
                    {
                        connectionSuccessful = false;

                        PlacedConnector = Instantiate(ConnectorPrefab, clickedTransform.position, Quaternion.identity);
                        presentStartPin = clickedTransform;
                        connectorStopMouseFollow = false;
                    }
                  


                }
                if (CheckValidEndPoint(clickedTransform))
                {

                        if (gameMode == GameMode.Training)
                        {
                            if (!StepCheck(recentConnectionData))
                            {
                            presentStartPin = null;
                            PlacedConnector = null;
                            return;
                            }
                                
                        }
                        else
                        {
                            if (!PracticeModeMarkStep(recentConnectionData))
                                return;
                        }

                        connectionSuccessful = true;
                        connectorStopMouseFollow = true;
                        presentStartPin = null;
                        PlacedConnector = null;
                       
                    
                   
                }
                if ((CheckStartConnection(clickedTransform) == CheckEndConnection(presentStartPin)) && (CheckStartConnection(clickedTransform) != 6969 || CheckEndConnection(clickedTransform) != 6969))
                {
                   
                        if (gameMode == GameMode.Training)
                        {
                        if (!StepCheck(recentConnectionData))
                        {
                            presentStartPin = null;
                            PlacedConnector = null;
                            return;
                        }
                                
                        }
                        else
                        {
                            PracticeModeMarkStep(recentConnectionData);
                        }

                        connectionSuccessful = true;
                        connectorStopMouseFollow = true;
                        presentStartPin = null;
                        PlacedConnector = null;
                      
                    
                    

                }
                break;
               

               


        }
        
        

    }


    bool PracticeModeMarkStep(KeyValuePair<Transform, Transform> connectionData)
    {

        if(CableConnectionMap.Contains(connectionData))
        {
            int step = CableConnectionMap.IndexOf(connectionData);
            if (!FinishedSteps.Contains(step))
            {
                FinishedSteps.Add(step);
                stepCounter += 1;
                return true;
            }
            else
                return false;

                
        }
        else
        {
            return false;
        }
    }


   
    public void CheckValidCircuitCompletionPracticeMode()
    {
        
                if ((stepCounter) >= CableConnectionMap.Count)
                {
                    Debug.Log("Circuit is complete!");
                    _instructionManager.text = "Circuit is complete!";
                    PMSuccess = true;
                    TMSuccess = true;
                    Finish.SetActive(true);
                    Done.SetActive(true);

        }

                else
                {
                    Debug.Log("circuit is wrong or incomplete");
                    _instructionManager.text = "Circuit is wrong or incomplete";
                    PMSuccess = false;
                    TMSuccess = false;
                }
                

            


        
      
    }

    

    bool StepCheck(KeyValuePair<Transform, Transform> connectionData)
    {



       
        completedStep = CableConnectionMap.IndexOf(connectionData);

        if (stepCounter == completedStep)
        {
            stepCounter += 1;
            if(_instructionManager!=null)
            {
                if (PlayMode.GetComponent<PlayerMode>().PMode)
                {
                    switch (stepCounter)
                    {
                        case 0:
                        case 1:
                        case 2:
                        case 3:
                        case 4:
                            _instructionManager.text = "Make Wire Connections!";
                            break;
                        case 5:
                            _instructionManager.text = "Click On Check Connections";
                            break;
                    }
                    
                }
                else
                {
                    switch (stepCounter)
                    {
                        case 0:
                            _instructionManager.text = "Connect Wheel 1 Motor to Port 2";
                            break;
                        case 1:
                            _instructionManager.text = "Connect Arm Motor to Port 3";
                            break;
                        case 2:
                            _instructionManager.text = "Connect Wheel 2 Motor to Port 4";
                            break;
                        case 3:
                            _instructionManager.text = "Connect Gripper Motor to Port 1";
                            break;
                        case 4:
                            _instructionManager.text = "Connect the Battery";
                            break;
                        case 5:
                            _instructionManager.text = "Click on Check Connections!";
                            break;
                    }
                }
                
            }
            else
            {
                Debug.Log("Assign an Instruction Manager Object!");
            }
            Debug.Log("Step check successful. Go for step " + stepCounter);

            if(stepCounter < CableConnectionMap.Count)
                DisplayHintIndicator(CableConnectionMap[stepCounter]);
          
            return true;

        }

        else
        {
            //_instructionManager.SendMessage("DisplayText", "Check the steps! Please perform them in order");
            //Debug.Log("Step check failed. Perform the connections in order!");

            if (stepCounter < CableConnectionMap.Count)
                DisplayHintIndicator(CableConnectionMap[stepCounter]);

            Destroy(PlacedConnector);
            presentStartPin = null;
            PlacedConnector = null;

            return false;
        }
    }

    //TBO
    int CheckStartConnection(Transform transform)
    {
        for(int i = 0; i<startPoints.Length; i++)
        {
            if (transform == startPoints[i])
                return i;
           
        }
        return 6969;
    }

    //TBO
    int CheckEndConnection(Transform transform)
    {
        for (int i = 0; i < correspondingEndPoints.Length; i++)
        {
            if (transform == correspondingEndPoints[i])
                return i;

        }
        return 6969;
    }

    bool CheckValidEndPoint(Transform t)
    {
        if (CableConnectionMap != null && CableConnectionMap.Count > 0)
        {
            if (presentStartPin != null)
            {
                foreach (KeyValuePair<Transform, Transform> pair in CableConnectionMap)
                {
                    if (pair.Key == presentStartPin)
                    {
                        if (pair.Value == t)
                        {
                            if (_startIndicator != null)
                                Destroy(_startIndicator);

                            if (_endIndicator != null)
                                Destroy(_endIndicator);
                            recentConnectionData = pair;
                            return true;
                        }
                           
                      
                    }
                 


                        if (pair.Value == presentStartPin)
                        {
                            if (pair.Key == t)
                            {
                            if (_startIndicator != null)
                                Destroy(_startIndicator);

                            if (_endIndicator != null)
                                Destroy(_endIndicator);
                            recentConnectionData = pair;
                                return true;
                            }

                        }
                    
                  
                }
            }
            return false;
        }
        else
            return false;

    }

    Material GetCableMaterial(Transform t)
    {
        if (cableColors != null && cableColors.Length > 0)
        {
            if (t.CompareTag("G"))
                return cableColors[0];

            else if (t.CompareTag("P"))
                return cableColors[1];

            else
                return cableColors[2];
        }
        else
        {
            return null;
        }

    }

    public void SetGameMode(GameMode _gameMode)
    {
        this.gameMode = _gameMode;
    }


    public void DisplayHintIndicator(KeyValuePair<Transform, Transform> connection)
    {
        if(_indicatorPrefab!=null)
        {
            if (_startIndicator != null)
                Destroy(_startIndicator);

            if (_endIndicator != null)
                Destroy(_endIndicator);

             _startIndicator = Instantiate(_indicatorPrefab, connection.Key.position, _indicatorPrefab.transform.rotation);
             _endIndicator = Instantiate(_indicatorPrefab, connection.Value.position, _indicatorPrefab.transform.rotation);
           
        }
    }


    public void DisplayRandomHint()
    {

        if (FinishedSteps.Count >= CableConnectionMap.Count)
            return;

       
       
        
        if (_indicatorPrefab != null)
        {
            if(hintCounter<CableConnectionMap.Count)
            {
                while (FinishedSteps.Contains(hintCounter))
                {
                    hintCounter += 1;
                    if (hintCounter >= CableConnectionMap.Count)
                        hintCounter = 0;

                }


                DisplayHintIndicator(CableConnectionMap[hintCounter]);

                _instructionManager.SendMessage("DisplayText", hintCounter, SendMessageOptions.DontRequireReceiver);
                hintCounter += 1;
                return;
            }
            else
            {
                hintCounter = 0;
            }
            
           
                   
               
            
           

           

            

        }
           
        
    }

    


}
