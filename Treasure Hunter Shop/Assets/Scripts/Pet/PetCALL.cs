using UnityEngine;
using System.Collections;

public class PetCALL : PetState
{
    private void OnEnable()
    {
        
    }

    public void EndAnimation()
    {
        GetComponentInParent<PetManager>().SetState(PetStatus.MOVE);
    }
}
