using System;
using System.Collections.Generic;
using System.Linq;

namespace MediaCore.ViewModel.Common
{
    public static class MediaFileMimeTypeHelper
    {
        private static Dictionary<string, string> _mimetype => new()
        {
              {"opus", "video/ogg"},
              {"ogv", "video/ogg"},
              {"mp4", "video/mp4" },
              {"mov", "video/mp4"},
              {"m4v", "video/mp4"},
              {"mkv", "video/x-matroska" },
              {"m4a", "audio/mp4" },
              {"mp3", "audio/mpeg" },
              {"aac", "audio/aac" },
              {"caf", "audio/x-caf" },
              {"flac", "audio/flac"},
              {"oga", "audio/ogg" },
              {"wav", "audio/wav"},
              //{"m3u8", "application/x-mpegURL" },
        };

        private const string _defaultMime = "application/octet-stream";

        public static MediaMimeTypeResult TryGet(string fileExtention)
        {
            MediaMimeTypeResult result = new MediaMimeTypeResult();

            var key = _mimetype.Keys.FirstOrDefault(x => x.ToLower() == fileExtention.ToLower());
            if (!string.IsNullOrEmpty(key))
            {
                result.MimeType = _mimetype[key];

                if (result.MimeType.Contains("video", StringComparison.OrdinalIgnoreCase))
                {
                    result.PlayType = MediaFilePlayTypeEnum.Video;
                }

                if (result.MimeType.Contains("audio", StringComparison.OrdinalIgnoreCase))
                {
                    result.PlayType = MediaFilePlayTypeEnum.Audio;
                }
            }
            else
            {
                result.MimeType = _defaultMime;
                result.PlayType = MediaFilePlayTypeEnum.Default;
            }

            return result;
        }
    }
}
