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
            Debug.Log("��ұ��ػ��ɹ�");
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
    /// ��һ/�����˳ƿ�������ҵı����������֤�Լ����۾��ڶ�����Ϸ�ﳤ���Լ����ϣ�����������ҵ��۾����᳤�����½�����������
    /// ��ֻ��һ�������������ҹ��ã������迼�Ǵ�����
    /// </summary>
    public override void OnStartLocalPlayer()
    {
        base.OnStartLocalPlayer();
        playerCam.SetActive(true);
    }

    /// <summary>
    /// ����1���Զ���������ÿ����һ��С��÷�+1
    /// ����2�������������ߵ��Ÿ�����������ſ������뿪�����Źر�
    /// ע�⣺Character Controller�Դ�һ��Collider
    /// </summary>
    /// <param name="other"></param>
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag.Equals("Ball") && isLocalPlayer)
            //ÿ���������ײ����Ball
        {
            CmdOnrecord();
            CmdOnDestroyBall(other.gameObject);

            gameObject.GetComponent<PlayerAnimator>().OnCheering();
        }

        if (other.gameObject.tag.Equals("Door") && isLocalPlayer)
            //ÿ���������ײ����Door
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
    /// ÿ������С��Ŀͻ�����ҵ÷�+1����UI����ʾ
    /// </summary>
    /// <param name="targetconnection"></param>
    /// <param name="count"></param>
    [TargetRpc]
    void TargetplayerScore(NetworkConnection targetconnection, int count)
    {
        UIControl.instance.AddBallscore(count);
    }

    /// <summary>
    /// ����δ��ΪSpawnPrefab��Door����֤Door�ڷ���˱�����(Door��Ҫ����NetowrkIdentity)
    /// �������ײ�����ж���������"isLocalPlayer"������Ҫ�ڴ˶μ�ǰ׺Command������������������ڷ�����������ײ����¼���
    /// ���������"isServer"������ײ���ֱ���ڷ���������,�˶�����д��if����У�����������
    /// ��Ҫ���в��������岻��SpawnPrefabʱ����ҪClientRpc�β����䴫���Ա�֤ÿ���ͻ��˵�ͬ��
    /// </summary>
    /// <param name="fa"></param>
    [Command]
    private void CmdOnDestroyDoor(GameObject fa)
    {
        fa.GetComponent<DoorAnimatorControl>().OnOpening();
        RpcOnDestroyDoor(fa);
    }
    /// <summary>
    /// ����δ��ΪSpawnPrefab��Door����֤Door�ڷ���˱����ٺ���ÿ���ͻ��˱�ͬ������(Door��Ҫ����NetowrkIdentity)
    /// ����Ҫ���������岻��SpawnPrefab���˶α�����ڣ�����ͬ�����������пͻ��ˣ��Ͼ��������ֻ�Ǹ���������
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
    //��·��������
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
