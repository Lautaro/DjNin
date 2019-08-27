using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts
{
    class AudioLaggCode
    {
        // WHEN RECORD IS PLACED ON TURNTABLE
        public Carriable Place(Carriable objectToPlace)
        {
            var returnObject = PlacedObject;
            PlacedObject = objectToPlace;
            PlacedObject.transform.position = transform.position;
            ResetRotationOfPlacedObject();
            if (objectToPlace != null)
            {
                var record = objectToPlace.GetComponent<Carriable>().CarriableName;
                MusicManager.Instance.songySong.SetClipVolume(1, record); // tHIS SWITCHES ON THE TRACK
            }

            if (returnObject != null)
            {

                var record = returnObject.CarriableName;
                MusicManager.Instance.songySong.SetClipVolume(0, record);
            }
            return returnObject;
        }

        // SETS VOLUME TO FULL
        public void SetClipVolume(float volume, string clipName)
        {
            var clip = GetClipByName(clipName);
            clip.source.volume = volume;
        }

        // GETS ALL CLIPS
        private SongyClip GetClipByName(string clipName)
        {
            var allClips = GetAllClipsInSongy();
            var returnClip = allClips.FirstOrDefault(c => c.ClipName == clipName);
            return returnClip;
        }

    }
}
