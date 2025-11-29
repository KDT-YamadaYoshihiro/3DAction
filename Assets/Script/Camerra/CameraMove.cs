using UnityEngine;

public class CameraMove: MonoBehaviour
{
    public Transform player;  // 追尾するプレイヤーのTransform
    public float smoothSpeed = 0.125f;  // カメラの追尾スピード
    public Vector3 offset;  // プレイヤーからカメラの位置のオフセット

    void LateUpdate()
    {
        // プレイヤーの位置にオフセットを加えた位置を求める
        Vector3 desiredPosition = player.position + offset;

        // 現在のカメラ位置と目標位置との間を滑らかに補間する
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);

        // カメラの位置を更新
        transform.position = smoothedPosition;

        // カメラがプレイヤーを常に向くようにする（オプション）
        transform.LookAt(player);
    }
}
