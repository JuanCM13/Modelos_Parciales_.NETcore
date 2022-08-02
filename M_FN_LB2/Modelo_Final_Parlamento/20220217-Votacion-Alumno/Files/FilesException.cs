using System;

namespace Files
{
    public class FilesException : Exception
    {
        public FilesException(String msje, Exception inner)
            : base(msje,inner)
        { }
    }
}
