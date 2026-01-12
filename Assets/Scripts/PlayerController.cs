using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private float horizontalInput;
    private bool isReleased = false;

    // Update is called once per frame
    void Update()
    {
        MoveHorizontal();
    }


    // Move object horizontal
    private void MoveHorizontal()
    {
        if (!isReleased)
        {
            horizontalInput = Input.GetAxis("Horizontal");

            transform.Translate(Vector3.forward * Time.deltaTime * 5.0f * horizontalInput);
        }
    }

    public void SetIsReleased(bool NewIsReleased)
    {
        isReleased = NewIsReleased;
    }
}
