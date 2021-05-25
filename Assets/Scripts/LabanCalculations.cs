using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LabanCalculations : MonoBehaviour
{
    public GameObject leftHand;
    public GameObject rightHand;
    public GameObject head;

    public Light lamp1;
    public Light lamp2;
    public Light lamp3;
    public Light lamp4;

    public Slider slider1;
    public Slider slider2;
    public Slider slider3;
    public Slider slider4;



    private Vector3 lastPosition;
    private Vector3 lastVelocity;
    private Vector3 lastAcceleration;

    private Vector3 lastRPosition;
    private Vector3 lastRVelocity;
    private Vector3 lastRAcceleration;

    public Vector3 objectAcceleration;
    public Vector3 objectVelocity;
    public Vector3 objectJerk;

    public Vector3 rightAcceleration;
    public Vector3 rightVelocity;
    public Vector3 rightJerk;

    public Vector3 headVelocity;

    public double oldVal = 50;


    int frames = 0;



    // Start is called before the first frame update
    void Start()
    {
        

    }

    // Update is called once per frame
    void Update()
    {
        ++frames;


        if (frames == 4)
        {
            frames = 0;

            //lefthand
            Vector3 position = leftHand.transform.position;
            Vector3 velocity = (position - lastPosition) / Time.deltaTime;
            Vector3 acceleration = (velocity - lastVelocity) / Time.deltaTime;

            objectVelocity = velocity;
            objectAcceleration = acceleration;

            objectJerk = ((leftHand.transform.position + 2 * objectVelocity * Time.deltaTime) - 2 * (leftHand.transform.position + objectVelocity * Time.deltaTime) + 2 * (lastPosition) - (lastPosition - lastVelocity * Time.deltaTime)) / (2 * Mathf.Pow(Time.deltaTime, 3));

            //right hand
            Vector3 rposition = rightHand.transform.position;
            Vector3 rvelocity = (rposition - lastRPosition) / Time.deltaTime;
            Vector3 racceleration = (rvelocity - lastRVelocity) / Time.deltaTime;

            rightVelocity = rvelocity;
            rightAcceleration = racceleration;

            rightJerk = ((rightHand.transform.position + 2 * rightVelocity * Time.deltaTime) - 2 * (rightHand.transform.position + rightVelocity * Time.deltaTime) + 2 * (lastRPosition) - (lastRPosition - lastRVelocity * Time.deltaTime)) / (2 * Mathf.Pow(Time.deltaTime, 3));

            Vector3 hPosition = leftHand.transform.position;
            Vector3 hVelocity = (position - lastPosition) / Time.deltaTime;
            Vector3 hAcceleration = (velocity - lastVelocity) / Time.deltaTime;

            headVelocity = hVelocity;




            slider1.SetValueWithoutNotify(Scale(0, 60, 0, 1, CalculateWeightEffort()));
            slider2.SetValueWithoutNotify(Scale(0, 800, 0, 1, CalculateTimeEffort()));
            slider3.SetValueWithoutNotify(CalculateSpaceEffort());
            slider4.SetValueWithoutNotify(Scale(0, 10000, 0, 1, CalculateFlowEffort()));



            lastAcceleration = acceleration;
            lastVelocity = velocity;
            lastPosition = position;

            lastRAcceleration = racceleration;
            lastRVelocity = rvelocity;
            lastRPosition = rposition;





        }



        lamp1.intensity = lamp2.intensity = lamp3.intensity = lamp4.intensity = Scale(0, 800, 0.1f, 4, CalculateTimeEffort());
       




    }

    float CalculateWeightEffort()
    {
        //strong or light
        float weight = 0;
        weight += rightVelocity.sqrMagnitude;
        return weight;
    }

    float CalculateTimeEffort()
    {
        float time = 0;
        time += Mathf.Sqrt(rightAcceleration.sqrMagnitude);
        return time;
    }

    float CalculateSpaceEffort()
    {

        Vector3 left;
        Vector3 right;
        Vector3 middle;
        Vector3 root;
        float space;

        left = head.transform.position - leftHand.transform.position;
        right = head.transform.position - rightHand.transform.position;
        middle = Vector3.Cross(right, left);

        root = headVelocity;

        space = Mathf.Abs(Vector3.Dot(middle, root));
        return space;
    }
    

    float CalculateFlowEffort()
    {
        float flow = 0;
        flow += Mathf.Sqrt(rightJerk.sqrMagnitude);
        return flow;
    }


    float Scale(float OldMin, float OldMax, float NewMin, float NewMax, float OldValue)
    {

        float OldRange = (OldMax - OldMin);
        float NewRange = (NewMax - NewMin);
        float NewValue = (((OldValue - OldMin) * NewRange) / OldRange) + NewMin;

        return (NewValue);
    }



}
