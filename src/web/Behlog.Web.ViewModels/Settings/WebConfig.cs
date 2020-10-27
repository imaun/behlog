using System;
using System.Collections.Generic;
using System.Text;

namespace Behlog.Web.ViewModels.Settings
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
    }
}
