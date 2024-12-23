using MoreMountains.Tools;
using System.Linq;
using UnityEngine;

public class MusicManager : Singleton<MusicManager>
{
    [SerializeField] MMPlaylist playlist;

    private bool playlistIsPlaying = false;

    private void Start()
    {
        playlistIsPlaying = true;
    }

    void OnApplicationFocus(bool hasFocus)
    {
        if (playlist != null)
        {
            if (hasFocus && !playlistIsPlaying && playlist.PlaylistState != null)
            {
                playlistIsPlaying = true;
                playlist.Play();
            }
            else if (!hasFocus && playlistIsPlaying)
            {
                playlistIsPlaying = false;
                playlist.Pause();
            }
        }
    }

    /*void OnApplicationPause(bool pauseStatus)
    {
        isPaused = pauseStatus;
    }*/
}
