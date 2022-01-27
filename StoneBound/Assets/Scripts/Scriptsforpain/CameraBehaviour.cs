using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraBehaviour : MonoBehaviour
{
    public Camera camera;
    public GameObject human_subject, dog_subject;
    //private int current_subject;
    private GameObject current_subject;
    public Vector3 offset;
    public Shader shader;
    
    // Start is called before the first frame update
    void Start()
    {
        current_subject = human_subject;
        camera = gameObject.GetComponent<Camera>();
        camera.RenderWithShader(shader, "PreHistoric");
    }

    // Update is called once per frame
    void Update()
    {
        /*switch (current_subject)
        {
            case 0 :
                gameObject.transform.position = (human_subject.transform.position - offset) * Time.deltaTime;
                break;
            case 1 :
                gameObject.transform.position = (dog_subject.transform.position - offset) * Time.deltaTime;
                break;
            case 2 :
                
                break;
        } */
        gameObject.transform.position = current_subject.transform.position - offset;
        
    }

    public void ChangeViewpoint(int next_position)
    {
        switch (next_position)
        {
            case 0 :
                current_subject = human_subject;
                break;
            case 1 :
                current_subject = dog_subject;
                break;
            case 2 :
                
                break;
        }

        //current_subject = next_position;
    }
}
