using System;
using System.Collections.Generic;
using System.Text;

namespace FilesModels
{
    public class ResponseModel
    {
        public bool Succeeded { get; set; }
        public string Message { get; set; }

        public ResponseModel(bool succeeded)
        {
            Succeeded = succeeded;
            
        }
    }
}
