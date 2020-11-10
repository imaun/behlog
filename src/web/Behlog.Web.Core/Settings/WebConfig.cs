using System;
using System.Collections.Generic;
using System.Text;

namespace Behlog.Web.Core.Settings
{
    public class WebConfig
    {
        public int PageSize { get; set; }
        public string UploadPhotoPath { get; set; }
        /// <summary>
        /// Valid photo file extensions seperated by semi-colon(;).
        /// </summary>
        public string ValidPhotoFileExtensions { get; set; }
        public string[] ValidPhotoFileExtensionsList => 
            ValidPhotoFileExtensions?.Split(';');
        public string ValidVideoFileExtensions { get; set; }
        public string[] ValidVideoFileExtensionsList =>
            ValidVideoFileExtensions?.Split(';');
        public string ValidAudioFileExtensions { get; set; }
        public string[] ValidAudioFileExtensionsList =>
            ValidAudioFileExtensions?.Split(';');
        public string ValidDocumentFileExtensions { get; set; }
        public string[] ValidDocumentFileExtensionsList =>
            ValidDocumentFileExtensions?.Split(';');
    }
}
