using UnityEngine;
using UnityEngine.Video;
using UnityEngine.SceneManagement;

public class VideoController : MonoBehaviour
{
    public string sceneToLoad; // El nombre de tu escena (en este caso "Level1").
    private VideoPlayer videoPlayer;

    void Start()
    {
        // Obtén el componente VideoPlayer y registra el evento.
        videoPlayer = GetComponent<VideoPlayer>();
        videoPlayer.loopPointReached += OnVideoEnd;
    }

    void OnVideoEnd(VideoPlayer vp)
    {
        // Cambia a la escena especificada.
        SceneManager.LoadScene(sceneToLoad);
    }
}
