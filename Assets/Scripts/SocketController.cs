using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class SocketController : MonoBehaviour
{
    private Transform objectInitialParent = default;
    private Vector3 objectInitialScale = default;
    private XRSocketInteractor _socketI;

    void Awake()
    {
        _socketI = gameObject.GetComponent<XRSocketInteractor>();
        _socketI.selectEntered.AddListener(SelectEntered);
        _socketI.selectExited.AddListener(SelectExited);
    }

    private void SelectEntered(SelectEnterEventArgs args)
    {
        IXRInteractable interactable = args.interactableObject;
        objectInitialScale = interactable.transform.localScale;

        objectInitialParent = interactable.transform.parent;
        interactable.transform.parent = transform;
        Debug.Log("SelectEntered");
    }

    private void SelectExited(SelectExitEventArgs args)
    {
        IXRInteractable interactable = args.interactableObject;
        interactable.transform.localScale = objectInitialScale;

        interactable.transform.parent = objectInitialParent;
        Debug.Log("SelectExited");
    }
}
