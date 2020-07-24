using System.Collections;
using System.Collections.Generic;
using System.Security.Authentication.ExtendedProtection;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.UIElements;

public class spotLightController : MonoBehaviour
{

    #region settings
    public float sensitivity = 2.0f;
    public float smoothing = 1.0f;
    #endregion

    #region gameObjects
    public GameObject player;
    #endregion

    #region vectors
    public Vector2 playerMove;
    public Vector2 smoothV;
    #endregion

    // Start is called before the first frame update
    void Start()
    {
        player = this.transform.parent.gameObject;
    }

    // Update is called once per frame
    void Update()
    {

        var md = new Vector2(player.transform.position.x, player.transform.position.y);
        md = Vector2.Scale(md, new Vector2(sensitivity * smoothing, sensitivity * smoothing));

        smoothV.x = Mathf.Lerp(smoothV.x, md.x, 1f / smoothing);
        smoothV.y = Mathf.Lerp(smoothV.y, md.y, 1f / smoothing);
        playerMove += smoothV;
        transform.localRotation = Quaternion.AngleAxis(-playerMove.y, Vector2.right);
        player.transform.localRotation = Quaternion.AngleAxis(playerMove.x, player.transform.up);

    }
}
