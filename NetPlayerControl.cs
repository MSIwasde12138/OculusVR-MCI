using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class NetPlayerControl : NetworkBehaviour
{

    public GameObject playerCam;
    public PlayerAnimator pa;

    // Start is called before the first frame update
    void Start()
    {
        if (isLocalPlayer)
        {
            Debug.Log("玩家本地化成功");
            PlayerLook pl = gameObject.GetComponentInChildren<PlayerLook>();
            pl.enabled = true;
            PlayerMove pm = gameObject.GetComponent<PlayerMove>();
            pm.enabled = true;
            PlayerAnimator pa = gameObject.GetComponent<PlayerAnimator>();
            pa.enabled = true;
            CharacterController cc = gameObject.GetComponent<CharacterController>();
            cc.enabled = true;
            Animator am = gameObject.GetComponent<Animator>();
            am.enabled = true;
        }
    }

    /// <summary>
    /// 第一/第三人称控制器玩家的必须操作，保证自己的眼睛在多人游戏里长在自己身上，否则所有玩家的眼睛都会长到最新进入的玩家身上
    /// 若只有一个相机，所有玩家共用，则无需考虑此问题
    /// </summary>
    public override void OnStartLocalPlayer()
    {
        base.OnStartLocalPlayer();
        playerCam.SetActive(true);
    }

    /// <summary>
    /// 功能1：吃豆豆比赛，每碰到一个小球得分+1
    /// 功能2：场景交互，走到门附近的玩家让门开启，离开门则门关闭
    /// 注意：Character Controller自带一个Collider
    /// </summary>
    /// <param name="other"></param>
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag.Equals("Ball") && isLocalPlayer)
            //每个本地玩家撞到了Ball
        {
            CmdOnrecord();
            CmdOnDestroyBall(other.gameObject);

            gameObject.GetComponent<PlayerAnimator>().OnCheering();
        }

        if (other.gameObject.tag.Equals("Door") && isLocalPlayer)
            //每个本地玩家撞到了Door
        {
            CmdOnDestroyDoor(other.gameObject);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag.Equals("Door") && isLocalPlayer)
        {
            CmdOnRecoverDoor(other.gameObject);
        }
    }

    [Command]
    void CmdOnrecord()
    {
        NetworkIdentity nd = gameObject.GetComponent<NetworkIdentity>();
        TargetplayerScore(nd.connectionToClient, 10);
    }

    [Command]
    private void CmdOnDestroyBall(GameObject go)
    {
        Destroy(go);
    }

    /// <summary>
    /// 每个碰到小球的客户端玩家得分+1并在UI上显示
    /// </summary>
    /// <param name="targetconnection"></param>
    /// <param name="count"></param>
    [TargetRpc]
    void TargetplayerScore(NetworkConnection targetconnection, int count)
    {
        UIControl.instance.AddBallscore(count);
    }

    /// <summary>
    /// 销毁未作为SpawnPrefab的Door，保证Door在服务端被销毁(Door需要挂载NetowrkIdentity)
    /// 如果在碰撞检测的判断中条件是"isLocalPlayer"，则需要在此段加前缀Command以向服务器发出请求，在服务器处理碰撞后的事件；
    /// 如果条件是"isServer"，则碰撞检测直接在服务器进行,此段内容写在if语句中，而不是这里
    /// 当要进行操作的物体不是SpawnPrefab时，需要ClientRpc段并给其传参以保证每个客户端的同步
    /// </summary>
    /// <param name="fa"></param>
    [Command]
    private void CmdOnDestroyDoor(GameObject fa)
    {
        fa.GetComponent<DoorAnimatorControl>().OnOpening();
        RpcOnDestroyDoor(fa);
    }
    /// <summary>
    /// 销毁未作为SpawnPrefab的Door，保证Door在服务端被销毁后在每个客户端被同步销毁(Door需要挂载NetowrkIdentity)
    /// 对于要操作的物体不是SpawnPrefab，此段必须存在，用于同步操作到所有客户端，毕竟这个物体只是个本地物体
    /// </summary>
    /// <param name="fa"></param>
    [ClientRpc]
    private void RpcOnDestroyDoor(GameObject fa)
    {
        fa.GetComponent<DoorAnimatorControl>().OnOpening();
    }

    [Command]
    private void CmdOnRecoverDoor(GameObject fa)
    {
        fa.GetComponent<DoorAnimatorControl>().OnClosing();
        RpcOnRecoverDoor(fa);
    }
    [ClientRpc]
    private void RpcOnRecoverDoor(GameObject fa)
    {
        fa.GetComponent<DoorAnimatorControl>().OnClosing();
    }

    // Update is called once per frame
    //走路动画控制
    void Update()
    {
        bool iw;
        if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.D))
        {
            iw = true;
            pa.OnWalking(iw);
        }
        if (Input.GetKeyUp(KeyCode.W) || Input.GetKeyUp(KeyCode.A) || Input.GetKeyUp(KeyCode.S) || Input.GetKeyUp(KeyCode.D))
        {
            iw = false;
            pa.OnWalking(iw);
        }
    }

}
