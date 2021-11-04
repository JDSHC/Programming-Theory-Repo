using UnityEngine;

public class FollowPlayer : MonoBehaviour {

    public GameObject player;
    private Vector3 _playerPos;

    // Update is called once per frame
    void Update () {

        _playerPos = player.transform.position;
        this.transform.position = _playerPos;
    }
}