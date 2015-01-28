using UnityEngine;
using System.Collections;
using Leap;

public class _Test1 : MonoBehaviour {

    Controller controller = new Controller();

	// Use this for initialization
	void Start () {
        controller.EnableGesture(Gesture.GestureType.TYPE_CIRCLE);
        controller.EnableGesture(Gesture.GestureType.TYPE_KEY_TAP);
        controller.EnableGesture(Gesture.GestureType.TYPE_SWIPE);
	
	}
	
	// Update is called once per frame
	void FixedUpdate () {

        if (controller.IsConnected)
        {
            Debug.Log("CONNECTED");

            // wait until Controller.isConnected() evaluates to true
            //...

            Frame frame = controller.Frame();
            HandList hands = frame.Hands;
            PointableList pointables = frame.Pointables;
            FingerList fingers = frame.Fingers;
            ToolList tools = frame.Tools;


            //Alden wrote:
            //Gesture gesture = frame.Gestures;

            //for (int g = 0; g < frame.Gestures().Count; g++)
            //{
            //    switch (frame.Gestures()[g].Type)
            //    {
            //        case Gesture.GestureType.TYPE_CIRCLE:
            //            //Handle circle gestures
            //            Debug.Log("CIRCLE");
            //            break;
            //        case Gesture.GestureType.TYPE_KEY_TAP:
            //            //Handle key tap gestures
            //            Debug.Log("KEY TAP");
            //            break;
            //        case Gesture.GestureType.TYPE_SCREEN_TAP:
            //            //Handle screen tap gestures
            //            Debug.Log("SCREEN TAP");
            //            break;
            //        case Gesture.GestureType.TYPE_SWIPE:
            //            //Handle swipe gestures
            //            Debug.Log("SWIPE");
            //            break;
            //        default:
            //            //Handle unrecognized gestures
            //            Debug.Log("UNRECOGNIZED");
            //            break;
            //    }
            //}

            Debug.Log(checkForSwipe());

        }
        else
        {
            Debug.Log("NOT CONNECTED");

        }
	
	}

    //Alden found:
    //http://thomaswinther.no/techtalk/leap-motion-full-hand-gesture
    int continuousFramesThatRightMovementWasDetected;
    int continuousFramesThatLeftMovementWasDetected;
    int numberOfContinuousUnidirectionalFramesNeededForGesture;

    string checkForSwipe()
    {
        Vector motionSinceLastFrame =
            controller.Frame().Translation(controller.Frame(1));
        if (motionSinceLastFrame.x > 8.0f)
        {
            continuousFramesThatRightMovementWasDetected++;
        }
        else
        {
            continuousFramesThatRightMovementWasDetected = 0;
        }
        if (motionSinceLastFrame.x < -8.0f)
        {
            continuousFramesThatLeftMovementWasDetected++;
        }
        else
        {
            continuousFramesThatLeftMovementWasDetected = 0;
        }

        if (continuousFramesThatLeftMovementWasDetected >=
            numberOfContinuousUnidirectionalFramesNeededForGesture)
        {
            return Leap.Vector.Left.ToString();
        }
        else if (continuousFramesThatRightMovementWasDetected >=
            numberOfContinuousUnidirectionalFramesNeededForGesture)
        {
            return Leap.Vector.Right.ToString();
        }
        else
        {
            return new Leap.Vector(0, 0, 0).ToString();
        }
    }

}
