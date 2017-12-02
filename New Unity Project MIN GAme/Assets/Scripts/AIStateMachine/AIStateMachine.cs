using UnityEngine;
using System.Collections;

public class AIStateMachine : MonoBehaviour {

    //Define States of out AI
    public enum AIState
    {
        Petrol,
        Alert,
        Attack,
        Smoke,
        Drink,
        Die
    }
    //Show it in the inspector also we can change AI state from inspector
    public AIState aiState;
    public Light pLight;

    private void Start()
    {
        //Set the first state in start
        aiState = AIState.Smoke;
    }

    // Update is called once per frame
    void Update () {

        //Check if we press input key 1
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            //Change the state to Smoke
            aiState = AIState.Smoke;
            //Run the code when we change the state
            SwithState();
        }


        //Repeat first for all other states
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            aiState = AIState.Drink;
            SwithState();
        }

        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            aiState = AIState.Petrol;
            SwithState();
        }

        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            aiState = AIState.Alert;
            SwithState();
        }

        if (Input.GetKeyDown(KeyCode.Alpha5))
        {
            aiState = AIState.Attack;
            SwithState();
        }

        if (Input.GetKeyDown(KeyCode.Alpha6))
        {
            aiState = AIState.Die;
            SwithState();
        }
    }

    void SwithState()
    {
        //Imageine this as an if statement here we define which enum we want to use
        switch (aiState)
        {
            //We check what is our case currently That means that if the current AI state(Enum) is Petrol we will run the code below
            case AIState.Petrol:
                //If our sate is petrol change the light color to green
                //If it's not move on to the next one
                pLight.color = Color.green;
                break;
            //Until we find the our current state that we set above we continue looking and when we find it we run the code between case and break
            //This is why above aiState = AIState.Alert is important if we don't do this we can never call the function we assign to the alert sate. We call 
            // SwithState() method after assigning the AI state if we don't call this our light color will not change. We can simply write this to the update but for the sake
            //of perfomance we can just call it once.
            case AIState.Alert:
                pLight.color = Color.yellow;
                break;
            case AIState.Attack:
                pLight.color = Color.red;
                break;
            case AIState.Smoke:
                pLight.color = Color.magenta;
                break;
            case AIState.Drink:
                pLight.color = Color.white;
                break;
            case AIState.Die:
                pLight.color = Color.blue;
                break;
        }
    }
}
