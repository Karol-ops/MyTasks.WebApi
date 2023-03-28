using System.Collections.Generic;
using System.Linq;

namespace MyTasks.WebApi.Models.Response
{
    public class Response
    {
        public Response()
        {
            Errors = new List<Error>();
        }

        public List<Error> Errors { get; set; }
        public bool IsSuccess => Errors == null || !Errors.Any();
    }
}
