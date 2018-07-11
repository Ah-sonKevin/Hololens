
using HoloToolkit.Sharing;
using HoloToolkit.Sharing.Spawning;
using HoloToolkit.Sharing.SyncModel;
using HoloToolkit.Sharing.Tests;
using HoloToolkit.Unity.InputModule;
using UnityEngine;
using UnityEngine.XR.WSA.Input;


public class MySyncDataModel : SyncObject
{
    [SyncData]
    private SyncBool firstTap;

    
}