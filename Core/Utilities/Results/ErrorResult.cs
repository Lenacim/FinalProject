using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Results
{
    public class ErrorResult : Result
    {
        public ErrorResult(string mesagge): base(false, mesagge)
        {

        }
        public ErrorResult() : base(false)
        {

        }
    }
}
